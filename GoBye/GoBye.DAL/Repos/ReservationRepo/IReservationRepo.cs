using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ReservationRepo
{
    public interface IReservationRepo:IGenericRepo<Reservation>
    {
        Task<IEnumerable<Reservation>?> GetAllWithTripDetailsAsync();
        Task<IEnumerable<Reservation>?> GetAllByTripIdAsync(int id);
        Task<IEnumerable<Reservation>?> GetAllWithTripDetailsByUserIdAsync(string id);
        Task<Reservation?> GetByIdWithTripDetailsAsync(int id);
    }
}
