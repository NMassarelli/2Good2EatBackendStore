using _2Good2EatBackendStore.Interfaces;
using _2Good2EatBackendStore.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public string HashPassword(string password, string userName)
        {
            byte[] hashedSigniture;
            using (HMACSHA256 hash = new(Encoding.UTF8.GetBytes(userName)))
            {
                MemoryStream stream = new(Encoding.UTF8.GetBytes(password));
                hashedSigniture = hash.ComputeHash(stream);
            }
            return Convert.ToBase64String(hashedSigniture);
        }

        public bool ComparePassword(string password, string userName, string hash)
        {
            byte[] hashedSigniture;
            using (HMACSHA256 compareHash = new(Encoding.UTF8.GetBytes(userName)))
            {
                MemoryStream stream = new(Encoding.UTF8.GetBytes(password));
                hashedSigniture = compareHash.ComputeHash(stream);
            }

            return Convert.ToBase64String(hashedSigniture).Equals(hash);
        }

        public string GenerateJwtToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Keys:IssuerSecret"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    
            var token = new JwtSecurityToken(
                issuer: config["Keys:tokenIssuer"],
                audience: config["Keys:tokenAudiance"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


    }
}
