using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.DestinationRepo
{
    public class DestinationRepo: GenericRepo<Destination>,IDestinationRepo
    {
        private readonly AppDbContext _appDbContext;

        public DestinationRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Destination>?> GetAllWithBranchesDetailsAsync()
        {
            return await
                _appDbContext
                .Destinations
                .Include(x => x.EndBranchs)
                .ToListAsync();
        }
    }
}
