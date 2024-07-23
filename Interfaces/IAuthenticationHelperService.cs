using _2Good2EatBackendStore.Models;
using System.Security.Claims;

namespace _2Good2EatBackendStore.Interfaces
{
    public interface IAuthenticationHelperService
    {
        ImagekitAuthModel ProcessImagekitAuthenticationToken();
        string HashPassword(string password, string userName);
        bool ComparePassword(string password, string userName, string hash);
        string GenerateJwtToken(List<Claim> claims);
    }
}
