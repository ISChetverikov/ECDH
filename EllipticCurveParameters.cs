using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ECDH
{
    public class EllipticCurveParameters
    {
        public BigInteger FieldCharacteristic { get; }

        public int A { get; }

        public int B { get; }

        public Point BasePoint { get; }

        public BigInteger SubGroupOrder { get; }

        public int SubGroupCofactor { get; }

        public EllipticCurveParameters(
            BigInteger fieldCharacteristic,
            int a,
            int b,
            Point point,
            BigInteger subGroupOrder,
            int subGroupCofactor)
        {
            FieldCharacteristic = fieldCharacteristic;
            A = a;
            B = b;
            BasePoint = point;
            SubGroupOrder = subGroupOrder;
            SubGroupCofactor = subGroupCofactor;
        }
    }
}
