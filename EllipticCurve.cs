using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using ECDH.Exceptions;

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
            if (!IsOnCurve(first))
            {
                throw new PointIsNotOnCurveExceptioin("First point is not on the curve");
            }

            if (!IsOnCurve(second))
            {
                throw new PointIsNotOnCurveExceptioin("Second point is not on the curve");
            }

            if (first == Point.InfinityPoint)
                return new Point(first);

            if (second == Point.InfinityPoint)
                return new Point(second);

            BigInteger x1 = first.X ?? default(BigInteger);
            BigInteger y1 = first.Y ?? default(BigInteger);
            BigInteger x2 = second.X ?? default(BigInteger);
            BigInteger y2 = second.Y ?? default(BigInteger);

            BigInteger m = 0;
            if (x1 == x2 && y1 != y2)
                return Point.InfinityPoint;

            if (x1 == x2)
                m = (3 * x1 * x1 + Parameters.A)
                    * ModuloArithmetics.Inverse(2 * y1, Parameters.FieldCharacteristic);
            else
                m = (y1 - y2) * ModuloArithmetics.Inverse(x1 - x2, Parameters.FieldCharacteristic);

            var x = m * m - x1 - x2;
            var y = y1 + m * (x - x1);

            var point = new Point(x, y);
            if (!IsOnCurve(point))
                throw new PointIsNotOnCurveExceptioin("Result point of adding is not on the curve");

            return point;
        }
    }
}
