using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.TicketRepo
{
    public interface ITicketRepo:IGenericRepo<Ticket>
    {
        Task<IEnumerable<Ticket>?> GetAllWithReservationNumberAsync();
        Task<IEnumerable<Ticket>?> GetAllByReservationIdAsync(int id);
        Task<IEnumerable<Ticket>?> GetAllByTripIdAsync(int id);
        Task<Ticket?> GetByIdWithReservationNumberAsync(int id);
    }
}
