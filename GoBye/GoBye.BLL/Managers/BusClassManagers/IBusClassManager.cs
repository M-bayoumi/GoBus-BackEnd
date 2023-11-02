using GoBye.BLL.Dtos;
using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.BusClassManagers
{
    public interface IBusClassManager
    {
        Task<Response> GetAllAsync();
        Task<Response> GetAllWithDetailsAsync();
        Task<Response> GetByIdAsync(int id);
        Task<Response> GetByIdWithDetailsAsync(int id);
        Task<Response> AddAsync(BusClassAddDto busClassAddDto);
        Task<Response> UpdateAsync(int id, BusClassUpdateDto busClassUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
