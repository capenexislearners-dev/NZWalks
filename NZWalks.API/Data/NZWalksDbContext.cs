using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTOs;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }


        public DbSet<Difficulty> difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<RegionDto> RegionsDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var difficulties = new List<Difficulty>()
                {
                new Difficulty()
                {
                    Id = Guid.Parse("9225d853-e28b-4f41-ae85-82cd1e98b14d"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("6bc3806b-51f5-4da7-8627-23d30d35c1a7"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("aeedf08d-0179-4ed4-b3d3-9f3c810b083c"),
                    Name = "Hard"
                }
            };
            //Seed difficulties to the DB
            modelBuilder.Entity<Difficulty>().HasData(difficulties);


            //Seed data for regions
            var regions = new List<Region>
            {
                new Region
                {
                 Id = Guid.Parse("ad5c6265-8548-4401-bb0e-cea68c54c4d9"),
                 Name = "Aukland",
                 Code = "AKL",
                 RegionImageUrl = "https://images.pexels.com/photos/5327300/pexels-photo-5327300.jpeg"
                },
                new Region
                {
                 Id = Guid.Parse("6df8f84e-dfa6-4802-95ef-ea4cce50f782"),
                 Name = "Makotopong",
                 Code = "MKP",
                 RegionImageUrl = "https://images.pexels.com/photos/163037/london-street-phone-cabin-163037.jpeg"
                },
                new Region
                {
                 Id = Guid.Parse("bcef4a09-cc5a-4e64-bee1-b405ea8e4114"),
                 Name = "Turfloop",
                 Code = "TFP",
                 RegionImageUrl = "https://images.pexels.com/photos/976873/pexels-photo-976873.jpeg"
                },
                new Region
                {
                 Id = Guid.Parse("8fc1c0d7-21b9-4c7f-8f02-25d5f3573423"),
                 Name = "Nobody",
                 Code = "NBD",
                 RegionImageUrl = null
                },
                new Region
                {
                 Id = Guid.Parse("57e92cf3-3f98-4911-a58e-092d3a306ab3"),
                 Name = "MarkTown",
                 Code = "MKT",
                 RegionImageUrl = "https://images.pexels.com/photos/6007607/pexels-photo-6007607.jpeg"
                }
            };
        }
    }
}
