using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using PlanetAPI.Models;

namespace PlanetAPI.Data
{
    public class PlanetDbContext : DbContext
    {
        public PlanetDbContext(DbContextOptions<PlanetDbContext> options)
            : base(options)
        {
        }

        public DbSet<Planet> Planets { get; set; }
    }
}
