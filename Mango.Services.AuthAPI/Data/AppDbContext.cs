

using Mango.Services.AuthAPI.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.AuthAPI.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            const string ADMIN_ID = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
            const string ADMIN_ROLE_ID = "ad376a8f-9eab-4bb9-9fca-30b01540f445";

            const string CUSTOMER_ROLE_ID = "bd376a8f-9eab-4bb9-9fca-30b01540f445";
            const string CUSTOMER_ID = "b18be9c0-aa65-4af8-bd17-00bd9344e575";
            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = "ADMIN",
                NormalizedName = "ADMIN",
            });

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = CUSTOMER_ROLE_ID,
                Name = "CUSTOMER",
                NormalizedName = "CUSTOMER",
            });

            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = ADMIN_ID,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Admin123.#"),
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = "Admin",
                LockoutEnabled = true
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID
            });

            builder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = CUSTOMER_ID,
                UserName = "customer",
                NormalizedUserName = "customer",
                Email = "customer@gmail.com",
                NormalizedEmail = "customer@gmail.com",
                EmailConfirmed = false,
                PasswordHash = hasher.HashPassword(null, "Customer123.#"),
                SecurityStamp = Guid.NewGuid().ToString(),
                Name = "Customer",
                LockoutEnabled = true
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = CUSTOMER_ROLE_ID,
                UserId = CUSTOMER_ID
            });
        }
    }

}
