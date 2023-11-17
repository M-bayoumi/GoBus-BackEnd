using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.BLL.Managers.ReservationManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationManager _reservationManager;

        public ReservationsController(IReservationManager reservationManager)
        {
            _reservationManager = reservationManager;
        }

        
        #region GetAllWithTripDetailsAsync
        [HttpGet]
        public async Task<IActionResult> GetAllWithTripDetailsAsync()
        {
            Response response = await _reservationManager.GetAllWithTripDetailsAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

       
        #region GetAllByTripIdAsync
        [HttpGet("tripId/{id:int}")]
        public async Task<IActionResult> GetAllByTripIdAsync(int id)
        {
            Response response = await _reservationManager.GetAllByTripIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
      

        #region GetAllWithTripDetailsByUserIdAsync
        [HttpGet("userId{id}")]
        public async Task<IActionResult> GetAllWithTripDetailsByUserIdAsync(string id)
        {
            Response response = await _reservationManager.GetAllWithTripDetailsByUserIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        #region FilterByDateAsync
        [HttpGet("filter/{date}")]
        public async Task<IActionResult> FilterByDateAsync(DateTime date)
        {
            Response response = await _reservationManager.FilterByDateAsync(DateOnly.FromDateTime(date));

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion




        #region GetByIdWithTripDetailsAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithTripDetailsAsync(int id)
        {
            Response response = await _reservationManager.GetByIdWithTripDetailsAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
        

        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(ReservationAddDto reservationAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _reservationManager.AddAsync(reservationAddDto);

                if (response.Success)

                    return Ok(response);
            }

            return BadRequest(reservationAddDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _reservationManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
