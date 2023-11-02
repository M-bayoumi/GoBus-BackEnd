using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Dtos.ReservationDtos;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.BLL.Managers.ReservationManagers;
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
            IEnumerable<ReservationDetailsDto>? reservationDetailsDtos = await _reservationManager.GetAllWithTripDetailsAsync();

            if (reservationDetailsDtos is not null)
            {
                return Ok(reservationDetailsDtos);
            }

            return NotFound($"There is no Reservation found");
        }
        #endregion

       
        #region GetAllByTripIdAsync
        [HttpGet("tripId/{id:int}")]
        public async Task<IActionResult> GetAllByTripIdAsync(int id)
        {
            IEnumerable<ReservationReadDto>? reservationReadDtos = await _reservationManager.GetAllByTripIdAsync(id);

            if (reservationReadDtos is not null)
            {
                return Ok(reservationReadDtos);
            }

            return NotFound($"Reservations with TripId ({id}) is not found");
        }
        #endregion
      

        #region GetAllWithTripDetailsByUserIdAsync
        [HttpGet("userId{id}")]
        public async Task<IActionResult> GetAllWithTripDetailsByUserIdAsync(string id)
        {
            IEnumerable<ReservationDetailsDto>? reservationReadDtos = await _reservationManager.GetAllWithTripDetailsByUserIdAsync(id);

            if (reservationReadDtos is not null)
            {
                return Ok(reservationReadDtos);
            }

            return NotFound($"Reservations with UserId ({id}) is not found");
        }
        #endregion
        

        #region GetByIdWithDestinationNameAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithTripDetailsAsync(int id)
        {
            ReservationDetailsDto? reservationDetailsDto = await _reservationManager.GetByIdWithTripDetailsAsync(id);

            if (reservationDetailsDto is not null)
            {
                return Ok(reservationDetailsDto);
            }

            return NotFound($"Reservation with id ({id}) is not found");
        }
        #endregion
        

        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(ReservationAddDto reservationAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _reservationManager.AddAsync(reservationAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(reservationAddDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _reservationManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"Reservation with id ({id}) is not found");
        }
        #endregion
    }
}
