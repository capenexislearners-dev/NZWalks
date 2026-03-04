using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext context;

        public SQLRegionRepository(NZWalksDbContext _context)
        {
            context = _context;
        }

        async Task<Region> IRegionRepository.CreateAsync(Region region)
        {
            await context.Regions.AddAsync(region);
            await context.SaveChangesAsync();
            return region;
        }

        async Task<Region> IRegionRepository.DeleteAsync(Guid Id)
        {
            var existingRegion = await context.Regions.FirstOrDefaultAsync(x => x.Id == Id);
            if (existingRegion == null)
            {
                return null;
                
            }
           context.Regions.Remove(existingRegion);
            await context.SaveChangesAsync();
            return existingRegion;
        }

        async Task<List<Region>> IRegionRepository.GetAllAsync()
        {
            return await context.Regions.ToListAsync();
        }

        async Task<Region?> IRegionRepository.GetByIdAsync(Guid Id)
        {
            return await context.Regions.FirstOrDefaultAsync(x=> x.Id == Id);
        }

        async Task<Region?> IRegionRepository.UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await context.Regions.FirstOrDefaultAsync(x => x.Id == id);

            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await context.SaveChangesAsync();
            return existingRegion;
        }
    }
}
