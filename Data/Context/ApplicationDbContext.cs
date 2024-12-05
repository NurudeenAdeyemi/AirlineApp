using AirlineApp.Data.Authentication;
using AirlineApp.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace AirlineApp.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            // seeds
            //users
            var user = new User
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "8999999",
            };

            //Roles
            var admin = new IdentityRole
            {
                Id = "9d1b777e-2c20-444e-ad26-6a77b1caec51",
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var employee = new IdentityRole
            {
                Id = "49f188a4-8196-419b-80cc-31091d58ccda",
                Name = "employee",
                NormalizedName = "EMPLOYEE"
            };

            var client = new IdentityRole
            {
                Id = "05eaefd4-f2ae-4ba9-92d3-c98e69b0273c",
                Name = "customer",
                NormalizedName = "CUSTOMER"
            };

            var userRole = new IdentityUserRole<string>
            {
                UserId = user.Id,
                RoleId = admin.Id,
            };

            builder.Entity<IdentityRole>().HasData(admin, employee, client);
            builder.Entity<User>().HasData(user);

            base.OnModelCreating(builder);
        }
    }
}
