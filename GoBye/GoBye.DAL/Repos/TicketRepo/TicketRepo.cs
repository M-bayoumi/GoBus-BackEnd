using GoBye.DAL.Data.Context;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.TicketRepo
{
    public class TicketRepo:GenericRepo<Ticket>,ITicketRepo
    {
        private readonly AppDbContext _appDbContext;

        public TicketRepo(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<IEnumerable<Ticket>?> GetAllWithReservationNumberAsync()
        {
            return await _appDbContext
                .Tickets
                .Include(x => x.Reservation)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>?> GetAllByReservationIdAsync(int id)
        {
            return await _appDbContext
                .Tickets
                .Include(x => x.Reservation)
                .Where(y=>y.ReservationId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>?> GetAllByTripIdAsync(int id)
        {
            return await _appDbContext
                .Tickets
                .Include(x => x.Reservation)
                .ThenInclude(x => x.Trip)
                .Where(y => y.Reservation.TripId == id)
                .ToListAsync();
        }

        public async Task<Ticket?> GetByIdWithReservationNumberAsync(int id)
        {
            return await _appDbContext
                .Tickets
                .Include(x => x.Reservation)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
