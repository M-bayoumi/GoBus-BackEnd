using GoBye.BLL.Dtos.BusDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.BusManagers
{
    public interface IBusManager
    {
        Task<IEnumerable<BusReadDto>?> GetAllWithBusClassAsync();
        Task<IEnumerable<BusReadDto>?> GetAllByBusClassIdAsync(int id);
        Task<IEnumerable<BusAvailableDto>?> GetAllAvailableBusesAsync();
        Task<BusReadDto?> GetByIdWithBusClassAsync(int id);
        Task<bool> AddAsync(BusAddDto busAddDto);
        Task<bool> UpdateAsync(int id, BusUpdateDto busUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
