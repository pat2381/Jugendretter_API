using AutoMapper;
using Jugendretter_API.Auth;
using Jugendretter_API.Contracts;
using Jugendretter_API.Entities;
using Jugendretter_API.Entities.Migrations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Jugendretter_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IRepositoryWrapper _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

       
        public UserController(ILoggerManager loggerManager, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = loggerManager;
            _repository= repository;
            _mapper = mapper;
        }

        [ApiKey]
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userlist = await _repository.User.Get();
                //var json = JsonConvert.SerializeObject(userlist, Formatting.Indented);
                return Ok(userlist);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetUser() action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

            [ApiKey]
        [HttpGet("{ID}")]
        public async Task<IActionResult> GetUser(Guid ID)
        {
            var user = await _repository.User.Get(ID);

            return new JsonResult(user);
        }




        [ApiKey]
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            var newUser = await _repository.User.Create(user);
            return CreatedAtAction(nameof(GetUser), new { newUser.ID });

        }

        [ApiKey]
        [HttpPut]
        public async Task<IActionResult> Update(Guid ID, [FromBody] User user)
        {
            if(ID != user.ID)
            {
                return BadRequest();
            }

            await _repository.User.Update(user);

            return NoContent();
        }

        [ApiKey]
        [HttpDelete]
        public async Task<IActionResult> DeleteUser(Guid ID)
        {
            var deleteUuser = await _repository.User.Get(ID);
            if(deleteUuser == null)
            {
                return NotFound();
            }

            await _repository.User.Delete(deleteUuser.ID);
            return NoContent();
        }
    }
}
