using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Operations_PostGresSQl.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "39537238-893b-4ad1-87f3-d2876cbfb71c";
            var managerRoleId = "24dbfaf0-de0a-4163-9d56-847830ab2e52";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = managerRoleId,
                    ConcurrencyStamp= managerRoleId,
                    Name = "Manager",
                    NormalizedName = "Manager".ToUpper()
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

        }
    }
}
