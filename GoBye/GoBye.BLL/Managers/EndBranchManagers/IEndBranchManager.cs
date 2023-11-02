using GoBye.BLL.Dtos.EndBranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.EndBranchManagers
{
    public interface IEndBranchManager
    {
        Task<IEnumerable<EndBranchWithDestinationNameDto>?> GetAllWithDestinationNameAsync();
        Task<IEnumerable<EndBranchReadDto>?> GetAllByDestinationIdAsync(int id);
        Task<EndBranchReadDto?> GetByIdWithDestinationNameAsync(int id);
        Task<bool> AddAsync(EndBranchAddDto endBranchAddDto);
        Task<bool> UpdateAsync(int id, EndBranchUpdateDto endBranchUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
