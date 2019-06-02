using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ECDH
{
    public static class ModuloArithmetics
    {
        /// <summary>
        /// Return x: (xk) % p == 1
        /// </summary>
        /// <param name="k"></param>
        /// <param name="p"></param>
        public static BigInteger Inverse(BigInteger k, BigInteger p)
        {
            if (k == 0)
                throw new DivideByZeroException("Cannot inverse zero element");

            if (k < 0)
                return p - Inverse(-k, p);

            BigInteger a = p;
            BigInteger b = k % p;
            BigInteger x_prev = 1;
            BigInteger x_next = 0;
            BigInteger y_prev = 0;
            BigInteger y_next = 1;

            BigInteger x=1, y=0, q, r;

            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                x = x_prev - q * x_next;
                y = y_prev - q * y_next;

                a = b;
                b = r;
                x_prev = x_next;
                x_next = x;
                y_prev = y_next;
                y_next = y;
            }

            y = y_prev;
            return y >= 0 ? y % p : p - (-y % p);
        }
    }
}
