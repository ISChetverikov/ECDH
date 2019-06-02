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
            var parameters = ParametersFactory.Custom();
            var EC = new EllipticCurve(parameters);

            Console.WriteLine("======================");
            var p = new Point(3, 5);
            var q = new Point(3, 5);

            
            Console.WriteLine(EC.Add(q, q));
            
            
        }
    }
}
