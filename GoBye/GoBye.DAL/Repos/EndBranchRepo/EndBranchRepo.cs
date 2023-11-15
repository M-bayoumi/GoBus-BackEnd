using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.EndBranchRepo
{
    public class EndBranchRepo : GenericRepo<EndBranch>, IEndBranchRepo
    {
        private readonly AppDbContext _appDbContext;

        public EndBranchRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<EndBranch>?> GetAllWithDestinationNameAsync()
        {
            return await _appDbContext.EndBranches.Include(x=>x.Destination).ToListAsync();
        }

        public async Task<EndBranch?> GetByIdWithDestinationNameAsync(int id)
        {
            return await _appDbContext.EndBranches.Include(x => x.Destination).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<EndBranch>?> GetAllByDestinationIdAsync(int id)
        {
            return await _appDbContext.EndBranches.Include(x => x.Destination).Where(x => x.DestinationId == id).ToListAsync();
        }
        public async Task<IEnumerable<EndBranch>?> FilterEndBranchesByStartBranchDestinationIdAsync(int id)
        {
            return await _appDbContext.EndBranches.Where(x => x.DestinationId != id).ToListAsync();
        }
    }
}
