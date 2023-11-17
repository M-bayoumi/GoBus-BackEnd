using GoBye.BLL.Dtos.PolicyDtos;
using GoBye.BLL.Dtos.PublicActivityDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<Response> GetAllWithDestinationNameAsync()
        {
            IEnumerable<PublicActivity>? publicActivities = await _unitOfWork.PublicActivityRepo.GetAllWithDestinationNameAsync();
            if (publicActivities is not null)
            {
                var data = publicActivities.Select(x => new PublicActivityReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageURL = x.ImageURL,
                    Description = x.Description,
                    DestinationName = x.Destination.Name,
                    DestinationId = x.Destination.Id
                });
                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no public Activities");

        }
        #endregion


        #region GetAllByDestinationIdAsync
        public async Task<Response> GetAllByDestinationIdAsync(int id)
        {
            IEnumerable<PublicActivity>? publicActivities = await _unitOfWork.PublicActivityRepo.GetAllByDestinationIdAsync(id);
            if (publicActivities is not null)
            {
                var data = publicActivities.Select(x => new PublicActivityReadDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    ImageURL = x.ImageURL,
                    Description = x.Description,
                    DestinationName = x.Destination.Name
                });
                return _unitOfWork.Response(true, data, null);

            }
            return _unitOfWork.Response(false, null, $"There is no public Activities With destination id ({id})");

        }
        #endregion


        #region GetByIdAsync
        public async Task<Response> GetByIdAsync(int id)
        {
            PublicActivity? publicActivity = await _unitOfWork.PublicActivityRepo.GetByIdAsync(id);
            if (publicActivity is not null)
            {
                var data = new PublicActivityReadDto
                {
                    Id = publicActivity.Id,
                    Title = publicActivity.Title,
                    ImageURL = publicActivity.ImageURL,
                    Description = publicActivity.Description,
                };
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, $"There is no public Activitie With id ({id})");

        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(PublicActivityAddDto publicActivityAddDto)
        {
            PublicActivity publicActivity = new PublicActivity
            {
                Title = publicActivityAddDto.Title,
                ImageURL = publicActivityAddDto.ImageURL,
                Description = publicActivityAddDto.Description,
                DestinationID = publicActivityAddDto.DestinationID,
            };
            await _unitOfWork.PublicActivityRepo.AddAsync(publicActivity);
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Public activity has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add Public activity");
        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(int id, PublicActivityUpdateDto publicActivityUpdateDto)
        {
            PublicActivity? publicActivity = await _unitOfWork.PublicActivityRepo.GetByIdAsync(id);
            if (publicActivity is not null)
            {
                publicActivity.Title = publicActivityUpdateDto.Title;
                publicActivity.ImageURL = publicActivityUpdateDto.ImageURL;
                publicActivity.Description = publicActivityUpdateDto.Description;
                publicActivity.DestinationID = publicActivityUpdateDto.DestinationID;
            }
            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The Public activity has been updated successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to update Public activity");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            PublicActivity? publicActivity = await _unitOfWork.PublicActivityRepo.GetByIdAsync(id);
            if (publicActivity is not null)
            {
                _unitOfWork.PublicActivityRepo.Delete(publicActivity);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The Public activity has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete Public activity");
            }
            return _unitOfWork.Response(false, null, $"Public activity with id ({id}) is not found");

        }
        #endregion
    }
}
