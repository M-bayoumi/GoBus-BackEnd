using GoBye.BLL.Dtos;
using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.BusDtos;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.BusRepo;
using GoBye.DAL.Repos.ClassBusRepo;
using GoBye.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GoBye.BLL.Managers.BusClassManagers
{
    public class BusClassManager:IBusClassManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public BusClassManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        

        #region GetAllAsync
        public async Task<Response> GetAllAsync()
        {
            IEnumerable<BusClass>? busClasses = await _unitOfWork.BusClassRepo.GetAllAsync();
            if (busClasses is not null)
            {
                var data = busClasses.Select(x => new BusClassReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    AveragePrice = x.AveragePrice
                });

                return _unitOfWork.Response(true, data, null);
            }

            return _unitOfWork.Response(false, null, "There is no BusClasses");
        }
        #endregion


        #region GetAllWithDetailsAsync
        public async Task<Response> GetAllWithDetailsAsync()
        {
            IEnumerable<BusClass>? busClasses = await _unitOfWork.BusClassRepo.GetAllWithDetailsAsync();
            if (busClasses is not null)
            {
                var data = busClasses.Select(x => new BusClassDetailsDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    AveragePrice=x.AveragePrice,
                    BusesNumbers = x.Buses.Select(y => y.Number),
                    ClassImageURLs = x.ClassImages.Select(y => y.ImageURL),
                });

                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, "There is no BusClasses");
        }
        #endregion


        #region GetByIdAsync
        public async Task<Response> GetByIdAsync(int id)
        {
            BusClass? busClass = await _unitOfWork.BusClassRepo.GetByIdAsync(id);
            if (busClass is not null)
            {
                var data = new BusClassReadDto
                {
                    Id = busClass.Id,
                    Name = busClass.Name,
                    AveragePrice = busClass.AveragePrice,
                };

                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, $"BusClass with id ({id}) is not found");
        }
        #endregion


        #region GetByIdWithDetailsAsync
        public async Task<Response> GetByIdWithDetailsAsync(int id)
        {
            BusClass? busClass = await _unitOfWork.BusClassRepo.GetByIdWithDetailsAsync(id);
            if (busClass is not null)
            {
                var data = new BusClassDetailsDto
                {
                    Id = busClass.Id,
                    Name = busClass.Name,
                    AveragePrice = busClass.AveragePrice,
                    BusesNumbers = busClass.Buses.Select(y => y.Number),
                    ClassImageURLs = busClass.ClassImages.Select(y => y.ImageURL),
                };

                return _unitOfWork.Response(true, data, null);

            }

            return _unitOfWork.Response(false, null, $"BusClass with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        public async Task<Response> AddAsync(BusClassAddDto busClassAddDto)
        {
            BusClass busClass = new BusClass
            {
                Name = busClassAddDto.Name,
                AveragePrice = busClassAddDto.AveragePrice
            };
            await _unitOfWork.BusClassRepo.AddAsync(busClass);

            bool addClass = await _unitOfWork.SaveChangesAsync() > 0;
            

            if (addClass && busClassAddDto.ClassImageURLs is not null)
            {
                foreach (var ClassImageURL in busClassAddDto.ClassImageURLs)
                {
                    ClassImage classImage = new ClassImage
                    {
                        BusClassId = busClass.Id,
                        ImageURL = ClassImageURL
                    };
                    await _unitOfWork.ClassImageRepo.AddAsync(classImage);
                }
            }
            bool addClassImages = await _unitOfWork.SaveChangesAsync() > 0;


            if (addClass && addClassImages)
            {
                return _unitOfWork.Response(true, null, "The class and classImages have been added successfully");
            }
            else if (addClass && !addClassImages)
            {
                return _unitOfWork.Response(true, null, "The class has been added successfully but the classImages failed to be added");

            }
            return _unitOfWork.Response(false, null, "Failed to add class and classImages");
        }
        #endregion


        #region UpdateAsync
        public async Task<Response> UpdateAsync(int id, BusClassUpdateDto busClassUpdateDto)
        {
            BusClass? busClass = await _unitOfWork.BusClassRepo.GetByIdAsync(id);
            if (busClass is not null)
            {
                busClass.Name = busClassUpdateDto.Name;
                busClass.AveragePrice = busClassUpdateDto.AveragePrice;
                busClass.ClassImages = new List<ClassImage>();

                if (busClassUpdateDto.ClassImageURLs is not null)
                {
                    foreach (var ClassImageURL in busClassUpdateDto.ClassImageURLs)
                    {
                        ClassImage classImage = new ClassImage
                        {
                            BusClassId = busClass.Id,
                            ImageURL = ClassImageURL
                        };
                        await _unitOfWork.ClassImageRepo.AddAsync(classImage);
                    }
                }
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The BusClassName has been updated successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to update BusClassName");
            }
            return _unitOfWork.Response(false, null, $"BusClass with id ({id}) is not found");

        }
        #endregion


        #region DeleteAsync
        public async Task<Response> DeleteAsync(int id)
        {
            BusClass? busClass = await _unitOfWork.BusClassRepo.GetByIdAsync(id);
            if (busClass is not null)
            {
                _unitOfWork.BusClassRepo.Delete(busClass);
                bool result = await _unitOfWork.SaveChangesAsync() > 0;
                if (result)
                {
                    return _unitOfWork.Response(true, null, "The BusClassName has been deleted successfully");
                }
                return _unitOfWork.Response(false, null, "Failed to delete BusClassName");
            }

            return _unitOfWork.Response(false, null, $"BusClass with id ({id}) is not found");
        }
        #endregion
    }
}
