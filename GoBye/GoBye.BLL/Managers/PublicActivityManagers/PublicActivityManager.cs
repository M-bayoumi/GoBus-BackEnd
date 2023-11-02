using GoBye.BLL.Dtos.PolicyDtos;
using GoBye.BLL.Dtos.PublicActivityDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.PublicActivityManagers
{
    public class PublicActivityManager:IPublicActivityManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public PublicActivityManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllAsync
        public async Task<IEnumerable<PublicActivityReadDto>?> GetAllAsync()
        {
            IEnumerable<PublicActivity>? publicActivities = await _unitOfWork.PublicActivityRepo.GetAllAsync();
            if (publicActivities is not null)
            {
                return publicActivities.Select(x => new PublicActivityReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageURL = x.ImageURL,
                    Description = x.Description,
                });
            }

            return null;
        }
        #endregion


        #region GetAllByDestinationIdAsync
        public async Task<IEnumerable<PublicActivityReadDto>?> GetAllByDestinationIdAsync(int id)
        {
            IEnumerable<PublicActivity>? publicActivities = await _unitOfWork.PublicActivityRepo.GetAllByDestinationIdAsync(id);
            if (publicActivities is not null)
            {
                return publicActivities.Select(x => new PublicActivityReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageURL = x.ImageURL,
                    Description = x.Description,
                });
            }

            return null;
        }
        #endregion


        #region GetByIdAsync
        public async Task<PublicActivityReadDto?> GetByIdAsync(int id)
        {
            PublicActivity? publicActivity = await _unitOfWork.PublicActivityRepo.GetByIdAsync(id);
            if (publicActivity is not null)
            {
                PublicActivityReadDto publicActivityReadDto = new PublicActivityReadDto
                {
                    Id = publicActivity.Id,
                    Title = publicActivity.Title,
                    ImageURL = publicActivity.ImageURL,
                    Description = publicActivity.Description,
                };
                return publicActivityReadDto;
            }

            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(PublicActivityAddDto publicActivityAddDto)
        {
            PublicActivity publicActivity = new PublicActivity
            {
                Title = publicActivityAddDto.Title,
                ImageURL = publicActivityAddDto.ImageURL,
                Description = publicActivityAddDto.Description,
                DestinationID = publicActivityAddDto.DestinationID,
            };
            await _unitOfWork.PublicActivityRepo.AddAsync(publicActivity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region UpdateAsync
        public async Task<bool> UpdateAsync(int id, PublicActivityUpdateDto publicActivityUpdateDto)
        {
            PublicActivity? publicActivity = await _unitOfWork.PublicActivityRepo.GetByIdAsync(id);
            if (publicActivity is not null)
            {
                publicActivity.Title = publicActivityUpdateDto.Title;
                publicActivity.ImageURL = publicActivityUpdateDto.ImageURL;
                publicActivity.Description = publicActivityUpdateDto.Description;
                publicActivity.DestinationID = publicActivityUpdateDto.DestinationID;
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            PublicActivity? publicActivity = await _unitOfWork.PublicActivityRepo.GetByIdAsync(id);
            if (publicActivity is not null)
            {
                _unitOfWork.PublicActivityRepo.Delete(publicActivity);
            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
