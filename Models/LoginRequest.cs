namespace _2Good2EatBackendStore.Models
{
    public class LoginRequest
    {
       public string Email { get; set; }
       public string Password { get; set; }
      
    }

    public class LoginResponse
    {
       public ApplicationUserModel User { get; set; }
       public string Token { get; set; }

    }

    public class RegistrationRequest 
    { 
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    
    }
}
