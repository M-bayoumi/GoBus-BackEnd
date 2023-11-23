using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Dtos.TripDtos;
using GoBye.BLL.Managers.BusManagers;
using GoBye.BLL.Managers.ReservationManagers;
using GoBye.BLL.Managers.TripManagers;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
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


        #region SearchAsync
        [HttpPost("search")]
        public async Task<IActionResult> SearchAsync(TripSearchDto tripSearchDto)
        {
            Response response = await _tripManager.SearchAsync(tripSearchDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region FilterByDateAsync
        [HttpGet("filter/{date}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> FilterByDateAsync(DateTime date)
        {
            Response response = await _tripManager.FilterByDateAsync(DateOnly.FromDateTime(date));

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllWithDetailsAsync
        [HttpGet]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllWithDetailsAsync()
        {
            Response response = await _tripManager.GetAllWithDetailsAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetByIdWithBusClassNameAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithBusClassNameAsync(int id)
        {
            Response response = await _tripManager.GetByIdWithBusClassNameAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region AddAsync
        [HttpPost]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> AddAsync(TripAddDto tripAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _tripManager.AddAsync(tripAddDto);

                if (response.Success)

                    return Ok(response);
            }

            return BadRequest(tripAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync(int id, TripUpdateDto tripUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _tripManager.UpdateAsync(id, tripUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(tripUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _tripManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}

