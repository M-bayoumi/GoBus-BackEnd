using GoBye.BLL.Dtos.BusDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.BusManagers
{
    public interface IBusManager
    {
        Task<Response> GetAllWithBusClassAsync();
        Task<Response> GetAllByBusClassIdAsync(int id);
        Task<Response> GetAllAvailableBusesAsync();
        Task<Response> GetByIdWithBusClassAsync(int id);
        Task<Response> AddAsync(BusAddDto busAddDto);
        Task<Response> UpdateAsync(int id, BusUpdateDto busUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
