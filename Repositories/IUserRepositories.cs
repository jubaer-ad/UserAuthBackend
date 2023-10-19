using backend.Models;

namespace backend.Repositories
{
    public interface IUserRepositories
    {
        public Task<int> Register(User user);
        public Task<User> Login(LoginReq req);
    }
}
