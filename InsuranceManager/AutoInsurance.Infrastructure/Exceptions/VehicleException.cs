

namespace Autoinsurance.Infrastructure.Exceptions
{
    public class VehicleException : Exception
    {
        public VehicleException()
        {
        }

        public VehicleException(string message)
            : base(message)
        {
        }

        public VehicleException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
