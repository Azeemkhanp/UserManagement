using Microsoft.EntityFrameworkCore;

namespace UserManagement.DBManagementFiles
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}