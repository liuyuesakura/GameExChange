using System;
using System.Runtime.Serialization;

namespace GameExChange.Domain
{
    /// <summary>
    /// 领域异常
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException() : base() { }

        public DomainException(string message) : base(message) { }

        public DomainException(string message,Exception innerException) : base(message, innerException) { }

        public DomainException(string format,params object[] args) : base(string.Format(format, args)) { }

        public DomainException(SerializationInfo info,StreamingContext context) : base(info, context) { }
    }
}
