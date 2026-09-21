using Microsoft.EntityFrameworkCore;
using UserManagement.Models.RequestModel;

namespace UserManagement.DBManagementFiles
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}