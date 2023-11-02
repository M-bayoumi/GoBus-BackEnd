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
        public async Task<IEnumerable<ClassImageReadDto>?> GetAllAsync()
        {
            IEnumerable<ClassImage>? classImages = await _unitOfWork.ClassImageRepo.GetAllAsync();
            if(classImages is not null)
            {
                return classImages.Select(x => new ClassImageReadDto
                {
                    Id = x.Id,
                    ImageURL = x.ImageURL,
                    BusClassId = x.BusClassId
                });
            }
            return null;
        }
        #endregion


        #region GetAllByBusClassIdAsync
        public async Task<IEnumerable<ClassImageReadDto>?> GetAllByBusClassIdAsync(int id)
        {
            IEnumerable<ClassImage>? classImages = await _unitOfWork.ClassImageRepo.GetAllByBusClassIdAsync(id);
            if (classImages is not null)
            {
                return classImages.Select(x => new ClassImageReadDto
                {
                    Id = x.Id,
                    ImageURL = x.ImageURL,
                    BusClassId = x.BusClassId
                });
            }
            return null;
        }
        #endregion


        #region GetByIdAsync
        public async Task<ClassImageReadDto?> GetByIdAsync(int id)
        {
            ClassImage? classImage = await _unitOfWork.ClassImageRepo.GetByIdAsync(id);
            if (classImage is not null)
            {
                ClassImageReadDto classImageReadDto = new ClassImageReadDto
                {
                    Id = classImage.Id,
                    ImageURL = classImage.ImageURL,
                    BusClassId = classImage.BusClassId
                };
                return classImageReadDto;
            }
            return null;
        }
        #endregion


        #region AddAsync
        public async Task<bool> AddAsync(ClassImageAddDto classImageAddDto)
        {
            ClassImage classImage = new ClassImage
            {
                BusClassId = classImageAddDto.BusClassId,
                ImageURL = classImageAddDto.ImageURL
            };
            await _unitOfWork.ClassImageRepo.AddAsync(classImage);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion


        #region DeleteAsync
        public async Task<bool> DeleteAsync(int id)
        {
            ClassImage? classImage = await _unitOfWork.ClassImageRepo.GetByIdAsync(id);
            if(classImage is not null)
            {
                _unitOfWork.ClassImageRepo.Delete(classImage);

            }
            return await _unitOfWork.SaveChangesAsync() > 0;
        }
        #endregion
    }
}
