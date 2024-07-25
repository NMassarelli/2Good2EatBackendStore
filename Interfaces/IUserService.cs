using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Models;
using System.Security.Claims;

namespace _2Good2EatBackendStore.Interfaces
{
    public interface IUserService
    {
        ApplicationUser  GetUserById(string id);
        void SaveUser(ApplicationUser user);
        void DeleteUser(string id);
        bool RegisterUser(RegistrationRequest newUser);
        string ProcessLogin(LoginRequest request);
    }
}
