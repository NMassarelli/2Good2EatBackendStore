using _2Good2EatBackendStore.Data.Models;

namespace _2Good2EatBackendStore.Interfaces
{
    public interface IAuthenticationHelperService
    {
        public ImagekitAuthModel ProcessImagekitAuthenticationToken();
        string HashPassword(string password);
    }
}
