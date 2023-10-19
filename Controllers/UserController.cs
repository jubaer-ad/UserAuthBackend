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
                APIRsp aPIRsp = new();
                var user = await _userServices.Register(model);
                if (user is not null && user.Name is not null)
                {
                    aPIRsp = new APIRsp()
                    {
                        IsSuccess = true,
                        Message = "User Created",
                        StatusCode = 201,
                        Data = new UserRsp()
                        {
                            Name = user.Name,
                            Email = user.Email,
                            MobileNumber = user.MobileNumber,
                        }
                    };
                    return Ok(aPIRsp);
                }
                if (!(user is not null && user.Name is not null))
                {
                    aPIRsp = new APIRsp()
                    {
                        IsSuccess = false,
                        Message = "User already exists",
                        StatusCode = 403
                    };
                    return Ok(aPIRsp);
                }
                aPIRsp = new APIRsp()
                {
                    IsSuccess = false,
                    Message = "Something went wrong",
                    StatusCode = 400
                };
                return Ok(aPIRsp);
            }
            catch (Exception ex)
            {
                var aPIRsp = new APIRsp()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 400
                };
                return Ok(aPIRsp);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginReq model)
        {
            try
            {
                APIRsp aPIRsp = new();
                var user = await _userServices.Login(model);
                if (user == null)
                {
                    aPIRsp = new APIRsp()
                    {
                        IsSuccess = false,
                        Message = "User not found",
                        StatusCode = 404,
                    };
                    return Ok(aPIRsp);
                }

                var res = Helper.Helper.VerifyHash(model.Password, user.HashedPassword, user.HashedSalt);
                if (!res)
                {
                    aPIRsp = new APIRsp()
                    {
                        IsSuccess = false,
                        Message = "Wrong Password",
                        StatusCode = 401,
                    };
                    return Ok(aPIRsp);
                }
                aPIRsp = new APIRsp()
                {
                    IsSuccess = true,
                    Message = "Login Success",
                    StatusCode = 200,
                    Data = new UserRsp()
                    {
                        Name = user.Name,
                        Email = user.Email,
                        MobileNumber = user.MobileNumber,
                    }
                };
                return Ok(aPIRsp);
            }
            catch (Exception ex)
            {
                var aPIRsp = new APIRsp()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                    StatusCode = 400
                };
                return Ok(aPIRsp);
            }
        }
    }
}
