﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ECDH
{
    public class Point
    {
        public BigInteger? X { get; }

        public BigInteger? Y { get; }

        public Point(BigInteger? x, BigInteger? y)
        {
            X = x;
            Y = y;
        }

        public static Point InfinityPoint
        {
            get
            {
                return new Point(null, null);
            }
        }

        public static bool operator !=(Point left, Point right)
        {
            return !(left == right);
        }

        public static bool operator ==(Point left, Point right)
        {
            if (left.X == right.X && left.Y == right.Y)
                return true;

            return false;
        }
    }
}
