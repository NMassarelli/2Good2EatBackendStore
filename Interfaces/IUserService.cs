using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Data.Models;

namespace _2Good2EatBackendStore.Interfaces
{
    public interface IUserService
    {
        ApplicationUser  GetUserById(string id);
        void SaveUser(ApplicationUser user);
        void DeleteUser(string id);

        bool RegisterUser(ApplicationUserModel newUser);
    }
}
