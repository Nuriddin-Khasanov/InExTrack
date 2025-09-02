using InExTrack.DTOs.Requests;
using InExTrack.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InExTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetAll(cancellationToken));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetUserByIdAsync(Guid _userId, CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetUserById(_userId, cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] UserRequestsDto _user, CancellationToken cancellationToken)
        {
            return Ok(await _userService.AddUser(_user, cancellationToken));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRequestsDto userDto, CancellationToken cancellationToken)
        {
            return Ok(await _userService.UpdateUserById(id, userDto, cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _userService.DeleteUser(id, cancellationToken));
        }
    }
}
