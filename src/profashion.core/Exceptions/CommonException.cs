using System;

namespace profashion.core.Exceptions
{
    public class CommonException : Exception
    {
        public string Code { get; }

        public CommonException()
        {
        }

        public CommonException(string code)
        {
            Code = code;
        }

        public CommonException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        public CommonException(string code, string message, params object[] args) : this(null, code, message, args)
        {
        }

        public CommonException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public CommonException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }

}