using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoInsurance.Application.Exceptions
{
    public class PolicyNotFoundException : Exception
    {
        public PolicyNotFoundException(string message) : base(message)
        {
        }
    }
}
