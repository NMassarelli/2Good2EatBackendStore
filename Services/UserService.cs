using _2Good2EatBackendStore.Data;
using _2Good2EatBackendStore.Data.Entities;
using _2Good2EatBackendStore.Interfaces;
using _2Good2EatBackendStore.Models;
using System.Security.Claims;
namespace _2Good2EatBackendStore.Services

{
    public class UserService(ApplicationDbContext context, IAuthenticationHelperService authenticationHelperService) : IUserService
    {
        private readonly ApplicationDbContext _dbContext = context;
        private readonly IAuthenticationHelperService _authenticationHelperService = authenticationHelperService;
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

        private ApplicationUser GetUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(x => x.Email == email);
        }
        public bool RegisterUser(RegistrationRequest newUser)
        {
            ApplicationUser user = new()
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                EmailConfirmed = false,
                PasswordHash = _authenticationHelperService.HashPassword(newUser.Password,newUser.Email),
                
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


        public string ProcessLogin(LoginRequest request)
        {
            var user = GetUserByEmail(request.Email);
            List<Claim> claims = [];
            if (user == null)
            {
                claims.Add(new Claim(ClaimTypes.AuthorizationDecision, "false"));
                return _authenticationHelperService.GenerateJwtToken(claims);
            }

            var compare = _authenticationHelperService.ComparePassword(request.Password, request.Email, user.PasswordHash);
 
            if (compare)
            {
                claims.Add(new Claim(ClaimTypes.AuthorizationDecision, "true"));
                claims.Add(new Claim(ClaimTypes.Name, user.Email));
                claims.Add(new Claim(ClaimTypes.Role, user.Role.ToString()));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.AuthorizationDecision, "false"));
            }

            return _authenticationHelperService.GenerateJwtToken(claims);

        }

    }
}
