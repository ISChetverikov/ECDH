using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ECDH
{
    public class Keys
    {
        public BigInteger Private { get; }

        public Point Public { get; }

        public Keys(BigInteger _private, Point _public){
            Public = _public;
            Private = _private;
        }

        public override string ToString()
        {
            return $"\tPrivate:\n\t{Private}\n\tPublic:\n\t{Public}\n";
        }
    }
}
