using System.Security.Cryptography;

namespace GeneralRPS.App
{
    public class HmacGenerator
    {
        private byte[] GenerateHmac(byte[] key, byte[] data)
        {
            using var hmac = new HMACSHA256(key);
            return hmac.ComputeHash(data);
        }
        
        public byte[] Generate(byte[] key, byte[] data) => 
            GenerateHmac(key, data);

        public byte[] Generate(byte[] key) => 
            GenerateHmac(key, key);
    }
}
