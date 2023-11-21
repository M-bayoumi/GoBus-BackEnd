using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.TicketDtos;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.TicketManagers;
using GoBye.DAL.Data.Models;
using GoBye.DAL.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketManager _ticketManager;

        public TicketsController(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }

        #region GetAllWithReservationNumberAsync
        [HttpGet]
        public async Task<IActionResult> GetAllWithReservationNumberAsync()
        {
            Response response = await _ticketManager.GetAllWithReservationNumberAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllByReservationIdAsync
        [HttpGet("reservation/{id:int}")]
        public async Task<IActionResult> GetAllByReservationIdAsync(int id)
        {
            Response response = await _ticketManager.GetAllByReservationIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        #region GetAllByTripIdAsync
        [HttpGet("trip/{id:int}")]
        public async Task<IActionResult> GetAllByTripIdAsync(int id)
        {
            Response response = await _ticketManager.GetAllByTripIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetByIdWithReservationNumberAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithReservationNumberAsync(int id)
        {
            Response response = await _ticketManager.GetByIdWithReservationNumberAsync(id);

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
        public async Task<IActionResult> AddAsync(TicketAddDto ticketAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _ticketManager.AddAsync(ticketAddDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(ticketAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync(int id, TicketUpdateDto ticketUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _ticketManager.UpdateAsync(id, ticketUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(ticketUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _ticketManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

    }
}
