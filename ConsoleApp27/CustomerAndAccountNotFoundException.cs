using System;
using System.Runtime.Serialization;

namespace ConsoleApp27
{
    [Serializable]
    internal class CustomerAndAccountNotFoundException : Exception
    {
        public CustomerAndAccountNotFoundException()
        {
        }

        public CustomerAndAccountNotFoundException(string message) : base(message)
        {
        }

        public CustomerAndAccountNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerAndAccountNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}