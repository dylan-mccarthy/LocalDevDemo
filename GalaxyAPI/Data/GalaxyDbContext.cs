using GalaxyAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace GalaxyAPI.Data
{
    public class GalaxyDbContext : DbContext
    {
        public GalaxyDbContext(DbContextOptions<GalaxyDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Galaxy> Galaxies { get; set; }
        
    }
}
