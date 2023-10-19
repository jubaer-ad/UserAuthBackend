using backend.Models;
using backend.Repositories;

namespace backend.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositories _userRepositories;
        public UserServices(IUserRepositories userRepositories)
        {
            _userRepositories = userRepositories;
        }

        public async Task<User> Login(LoginReq req)
        {
            try
            {
                return await _userRepositories.Login(req);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> Register(UserVM model)
        {

            try
            {
                Helper.Helper.CreateHash(model.Password, out byte[] passwordHash, out byte[] hashedSalt);
                User user = new()
                {
                    Email = model.Email,
                    Name = model.Name,
                    MobileNumber = model.MobileNumber,
                    HashedPassword = passwordHash,
                    HashedSalt = hashedSalt
                };
                return await _userRepositories.Register(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
