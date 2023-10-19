using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace backend.DB
{
    public class DataContext: DbContext
    {
        private readonly IConfiguration _configuration;
        public DataContext(IConfiguration configuration, DbContextOptions<DataContext> options) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<User> Users => Set<User>();
    }
}
