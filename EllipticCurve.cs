using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ECDH
{
    public class EllipticCurve
    {
        public EllipticCurveParameters Parameters { get; }

        public EllipticCurve(EllipticCurveParameters parameters)
        {
            Parameters = parameters;
        }

        public bool IsOnCurve(Point point)
        {
            if (point == Point.InfinityPoint)
                return true;

            var x = point.X;
            var y = point.Y;
            var a = Parameters.A;
            var b = Parameters.B;
            var p = Parameters.FieldCharacteristic;

            return (y * y - x * x * x - a * x - b) % p == 0;
        }

        public Point Add(Point first, Point second)
        {

        }
    }
}
