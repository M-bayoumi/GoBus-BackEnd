using GoBye.BLL.Dtos.StartBranchDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.StartBranchManagers
{
    public interface IStartBranchManager
    {
        Task<IEnumerable<StartBranchWithDestinationNameDto>?> GetAllWithDestinationNameAsync();
        Task<IEnumerable<StartBranchReadDto>?> GetAllByDestinationIdAsync(int id);
        Task<StartBranchReadDto?> GetByIdWithDestinationNameAsync(int id);
        Task<bool> AddAsync(StartBranchAddDto startBranchAddDto);
        Task<bool> UpdateAsync(int id, StartBranchUpdateDto startBranchUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
