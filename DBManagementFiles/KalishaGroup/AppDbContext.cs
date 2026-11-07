using Microsoft.EntityFrameworkCore;
using UserManagement.Models.KalishaGroup.RequestModel;

namespace UserManagement.DBManagementFiles.KalishaGroup
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
    }
}