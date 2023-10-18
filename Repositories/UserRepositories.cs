using backend.Models;

namespace backend.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        public Task<bool> Register(User user)
        {
			try
			{
				return false;
			}
			catch (Exception)
			{

				throw;
			}
        }
    }
}
