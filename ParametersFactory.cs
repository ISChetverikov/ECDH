﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ECDH
{
    public static class ParametersFactory
    {
        public static EllipticCurveParameters Secp256k1()
        {
            return
                new EllipticCurveParameters(
                    BigInteger.Parse("0fffffffffffffffffffffffffffffffffffffffffffffffffffffffefffffc2f", System.Globalization.NumberStyles.AllowHexSpecifier),
                    0,
                    7,
                    new Point(
                        BigInteger.Parse("079be667ef9dcbbac55a06295ce870b07029bfcdb2dce28d959f2815b16f81798", System.Globalization.NumberStyles.AllowHexSpecifier),
                        BigInteger.Parse("0483ada7726a3c4655da4fbfc0e1108a8fd17b448a68554199c47d08ffb10d4b8", System.Globalization.NumberStyles.AllowHexSpecifier)),
                    BigInteger.Parse("0fffffffffffffffffffffffffffffffebaaedce6af48a03bbfd25e8cd0364141", System.Globalization.NumberStyles.AllowHexSpecifier),
                    1);

        }
    }
}
