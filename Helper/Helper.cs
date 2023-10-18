using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Data.SqlTypes;
using System.Security.Cryptography;

namespace backend.Helper
{
    public class Helper: IHelper
    {
        public Helper(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; set; }

        public string GetHashed(string key)
        {
            var salt = Configuration.GetSection("Salt").Value;
            var saltBytes = Convert.FromBase64String(salt);
            var hashed = KeyDerivation.Pbkdf2(
                                password: key!,
                                salt: saltBytes,
                                prf: KeyDerivationPrf.HMACSHA256,
                                iterationCount: 100000,
                                numBytesRequested: 256 / 8);
            return Convert.ToBase64String(hashed);
        }


    }
}
