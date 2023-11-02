using GoBye.BLL.Dtos.QuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.QuestionManagers
{
    public interface IQuestionManager
    {
        Task<IEnumerable<QuestionReadDto>?> GetAllAsync();
        Task<QuestionReadDto?> GetByIdAsync(int id);
        Task<bool> AddAsync(QuestionAddDto questionAddDto);
        Task<bool> UpdateAsync(int id, QuestionUpdateDto questionUpdateDto);
        Task<bool> DeleteAsync(int id);
    }
}
