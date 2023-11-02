using GoBye.BLL.Dtos.ClassImageDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ClassImageManagers
{
    public interface IClassImageManager
    {
        Task<IEnumerable<ClassImageReadDto>?> GetAllAsync();
        Task<IEnumerable<ClassImageReadDto>?> GetAllByBusClassIdAsync(int id);
        Task<ClassImageReadDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(ClassImageAddDto classImageAddDto);
        Task<bool> DeleteAsync(int id);
    }
}
