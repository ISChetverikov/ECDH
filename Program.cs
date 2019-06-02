using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECDH
{
    class Program
    {
        static void Main(string[] args)
        {
            var parameters = ParametersFactory.Secp256k1();
            var EC = new EllipticCurve(parameters);

            DH.Execute(EC);
        }
    }
}
