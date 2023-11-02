using GoBye.BLL.Dtos.StartBranchDtos;
using GoBye.BLL.Dtos.TermDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.TermManagers
{
    public class TermManager:ITermManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public TermManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllAsync
        public async Task<IEnumerable<TermReadDto>?> GetAllAsync()
        {
            IEnumerable<Term>? terms = await _unitOfWork.TermRepo.GetAllAsync();
            if (terms is not null)
            {
                return terms.Select(x => new TermReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    Description = x.Description,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdAsync
        public async Task<TermReadDto?> GetByIdAsync(int id)
        {
            Term? term = await _unitOfWork.TermRepo.GetByIdAsync(id);
            if (term is not null)
            {
                TermReadDto termReadDto = new TermReadDto
                {
                    Id = term.Id,
                    Title = term.Title,
                    SubTitle = term.SubTitle,
                    Description = term.Description,
                };
                return termReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(TermAddDto termAddDto)
        {
            Term term = new Term
            {
                Title = termAddDto.Title,
                SubTitle = termAddDto.SubTitle,
                Description = termAddDto.Description,
            };
            await _unitOfWork.TermRepo.AddAsync(term);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, TermUpdateDto termUpdateDto)
        {
            Term? term = await _unitOfWork.TermRepo.GetByIdAsync(id);
            if (term is not null)
            {
                term.Title = termUpdateDto.Title;
                term.SubTitle = termUpdateDto.SubTitle;
                term.Description = termUpdateDto.Description;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            Term? term = await _unitOfWork.TermRepo.GetByIdAsync(id);
            if (term is not null)
            {
                _unitOfWork.TermRepo.Delete(term);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
