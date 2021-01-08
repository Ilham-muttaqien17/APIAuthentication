using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace APIAuthentication.Utils
{
    public class Common
    {
        public static byte[] GetRandomSalt(int length)
        {
            var random = new RNGCryptoServiceProvider();
            byte[] salt = new byte[length];
            random.GetNonZeroBytes(salt);
            return salt;
        }

        public static byte[] SaltHashPassword(byte[] password, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] plainTextWithSaltByte = new byte[password.Length + salt.Length];

            for(int i = 0; i < password.Length; i++)
            {
                plainTextWithSaltByte[i] = password[i];
            }

            for(int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltByte[password.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltByte);
        }
    }
}
