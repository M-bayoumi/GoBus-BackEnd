using GoBye.BLL.Dtos.StartBranchDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.StartBranchManagers
{
    public interface IStartBranchManager
    {
        Task<Response> GetAllWithDestinationNameAsync();
        Task<Response> GetAllByDestinationIdAsync(int id);
        Task<Response> FilterStartBranchesByEndBranchDestinationIdAsync(int id);
        Task<Response> GetByIdAsync(int id);
        Task<Response> AddAsync(StartBranchAddDto startBranchAddDto);
        Task<Response> UpdateAsync(int id, StartBranchUpdateDto startBranchUpdateDto);
        Task<Response> DeleteAsync(int id);


    }
}
