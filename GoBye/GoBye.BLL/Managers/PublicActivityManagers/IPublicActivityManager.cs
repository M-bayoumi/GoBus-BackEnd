using GoBye.BLL.Dtos.PublicActivityDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.PublicActivityManagers
{
    public interface IPublicActivityManager
    {
        Task<IEnumerable<PublicActivityReadDto>?> GetAllAsync();
        Task<IEnumerable<PublicActivityReadDto>?> GetAllByDestinationIdAsync(int id);
        Task<PublicActivityReadDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(PublicActivityAddDto publicActivityAddDto);
        Task<bool> UpdateAsync(int id, PublicActivityUpdateDto publicActivityUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
