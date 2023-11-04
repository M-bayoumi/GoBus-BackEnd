using GoBye.BLL.Dtos.TermDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.TermManagers
{
    public interface ITermManager
    {
        Task<Response> GetAllAsync();
        Task<Response> GetByIdAsync(int id);
        Task<Response> AddAsync(TermAddDto termAddDto);
        Task<Response> UpdateAsync(int id, TermUpdateDto termUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
