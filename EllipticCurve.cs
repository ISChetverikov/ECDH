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

            var m = 0;
            if (first.X == second.X && first.Y != second.Y)
                return Point.InfinityPoint;

            return Point.InfinityPoint;
            //if (first.X == second.X)
            //    m = (3 * first.X * first.X + Parameters.A)               
        }
    }
}
