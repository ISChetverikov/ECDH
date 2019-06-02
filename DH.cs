using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ECDH
{
    public static class DH
    {
        public static void Execute(EllipticCurve curve)
        {
            var AliceKeys = GenerateKeys(curve);
            var BobKeys = GenerateKeys(curve);

            Console.WriteLine("\nAlice`s key:\n");
            Console.WriteLine(AliceKeys);
            Console.WriteLine("\nBob`s key\n");
            Console.WriteLine(BobKeys);

            var AliceSecret = curve.Multiply(AliceKeys.Private, BobKeys.Public);
            var BobSecret = curve.Multiply(BobKeys.Private, AliceKeys.Public);

            Console.WriteLine("\nAlice`s secret:\n");
            Console.WriteLine(AliceSecret);
            Console.WriteLine("\nBob`s secret\n");
            Console.WriteLine(BobSecret);
        }

        public static Keys GenerateKeys(EllipticCurve curve)
        {
            var privateKey = RandomBigInteger(curve.Parameters.FieldCharacteristic);
            var publicKey = curve.Multiply(privateKey, curve.Parameters.BasePoint);

            return new Keys(privateKey, publicKey);
        }

        private static BigInteger RandomBigInteger(BigInteger N)
        {
            byte[] bytes = N.ToByteArray();
            BigInteger R;
            Random random = new Random();

            do
            {
                random.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                R = new BigInteger(bytes);
            } while (R >= N);

            return R;
        }
    }
}
