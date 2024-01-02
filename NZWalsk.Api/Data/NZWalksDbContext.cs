using Microsoft.EntityFrameworkCore;
using NZWalsk.Api.Models.Domain;

namespace NZWalsk.Api.Data
{
    public class NZWalksDbContext:  DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) 
        {
                
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Walk> Walks { get; set; }
    }
}
