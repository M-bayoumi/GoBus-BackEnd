using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.QuestionManagers
{
    public interface IQuestionManager
    {
        Task<Response> GetAllAsync();
        Task<Response> GetByIdAsync(int id);
        Task<Response> AddAsync(QuestionAddDto questionAddDto);
        Task<Response> UpdateAsync(int id, QuestionUpdateDto questionUpdateDto);
        Task<Response> DeleteAsync(int id);
    }
}
