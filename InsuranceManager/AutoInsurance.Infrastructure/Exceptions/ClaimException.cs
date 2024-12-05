

namespace Autoinsurance.Infrastructure.Exceptions
{
    public class ClaimException : Exception
    {
        public ClaimException()
        {
        }

        public ClaimException(string message)
            : base(message)
        {
        }

        public ClaimException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
