using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.DestinationManagers
{
    public interface IDestinationManager
    {
        Task<Response> GetAllAsync();
        Task<Response> GetAllWithBranchesDetailsAsync();
        Task<Response> GetByIdAsync(int id);
        Task<Response> AddAsync(DestinationAddDto destinationAddDto);
        Task<Response> UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
