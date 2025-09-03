using InExTrack.Common;
using InExTrack.DTOs.Requests;
using InExTrack.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace InExTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest_ request)
        {
            var token = await _authService.AuthenticateAsync(request.Username, request.Password);
            if (token == null)
                return Unauthorized();

            return Ok(new ApiResponse<string>(token, "Успешняя авторизация"));
        }

        [HttpPost("register/user")]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterRequest_ request)
        {
            var success = await _authService.RegisterUserAsync(request.Username, request.Password);
            if (!success)
                return BadRequest(new ApiResponse<string>("Пользователь с таким именем уже существует"));

            return Ok(new ApiResponse<bool>(success, "Регистрация успешна"));
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
