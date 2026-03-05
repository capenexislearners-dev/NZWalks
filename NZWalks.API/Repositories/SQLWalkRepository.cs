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
    }
}
