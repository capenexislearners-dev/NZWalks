using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext context;

        public SQLWalkRepository(NZWalksDbContext _context) 
        {
            this.context = _context;
        }


        public async Task<Walk> CreateAsync(Walk walk)
        {
           await context.Walks.AddAsync(walk);
            await context.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalk == null)
            {
                return null;
            }
            context.Walks.Remove(existingWalk);
            await context.SaveChangesAsync();
            return existingWalk;



        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = null, bool isAscending = true)
        {
            var Walks = context.Walks.Include("Difficulty").Include("Region").AsQueryable();
            //filtering 
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    Walks = Walks.Where(x => x.Name.Contains(filterQuery));
                }

            }

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    Walks = isAscending ? Walks.OrderBy(x => x.Name): Walks.OrderByDescending(x => x.Name);
                }
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase))
                {
                    Walks = isAscending ? Walks.OrderBy(x => x.lengthInkm) : Walks.OrderByDescending(x => x.lengthInkm);
                }
            }

            return await Walks.ToListAsync();
            //return await context.Walks.Include("Difficulty").Include("Region").ToListAsync();
        }
           
        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await context.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await context.Walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.lengthInkm = walk.lengthInkm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await context.SaveChangesAsync();

            return existingWalk;



        }
    }
}
