using _2Good2EatBackendStore.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace _2Good2EatBackendStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IConfiguration config) : ControllerBase
    {

        [HttpPost("/GenerateKeyForImagekit")]
        public string GenerateKeyForImagekit()
        {
            var token = Guid.NewGuid().ToString();
            Int32 unixTimestamp = (int)DateTime.UtcNow.AddMinutes(30).Subtract(DateTime.UnixEpoch).TotalSeconds;
            var timestamp = unixTimestamp.ToString();
            var key = Encoding.UTF8.GetBytes(config["Keys:ImageKitPrivateKey"]);
            var sigText = Encoding.UTF8.GetBytes(token + timestamp);
            string testSig;
            using (HMACSHA1 hash = new(key))
            {
                MemoryStream stream = new(sigText);
                testSig = hash.ComputeHash(stream).Aggregate("", (s, e) => s + String.Format("{0:x2}", e), s => s);
            }
    
            var test = new ImagekitAuthModel()
            {
                token = token,
                expire = timestamp,
                signature = testSig

            };


            return JsonSerializer.Serialize(test);

        }
    }
}
