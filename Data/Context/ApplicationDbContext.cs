using AirlineApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirlineApp.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Location> Locations { get; set; }
    }
}
