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
        public async Task<Response> GetAllAsync()
        {
            IEnumerable<Term>? terms = await _unitOfWork.TermRepo.GetAllAsync();
            if (terms is not null)
            {
                var data = terms.Select(x => new TermReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    SubTitle = x.SubTitle,
                    Description = x.Description,
                });
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, "There is no Terms");
        }
        #endregion


        #region GetByIdAsync
        public async Task<Response> GetByIdAsync(int id)
        {
            Term? term = await _unitOfWork.TermRepo.GetByIdAsync(id);
            if (term is not null)
            {
                var data = new TermReadDto
                {
                    Id = term.Id,
                    Title = term.Title,
                    SubTitle = term.SubTitle,
                    Description = term.Description,
                };
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, $"Term with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(TermAddDto termAddDto)
        {
            Term term = new Term
            {
                Title = termAddDto.Title,
                SubTitle = termAddDto.SubTitle,
                Description = termAddDto.Description,
            };
            await _unitOfWork.TermRepo.AddAsync(term);
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Term has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add Term");
        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(int id, TermUpdateDto termUpdateDto)
        {
            Term? term = await _unitOfWork.TermRepo.GetByIdAsync(id);
            if (term is not null)
            {
                term.Title = termUpdateDto.Title;
                term.SubTitle = termUpdateDto.SubTitle;
                term.Description = termUpdateDto.Description;
            }
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Term has been updated successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to update Term");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            Term? term = await _unitOfWork.TermRepo.GetByIdAsync(id);
            if (term is not null)
            {
                _unitOfWork.TermRepo.Delete(term);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Term has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete Term");
            }
            return _unitOfWork.Response(false, null, $"Term with id ({id}) is not found");
        }
        #endregion
    }
}
