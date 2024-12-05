

namespace Autoinsurance.Infrastructure.Exceptions
{
    public class PolicyException : Exception
    {
        public PolicyException()
        {
        }

        public PolicyException(string message)
            : base(message)
        {
        }

        public PolicyException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
