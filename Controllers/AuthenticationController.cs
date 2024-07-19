using _2Good2EatBackendStore.Data.Models;
using _2Good2EatBackendStore.Interfaces;
using _2Good2EatStore.Interfaces;
using _2Good2EatStore.Services;
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
    public class AuthenticationController(IAuthenticationHelperService authenticationHelperService) : ControllerBase
    {

        private readonly IAuthenticationHelperService _authenticationHelperService = authenticationHelperService;
        
        [HttpPost("/GenerateKeyForImagekit")]
        public string GenerateKeyForImagekit()
        {
            return JsonSerializer.Serialize(_authenticationHelperService.ProcessImagekitAuthenticationToken);
        }
    }
}
