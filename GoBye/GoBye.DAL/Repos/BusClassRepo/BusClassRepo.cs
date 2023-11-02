using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ClassBusRepo
{
    public class BusClassRepo: GenericRepo<BusClass>, IBusClassRepo
    {
        private readonly AppDbContext _appDbContext;

        public BusClassRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<BusClass>?> GetAllWithDetailsAsync()
        {
            return await _appDbContext
                .BusClasses
                .Include(x => x.Buses)
                .Include(x => x.ClassImages)
                .ToListAsync();
        }

        public async Task<BusClass?> GetByIdWithDetailsAsync(int id)
        {
            return await _appDbContext
                .BusClasses
                .Include(x => x.Buses)
                .Include(x => x.ClassImages)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
