using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.PublicActivityRepo
{
    public class PublicActivityRepo:GenericRepo<PublicActivity>,IPublicActivityRepo
    {
        private readonly AppDbContext _appDbContext;

        public PublicActivityRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<PublicActivity>?> GetAllWithDestinationNameAsync()
        {
            return await _appDbContext.PublicActivities.Include(x => x.Destination).ToListAsync();
        }

        public async Task<IEnumerable<PublicActivity>?> GetAllByDestinationIdAsync(int id)
        {
            return await _appDbContext.PublicActivities.Include(x=>x.Destination).Where(x=>x.DestinationID == id).ToListAsync();
        }
    }
}
