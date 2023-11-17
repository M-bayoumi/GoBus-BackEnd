using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.TripRepo
{
    public class TripRepo:GenericRepo<Trip>,ITripRepo
    {
        private readonly AppDbContext _appDbContext;

        public TripRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Trip>?> FilterAllAsync()
        {
            return await _appDbContext
                .Trips

                .Include(x => x.Bus)
                .ThenInclude(y => y.BusClass)

                .Include(x => x.Bus)
                .ThenInclude(y => y.Driver)

                .Include(x => x.StartBranch)

                .Include(x => x.EndBranch)

                .ToListAsync();
        }


        public async Task<Trip?> GetByIdWithBusClassNameAsync(int id)
        {
            return await _appDbContext
                .Trips

                .Include(x => x.Bus)
                .ThenInclude(y => y.BusClass)

                .Include(x => x.StartBranch)

                .Include(x => x.EndBranch)

                .FirstOrDefaultAsync(z => z.Id == id);
        }

        public async Task<IEnumerable<Trip>?> GetAllWithDetailsAsync()
        {
            return await _appDbContext
                .Trips

                .Include(x => x.Bus)
                .ThenInclude(y=>y.BusClass)

                .Include(x=>x.StartBranch)

                .Include(x=>x.EndBranch)

                .Include(x=>x.Reservations)
                .ThenInclude(y => y.User)

                .Include(x => x.Reservations)
                .ThenInclude(y => y.Tickets)

                .ToListAsync();
        }
    }
}
