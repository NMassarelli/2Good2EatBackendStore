using _2Good2EatBackendStore.Interfaces;
using _2Good2EatBackendStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace _2Good2EatBackendStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {

        private readonly IUserService _userService = userService;
        // GET api/<UserController>/5
        [HttpGet("{id}")]
        [Authorize]
        public ApplicationUserModel Get(string id)
        {
            return _userService.GetUserById(id).MapToModel();
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] ApplicationUserModel value)
        {

        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }


        [HttpPost("register")]
        public bool Register(RegistrationRequest model)
        {
            return _userService.RegisterUser(model);
        }
    }
}
