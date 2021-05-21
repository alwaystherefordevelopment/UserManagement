using Microsoft.EntityFrameworkCore;
using UserManagementDAL;

namespace UserManagementRepository
{
    public class AppDbContext :DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"data source = .; initial catalog = UserManagement; persist security info = true; " +
                    "user id=sa; password=password;App=EntityFramework");
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
