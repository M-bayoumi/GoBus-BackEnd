using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.ClassImageDto;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBye.BLL.Managers.ClassImageManagers
{
    public class ClassImageManager:IClassImageManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClassImageManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region GetAllAsync
        public async Task<Response> GetAllAsync()
        {
            IEnumerable<ClassImage>? classImages = await _unitOfWork.ClassImageRepo.GetAllAsync();
            if(classImages is not null)
            {
                var data =  classImages.Select(x => new ClassImageReadDto
                {
                    Id = x.Id,
                    ImageURL = x.ImageURL,
                    BusClassId = x.BusClassId
                });
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, "There is no ClassImages");
        }
        #endregion


        #region GetAllByBusClassIdAsync
        public async Task<Response> GetAllByBusClassIdAsync(int id)
        {
            IEnumerable<ClassImage>? classImages = await _unitOfWork.ClassImageRepo.GetAllByBusClassIdAsync(id);
            if (classImages is not null)
            {
                var data = classImages.Select(x => new ClassImageReadDto
                {
                    Id = x.Id,
                    ImageURL = x.ImageURL,
                    BusClassId = x.BusClassId
                });
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, "There is no ClassImages");
        }
        #endregion


        #region GetByIdAsync
        public async Task<Response> GetByIdAsync(int id)
        {
            ClassImage? classImage = await _unitOfWork.ClassImageRepo.GetByIdAsync(id);
            if (classImage is not null)
            {
                var data = new ClassImageReadDto
                {
                    Id = classImage.Id,
                    ImageURL = classImage.ImageURL,
                    BusClassId = classImage.BusClassId
                };
                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, $"ClassImages is not found");
        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(ClassImageAddDto classImageAddDto)
        {
            ClassImage classImage = new ClassImage
            {
                BusClassId = classImageAddDto.BusClassId,
                ImageURL = classImageAddDto.ImageURL
            };
            await _unitOfWork.ClassImageRepo.AddAsync(classImage);

            bool result = await _unitOfWork.SaveChangesAsync() > 0;
            if (result)
            {
                return _unitOfWork.Response(true, null, "The ClassImage has been added successfully");
            }
            return _unitOfWork.Response(false, null, "Failed to add ClassImage");
        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            ClassImage? classImage = await _unitOfWork.ClassImageRepo.GetByIdAsync(id);
            if (classImage is not null)
            {
                _unitOfWork.ClassImageRepo.Delete(classImage);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The classImage has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete classImage");
            }
            return _unitOfWork.Response(false, null, $"classImage is not found");
        }
        #endregion
    }
}
