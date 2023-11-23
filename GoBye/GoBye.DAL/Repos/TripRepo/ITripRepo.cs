using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.TripRepo
{
    public interface ITripRepo:IGenericRepo<Trip>
    {
        Task<IEnumerable<Trip>?> SearchAsync();
        Task<Trip?> GetByIdWithBusClassNameAsync(int id);
        Task<IEnumerable<Trip>?> GetAllWithDetailsAsync();
    }
}
