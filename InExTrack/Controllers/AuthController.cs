using InExTrack.DTOs.Requests;
using InExTrack.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InExTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserService _userService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest_ request)
        {
            var token = await _userService.AuthenticateAsync(request.Username, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(token);
        }

        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser([FromForm] UserRequestsDto request, CancellationToken cancellationToken)
        {
            var success = await _userService.RegisterUserAsync(request, cancellationToken);

            return Ok(success);
        }

        [Authorize]
        [HttpGet("id")]
        public async Task<IActionResult> GetUserByIdAsync(Guid _userId, CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetUserById(_userId, cancellationToken));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserRequestsDto userDto, CancellationToken cancellationToken)
        {
            return Ok(await _userService.UpdateUserById(id, userDto, cancellationToken));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _userService.DeleteUser(id, cancellationToken));
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPost("register/admin")]
        //public async Task<IActionResult> RegisterAdmin([FromBody] RegisterRequest_ request)
        //{
        //    var currentAdmin = await _authService.AuthenticateAsync(User.Identity!.Name!, request.Password);
        //    if (currentAdmin == null)
        //        return Unauthorized(new ApiResponse<string>("Вы не являетесь администратором"));

        //    var success = await _authService.RegisterAdminAsync(request.Username, request.Password);
        //    if (!success)
        //        return BadRequest(new ApiResponse<string>("Ошибка при регистрации администратора"));

        //    return Ok(new ApiResponse<bool>(success, "Администратор успешно зарегистрирован"));
        //}
    }
}
