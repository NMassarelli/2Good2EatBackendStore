using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Data.Models;
using _2Good2EatBackendStore.Interfaces;
using _2Good2EatStore.Data;
using _2Good2EatStore.Data.Enums;
using _2Good2EatStore.Interfaces;
namespace _2Good2EatBackendStore.Services

{
    public class UserService(ApplicationDbContext context, IAuthenticationHelperService authenticationHelperService) : IUserService
    {
        private readonly ApplicationDbContext _dbContext = context;
        private readonly IAuthenticationHelperService _authenticationHelperService;
        public void DeleteUser(string id)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public ApplicationUser GetUserById(string id)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Id == id);
        }

        public bool RegisterUser(ApplicationUserModel newUser)
        {
            ApplicationUser user = new()
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                EmailConfirmed = false,
                PasswordHash = _authenticationHelperService.HashPassword(newUser.Password),
                
            };

            SaveUser(user);
            return true;
        }

        public void SaveUser(ApplicationUser user)
        {
            var trackedReference = _dbContext.Users.Local.SingleOrDefault(p => p.Id == user.Id);

            if (trackedReference == null)
            {
                _dbContext.Users.Update(user);
            }
            else if (!Object.ReferenceEquals(trackedReference, user))
            {
                _dbContext.Entry(trackedReference).CurrentValues.SetValues(user);
            }

            _dbContext.SaveChanges();
        }
    }
}
