using GoBye.BLL.Dtos.TripDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.TripManagers
{
    public interface ITripManager
    {
        Task<Response> FilterAllAsync(TripSearchDto tripSearchDto);
        Task<Response> GetAllWithDetailsAsync();
        Task<Response> GetByIdWithBusClassNameAsync(int id);
        Task<Response> AddAsync(TripAddDto tripAddDto);
        Task<Response> UpdateAsync(int id, TripUpdateDto tripUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
