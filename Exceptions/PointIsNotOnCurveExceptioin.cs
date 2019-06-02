using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECDH.Exceptions
{
    public class PointIsNotOnCurveExceptioin : Exception
    {
        public PointIsNotOnCurveExceptioin(string message) : base(message)
        {
        }
    }
}
