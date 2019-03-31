using System;
using System.Runtime.Serialization;

namespace ConsoleApp27
{
    [Serializable]
    internal class BothAccountsNotFoundException : Exception
    {
        public BothAccountsNotFoundException()
        {
        }

        public BothAccountsNotFoundException(string message) : base(message)
        {
        }

        public BothAccountsNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BothAccountsNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}