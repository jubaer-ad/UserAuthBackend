using backend.DB;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly DataContext _dbContext;
        public UserRepositories(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> Login(LoginReq req)
        {
            try
            {
                return _dbContext.Set<User>().FirstOrDefault(x => x.Email == req.Email);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> Register(User user)
        {
			try
			{
                var res = _dbContext.Set<User>().Any(x => x.Email == user.Email);
                if (res)
                {
                    return Task.FromResult(2);
                }


                _dbContext.Set<User>().Add(user);
                _dbContext.SaveChanges();
                return Task.FromResult(1);

            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
