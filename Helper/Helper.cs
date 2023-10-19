using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace backend.Helper
{
    public class Helper
    {

        public static void CreateHash(string toBeHashed, out byte[] hashed, out byte[] salt)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(toBeHashed));
        }

        public static bool VerifyHash(string toBeVerified, byte[] hashed, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            salt = hmac.Key;
            var generatedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(toBeVerified));
            return generatedHash.SequenceEqual(hashed);
        }


    }
}
