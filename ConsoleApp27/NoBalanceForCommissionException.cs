using System;
using System.Runtime.Serialization;

namespace ConsoleApp27
{
    [Serializable]
    internal class NoBalanceForCommissionException : Exception
    {
        public NoBalanceForCommissionException()
        {
        }

        public NoBalanceForCommissionException(string message) : base(message)
        {
        }

        public NoBalanceForCommissionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoBalanceForCommissionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}