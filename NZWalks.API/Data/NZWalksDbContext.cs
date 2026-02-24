using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext: DbContext
    {
        public NZWalksDbContext (DbContextOptions dbContextOptions): base(dbContextOptions)
        {

        }


        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<RegionDto> RegionsDto { get; set; }
    }
}
