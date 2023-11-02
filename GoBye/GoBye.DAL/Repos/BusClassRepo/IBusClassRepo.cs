using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.DAL.Repos.ClassBusRepo
{
    public interface IBusClassRepo:IGenericRepo<BusClass>
    {
        Task<IEnumerable<BusClass>?> GetAllWithDetailsAsync();
        Task<BusClass?> GetByIdWithDetailsAsync(int id);
    }
}
