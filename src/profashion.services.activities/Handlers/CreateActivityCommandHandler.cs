using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using profashion.business.Models;
using profashion.core.Commands;
using profashion.core.Events;
using profashion.core.Exceptions;
using profashion.services.activities.Services;
using RawRabbit;

namespace profashion.services.activities.Handlers
{
    public class CreateActivityCommandHandler : ICommandHandler<CreateActivityCommand>
    {
        private readonly IBusClient _busClient;
        private readonly IService<Activity> _activityService;
        private readonly ILogger<CreateActivityCommandHandler> _logger;

        public CreateActivityCommandHandler(IBusClient busClient, IService<Activity> activityService,
            ILogger<CreateActivityCommandHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateActivityCommand command)
        {
            _logger.LogInformation($"{DateTime.Now} --> {nameof(ActivityCreatedEvent)}");
            try
            {
                await _activityService.AddAsync(new Activity(command.UserId, command.Category, command.Name,
                    command.Description, command.CreatedAt));
                await _busClient.PublishAsync(new ActivityCreatedEvent(command.Id, command.Id, command.Category,
                    command.Name, command.Description, command.CreatedAt));
            }
            catch (CommonException e)
            {
                await _busClient.PublishAsync(new CreateActivityRejectedEvent(command.Id, e.Message, e.Code));
                _logger.LogError(e.Message);
            }
            catch (Exception e)
            {
                await _busClient.PublishAsync(new CreateActivityRejectedEvent(command.Id, "error", e.Message));
                _logger.LogError(e.Message);
            }
        }
    }
}