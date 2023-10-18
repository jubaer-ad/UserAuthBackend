using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(UserVm model)
        {
            try
            {
                var userData = await _userService.GetAnyUserByEmailAsync(model.Email ?? "");
                if (userData == null)
                {
                    User User = new()
                    {
                        Email = model.Email,
                        Mobile = model.Mobile,
                        Password = Cryptographer.Encrypt(model.Password),
                        FullName = model.FullName,
                        RoleId = model.RoleId,
                        CreatedBy = 0,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        ModifiedBy = 0,
                        IsActive = true,
                        IsRemoved = false,
                        IsLocked = false
                    };
                    var data = await _userService.AddAsync(User);
                    return Ok(data);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
