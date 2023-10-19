using backend.Models;

namespace backend.Services
{
    public interface IUserServices
    {
        public Task<UserRsp> Register(UserVM user);
        public Task<User> Login(LoginReq req);
    }
}
