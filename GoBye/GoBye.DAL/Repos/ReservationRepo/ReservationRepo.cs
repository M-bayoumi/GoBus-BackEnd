using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ReservationRepo
{
    public class ReservationRepo:GenericRepo<Reservation>, IReservationRepo
    {
        private readonly AppDbContext _appDbContext;

        public ReservationRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Reservation>?> GetAllWithTripDetailsAsync()
        {
            return await _appDbContext
                .Reservations

                .Include(x=>x.User)

                .Include(x=>x.Tickets)

                .Include(x=>x.Trip)
                .ThenInclude(y=>y.StartBranch)

                .Include(x => x.Trip)
                .ThenInclude(y => y.EndBranch)

                .Include(x=>x.Trip)
                .ThenInclude(y=>y.Bus)
                .ThenInclude(z=>z.BusClass)

                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>?> GetAllWithTripDetailsByUserIdAsync(string id)
        {
            return await _appDbContext.
                 Reservations

                .Include(x => x.User)

                .Include(x => x.Tickets)

                .Include(x => x.Trip)
                .ThenInclude(y => y.StartBranch)

                .Include(x => x.Trip)
                .ThenInclude(y => y.EndBranch)

                .Include(x => x.Trip)
                .ThenInclude(y => y.Bus)
                .ThenInclude(z => z.BusClass)

                .Where(x => x.UserId == id)

                .ToListAsync();
        }

        public async Task<IEnumerable<Reservation>?> GetAllByTripIdAsync(int id)
        {
            return await _appDbContext
                .Reservations

                .Include(x => x.User)

                .Include(y=>y.Trip)

                .Include(y=>y.Tickets)

                .Where(x => x.TripId == id)

                .ToListAsync();
        }

        public async Task<Reservation?> GetByIdWithTripDetailsAsync(int id)
        {
            return await _appDbContext
                .Reservations

                .Include(x => x.User)

                .Include(x => x.Tickets)

                .Include(x => x.Trip)
                .ThenInclude(y => y.StartBranch)

                .Include(x => x.Trip)
                .ThenInclude(y => y.EndBranch)

                .Include(x => x.Trip)
                .ThenInclude(y => y.Bus)
                .ThenInclude(z => z.BusClass)

                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
