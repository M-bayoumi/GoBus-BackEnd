using GoBye.BLL.Dtos.DestinationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.DestinationManagers
{
    public interface IDestinationManager
    {
        Task<IEnumerable<DestinationReadDto>?> GetAllAsync();
        Task<DestinationReadDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(DestinationAddDto destinationAddDto);
        Task<bool> UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
