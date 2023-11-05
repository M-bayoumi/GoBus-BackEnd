using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.StartBranchRepo
{
    public class StartBranchRepo:GenericRepo<StartBranch>,IStartBranchRepo
    {
        private readonly AppDbContext _appDbContext;

        public StartBranchRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<StartBranch>?> GetAllWithDestinationNameAsync()
        {
            return await _appDbContext.StartBranches.Include(x => x.Destination).ToListAsync();
        }

        public async Task<StartBranch?> GetByIdWithDestinationNameAsync(int id)
        {
            return await _appDbContext.StartBranches.Include(x => x.Destination).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<StartBranch>?> GetAllByDestinationIdAsync(int id)
        {
            return await _appDbContext.StartBranches.Where(x => x.DestinationId == id).ToListAsync();
        }

        public async Task<IEnumerable<StartBranch>?> FilterStartBranchesByEndBranchDestinationIdAsync(int id)
        {
            return await _appDbContext.StartBranches.Where(x => x.DestinationId != id).ToListAsync();
        }
    }
}
