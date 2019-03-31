using System;
using System.Runtime.Serialization;

namespace ConsoleApp27
{
    [Serializable]
    internal class CustomerNotFountException : Exception
    {
        public CustomerNotFountException()
        {
        }

        public CustomerNotFountException(string message) : base(message)
        {
        }

        public CustomerNotFountException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CustomerNotFountException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}