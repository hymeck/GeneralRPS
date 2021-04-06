using System;
using System.Security.Cryptography;

namespace GeneralRPS.App
{
    public static class Utils
    {
        private static byte[] GetRandomBytes(int size)
        {
            using var g = RandomNumberGenerator.Create();
            var b = new byte[size];
            g.GetNonZeroBytes(b);
            return b;
        }
        
        public static byte[] GenerateKey() => 
            GetRandomBytes(16);

        public static int GenerateRandomShapeNumber(int min, int max)
        {
            var b = GetRandomBytes(4);
            var v = BitConverter.ToInt32(b);
            // https://stackoverflow.com/a/3057867/86411
            return ((v - min) % (max - min + 1) + (max - min + 1)) % (max - min + 1) + min;
        }

        public static (byte[] keyHmac, byte[] hmac) GenerateHmacs(int shapeNumber)
        {
            var key = GenerateKey();
            var hg = new HmacGenerator();
            var keyHmac = hg.Generate(key);
            var hmac = hg.Generate(key, BitConverter.GetBytes(shapeNumber));
            return (keyHmac, hmac);
        }
    }
}
