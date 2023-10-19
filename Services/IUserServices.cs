using backend.Models;

namespace backend.Services
{
    public interface IUserServices
    {
        public Task<int> Register(UserVM user);
        public Task<User> Login(LoginReq req);
    }
}
