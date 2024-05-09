using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProductsManagement.Domain.Entities;
using System.Reflection;

namespace ProductsManagement.Infrastructure.Data
{
    public class ProductDbContext : IdentityDbContext<IdentityUser>
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AI");
            base.OnModelCreating(builder);

            builder.Entity<Product>().HasKey(p => p.Id);
            builder.Entity<Product>().Property(x => x.Id).ValueGeneratedOnAdd();

            SeedRoles(builder);
            SeedUserAdmin(builder);
            SeedUserUser(builder);
            SeedUserRoles(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private static void SeedUserAdmin(ModelBuilder builder)
        {
            var user = new IdentityUser()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "AdminUser",
                NormalizedUserName= "AdminUser",
                Email = "admin@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");

            builder.Entity<IdentityUser>().HasData(user);
        }

        private void SeedUserUser(ModelBuilder builder)
        {
            var user = new IdentityUser()
            {
                Id = "b74ddd55-6340-4840-95c2-db12554843e5",
                UserName = "ClientUser",
                NormalizedUserName = "ClientUser",
                Email = "user@gmail.com",
                LockoutEnabled = false,
                PhoneNumber = "1234567890"
            };

            var passwordHasher = new PasswordHasher<IdentityUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, "User*123");


            builder.Entity<IdentityUser>().HasData(user);
        }

        private static void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "Client", ConcurrencyStamp = "2", NormalizedName = "Client" }
            );
        }

        private static void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" },
                new IdentityUserRole<string>() { RoleId = "c7b013f0-5201-4317-abd8-c211f91b7330", UserId = "b74ddd55-6340-4840-95c2-db12554843e5" });
        }
    }
}
