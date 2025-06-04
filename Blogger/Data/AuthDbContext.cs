using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "f9b16c62-86a2-4ae2-98b4-35a0b82440a1";
            var adminUserId = "e32588d5-84d5-4423-940a-77f8b23edb8b";


            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            var adminUser = new IdentityUser
            {
                Id = adminUserId,
                UserName = "admin@bloggie.com",
                Email = "admin@bloggie.com",
                NormalizedEmail = "ADMIN@BLOGGIE.COM",
                NormalizedUserName = "ADMIN@BLOGGIE.COM",
                EmailConfirmed = true,
                SecurityStamp = "cfeb3e90-a12e-4e5d-9c7e-2c1a3f63db4b",
                ConcurrencyStamp = "2282952a-293c-4e7c-b9e0-8e95ec15ead2", 
                PasswordHash = "AQAAAAIAAYagAAAAEEU7vxejBzfSgXs35j54Ik2Fxhs1oyqryrY0sfpGTUiPHVWzxcZw2vg4X4DuTF6AdQ=="
            };


            adminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(adminUser, "admin123");

            builder.Entity<IdentityUser>().HasData(adminUser);

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminUserId,
                RoleId = adminRoleId
            });
        }

    }
}
