using backend.Models;

namespace backend.Repositories
{
    public interface IUserRepositories
    {
        public Task<bool> Register(User user);
    }
}
