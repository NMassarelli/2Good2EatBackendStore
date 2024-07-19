using _2Good2EatBackendStore.Data.Models;
using _2Good2EatBackendStore.Interfaces;
using _2Good2EatStore.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace _2Good2EatBackendStore.Services
{
    public class AuthenticationHelperService(IConfiguration config) : IAuthenticationHelperService
    {
        public ImagekitAuthModel ProcessImagekitAuthenticationToken()
        {
            var token = Guid.NewGuid().ToString();
            Int32 unixTimestamp = (int)DateTime.UtcNow.AddMinutes(30).Subtract(DateTime.UnixEpoch).TotalSeconds;
            var timestamp = unixTimestamp.ToString();
            var key = Encoding.UTF8.GetBytes(config["Keys:ImageKitPrivateKey"]);
            var sigText = Encoding.UTF8.GetBytes(token + timestamp);
            string hashedSigniture;
            using (HMACSHA1 hash = new(key))
            {
                MemoryStream stream = new(sigText);
                hashedSigniture = hash.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
            }

            return new ImagekitAuthModel()
            {
                token = token,
                expire = timestamp,
                signature = hashedSigniture

            };
        }

        public string HashPassword(string password)
        {
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password)));
        }

        public bool ComparePassword(string password, string hash)
        {
            return Convert.ToBase64String(SHA256.HashData(Encoding.UTF8.GetBytes(password))).Equals(hash);
        }
    }
}
