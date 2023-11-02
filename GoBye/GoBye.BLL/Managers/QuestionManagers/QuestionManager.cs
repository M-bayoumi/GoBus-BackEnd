using GoBye.BLL.Dtos.PolicyDtos;
using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.QuestionRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.QuestionManagers
{
    public class QuestionManager: IQuestionManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllAsync
        public async Task<IEnumerable<QuestionReadDto>?> GetAllAsync()
        {
            IEnumerable<Question>? questions = await _unitOfWork.QuestionRepo.GetAllAsync();

            if (questions is not null)
            {
                return questions.Select(x => new QuestionReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Answer = x.Answer
                });
            }
            return null;
        }
        #endregion


        #region GetByIdAsync
        public async Task<QuestionReadDto?> GetByIdAsync(int id)
        {
            Question? question = await _unitOfWork.QuestionRepo.GetByIdAsync(id);

            if (question is not null)
            {
                QuestionReadDto questionReadDto = new QuestionReadDto
                {
                    Id = question.Id,
                    Title = question.Title,
                    Answer = question.Answer
                };
                return questionReadDto;
            }
            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(QuestionAddDto questionAddDto)
        {
            Question question = new Question
            {
                Title = questionAddDto.Title,
                Answer = questionAddDto.Answer
            };
            await _unitOfWork.QuestionRepo.AddAsync(question);

            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, QuestionUpdateDto questionUpdateDto)
        {
            Question? question = await _unitOfWork.QuestionRepo.GetByIdAsync(id);
            if (question is not null)
            {
                question.Title = questionUpdateDto.Title;
                question.Answer = questionUpdateDto.Answer;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Question? question = await _unitOfWork.QuestionRepo.GetByIdAsync(id);

            if (question is not null)
            {
                _unitOfWork.QuestionRepo.Delete(question);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
