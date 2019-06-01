using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ECDH1
{
    class EllipticCurveParameters
    {
        public BigInteger FieldCharacteristic { get; }

        public int A { get; }

        public int B { get; }

        public Tuple<BigInteger, BigInteger> Point { get; }

        public BigInteger SubGroupOrder { get; }

        public int SubGroupCofactor { get; }

        public EllipticCurveParameters(
            BigInteger fieldCharacteristic,
            int a,
            int b,
            Tuple<BigInteger, BigInteger> point,
            BigInteger subGroupOrder,
            int subGroupCofactor)
        {
            FieldCharacteristic = fieldCharacteristic;
            A = a;
            B = b;
            Point = point;
            SubGroupOrder = subGroupOrder;
            SubGroupCofactor = subGroupCofactor;
        }
    }
}
