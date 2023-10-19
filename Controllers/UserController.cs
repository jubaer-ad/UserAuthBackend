using backend.Models;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserVM model)
        {
            try
            {
                var res = await _userServices.Register(model);
                if (res == 1)
                {
                    return Ok("User Created");
                }
                if (res == 2)
                {
                    return BadRequest("User already exists");
                }
                return BadRequest("Something went wrong");
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginReq model)
        {
            try
            {
                var user = await _userServices.Login(model);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                var res = Helper.Helper.VerifyHash(model.Password, user.HashedPassword, user.HashedSalt);
                if (!res)
                {
                    return BadRequest("Wrong Password");
                }
                return Ok("Login Success");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
