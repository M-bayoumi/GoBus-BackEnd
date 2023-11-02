using GoBye.BLL.Dtos.TripDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.TripManagers
{
    public interface ITripManager
    {
        Task<IEnumerable<TripReadDto>?> FilterAllAsync(TripSearchDto tripSearchDto);
        Task<IEnumerable<TripDetailsDto>?> GetAllWithDetailsAsync();
        Task<TripUserDto?> GetByIdWithBusClassNameAsync(int id);
        Task<bool> AddAsync(TripAddDto tripAddDto);
        Task<bool> UpdateAsync(int id, TripUpdateDto tripUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
