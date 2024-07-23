using Microsoft.AspNetCore.Identity;

namespace _2Good2EatBackendStore.Data.Entities
{
    public class ApplicationUser 
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
    }

}
