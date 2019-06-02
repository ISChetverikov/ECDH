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

            // Stuff
            var x = point.X ?? throw new ArgumentException();
            var y = point.Y ?? throw new ArgumentException();
            var a = Parameters.A;
            var b = Parameters.B;
            var p = Parameters.FieldCharacteristic;

            return ModuloArithmetics.Mod((y * y - x * x * x - a * x - b), p) == 0;
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
                return new Point(second);

            if (second == Point.InfinityPoint)
                return new Point(first);

            BigInteger x1 = first.X ?? throw new ArgumentException();
            BigInteger y1 = first.Y ?? throw new ArgumentException();
            BigInteger x2 = second.X ?? throw new ArgumentException();
            BigInteger y2 = second.Y ?? throw new ArgumentException();

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

            var point = new Point(
                ModuloArithmetics.Mod( x, Parameters.FieldCharacteristic),
                ModuloArithmetics.Mod(-y, Parameters.FieldCharacteristic));

            if (!IsOnCurve(point))
                throw new PointIsNotOnCurveExceptioin("Result point of adding is not on the curve");

            return point;
        }

        public Point Neg(Point point)
        {
            if (!IsOnCurve(point))
            {
                throw new PointIsNotOnCurveExceptioin("Point is not on the curve");
            }

            if (point == Point.InfinityPoint)
                return Point.InfinityPoint;

            // Stuff
            BigInteger y = point.Y ??
                throw new ArgumentException();

            return new Point(point.X,
                ModuloArithmetics.Mod(-y, Parameters.FieldCharacteristic));
        }

        public Point Multiply(BigInteger k, Point point)
        {
            if (!IsOnCurve(point))
            {
                throw new PointIsNotOnCurveExceptioin("Point is not on the curve");
            }

            if (ModuloArithmetics.Mod(k, Parameters.SubGroupOrder) == 0
                || point == Point.InfinityPoint)
                return Point.InfinityPoint;

            if (k < 0)
                return Multiply(-k, Neg(point));

            BigInteger copy = k;
            Point result = Point.InfinityPoint;
            Point currentPow = point;

            while(copy > 0)
            {
                if (copy % 2 == 1)
                    result = Add(result, currentPow);

                currentPow = Add(currentPow, currentPow);
                copy = copy / 2;
            }

            return result;
        }
    }
}
