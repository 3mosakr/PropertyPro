using Microsoft.AspNetCore.Mvc;
using PropertyPro.Api.Base;
using PropertyPro.Service.Abstract;
using PropertyPro.Service.Dto.Auth;
using PropertyPro.Service.Implementation;

namespace PropertyPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : AppControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            var response = await _authService.RegisterAsync(registerDto);
            return NewResult(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _authService.LoginAsync(loginDto);
            return NewResult(response);
        }

        [HttpPost("logout")]
        public Task<IActionResult> Logout()
        {
            throw new System.NotImplementedException();
        }

        //[HttpPost("refresh")]
        //public Task<IActionResult> Refresh()
        //{
        //    throw new System.NotImplementedException();
        //}

        //[HttpPost("forgot-password")]
        //public Task<IActionResult> ForgotPassword()
        //{
        //    throw new System.NotImplementedException();
        //}

        //[HttpPost("reset-password")]
        //public Task<IActionResult> ResetPassword()
        //{
        //    throw new System.NotImplementedException();
        //}

        //[HttpPost("change-password")]
        //public Task<IActionResult> ChangePassword()
        //{
        //    throw new System.NotImplementedException();
        //}



    }
}
