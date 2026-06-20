using System.Security.Cryptography;

namespace NativeZipTools.Crypto
{
    public static class EncryptionService
    {
        public static byte[] Encrypt(
            byte[] data,
            string password)
        {
            using var aes = Aes.Create();

            aes.KeySize = 256;

            return data;
        }
    }
}