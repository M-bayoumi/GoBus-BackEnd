using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Dtos.TripDtos;
using GoBye.BLL.Managers.BusManagers;
using GoBye.BLL.Managers.ReservationManagers;
using GoBye.BLL.Managers.TripManagers;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private readonly ITripManager _tripManager;
        private readonly IUnitOfWork _unitOfWork;

        public TripsController(ITripManager tripManager, IUnitOfWork unitOfWork)
        {
            _tripManager = tripManager;
            _unitOfWork = unitOfWork;
        }


        #region FilterAllAsync
        [HttpPost("search")]
        public async Task<IActionResult> FilterAllAsync(TripSearchDto tripSearchDto)
        {
            IEnumerable<TripReadDto>? tripReadDtos = await _tripManager.FilterAllAsync(tripSearchDto);

            if (tripReadDtos is not null)
            {
                return Ok(tripReadDtos);
            }

            return NotFound($"There is no Trips found");
        }
        #endregion


        #region GetAllWithDetailsAsync
        [HttpGet]
        public async Task<IActionResult> GetAllWithDetailsAsync()
        {
            IEnumerable<TripDetailsDto>? tripDetailsDtos = await _tripManager.GetAllWithDetailsAsync();

            if (tripDetailsDtos is not null)
            {
                return Ok(tripDetailsDtos);
            }

            return NotFound($"There is no Trips found");
        }
        #endregion


        #region GetByIdWithBusClassNameAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithBusClassNameAsync(int id)
        {
            TripUserDto? tripUserDto = await _tripManager.GetByIdWithBusClassNameAsync(id);

            if (tripUserDto is not null)
            {
                return Ok(tripUserDto);
            }

            return NotFound($"Trip with Id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(TripAddDto tripAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _tripManager.AddAsync(tripAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(tripAddDto);
        }
        #endregion

        #region UpdateAsync
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TripUpdateDto tripUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _tripManager.UpdateAsync(id, tripUpdateDto);

                if (result)
                {
                    return Ok("Updated");
                }
                return NotFound($"Trip with Id ({id}) not found");
            }

            return BadRequest(tripUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _tripManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"Trip with id ({id}) is not found");
        }
        #endregion
    }
}

