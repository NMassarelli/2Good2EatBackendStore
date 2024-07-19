using _2Good2EatBackendStore.Data.Models;
using _2Good2EatBackendStore.Interfaces;
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
        public ApplicationUserModel Get(string id)
        {
            return _userService.GetUserById(id).MapToModel();
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] ApplicationUserModel value)
        {

        }


        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpPost("register")]
        public bool Register(ApplicationUserModel model)
        {
            return _userService.RegisterUser(model);
        }
    }
}
