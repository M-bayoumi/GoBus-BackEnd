using GoBye.BLL.Dtos.PolicyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.PolicyManager
{
    public interface IPolicyManager
    {
        Task<IEnumerable<PolicyReadDto>?> GetAllAsync();
        Task<PolicyReadDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(PolicyAddDto policyAddDto);
        Task<bool> UpdateAsync(int id, PolicyUpdateDto policyUpdateDto);
        Task<bool> DeleteAsync(int id);

    }
}
