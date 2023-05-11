using Microsoft.EntityFrameworkCore;

namespace SampleTwitterAPI.Models
{
    public class SampleTwitterContext : DbContext
    {
        public SampleTwitterContext(DbContextOptions<SampleTwitterContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profile { get; set; } = null!;
        public DbSet<Tweet> Tweet { get; set; } = null!;
    }
}
