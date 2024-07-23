using _2Good2EatBackendStore.Interfaces;
using _2Good2EatBackendStore.Models;
using Microsoft.AspNetCore.Authorization;
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

    public class AuthenticationController(IAuthenticationHelperService authenticationHelperService, 
        IUserService userService) : ControllerBase
    {

        private readonly IAuthenticationHelperService _authenticationHelperService = authenticationHelperService;
        private readonly IUserService _userService = userService;

        [Authorize]
        [HttpPost("/GenerateKeyForImagekit")]
        public string GenerateKeyForImagekit()
        {
            return JsonSerializer.Serialize(_authenticationHelperService.ProcessImagekitAuthenticationToken);
        }

        [HttpPost("/Login")]
        public string Login([FromBody] LoginRequest auth)
        {
            return string.Empty;
        }

    }
}
