using Jugendretter_API.Auth;
using Jugendretter_API.Contracts;
using Jugendretter_API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Jugendretter_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository userRepository;

       
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        [ApiKey]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userlist = await userRepository.Get();

            //var json = JsonConvert.SerializeObject(userlist, Formatting.Indented);
            return Ok(userlist);
        }

            [ApiKey]
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetUser(int ID)
        {
            var user = await userRepository.Get(ID);

            return new JsonResult(user);
        }

        [ApiKey]
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            var newUser = await userRepository.Create(user);
            return CreatedAtAction(nameof(GetUser), new { newUser.ID });

        }

        [ApiKey]
        [HttpPut]
        public async Task<IActionResult> Update(int ID, [FromBody] User user)
        {
            if(ID != user.ID)
            {
                return BadRequest();
            }

            await userRepository.Update(user);

            return NoContent();
        }

        [ApiKey]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(int ID)
        {
            var deleteUuser = await userRepository.Get(ID);
            if(deleteUuser == null)
            {
                return NotFound();
            }

            await userRepository.Delete(deleteUuser.ID);
            return NoContent();
        }
    }
}
