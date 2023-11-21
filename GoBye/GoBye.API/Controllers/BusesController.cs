using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Managers.BusManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesController : ControllerBase
    {
        private readonly IBusManager _busManager;

        public BusesController(IBusManager busManager)
        {
            _busManager = busManager;
        }

        #region GetAllWithBusClassAsync
        [HttpGet]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllWithBusClassAsync()
        {
            Response response = await _busManager.GetAllWithBusClassAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllByBusClassIdAsync
        [HttpGet("ClassId/{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllByBusClassIdAsync(int id)
        {
            Response response = await _busManager.GetAllByBusClassIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllAvailableBusesAsync
        [HttpGet("Available")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllAvailableBusesAsync()
        {
            Response response = await _busManager.GetAllAvailableBusesAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetByIdWithBusClassAsync
        [HttpGet("{id:int}")]

        public async Task<IActionResult> GetByIdWithBusClassAsync(int id)
        {
            Response response = await _busManager.GetByIdWithBusClassAsync(id);

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
        public async Task<IActionResult> AddAsync(BusAddDto busAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _busManager.AddAsync(busAddDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(busAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync(int id, BusUpdateDto busUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _busManager.UpdateAsync(id, busUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(busUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _busManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

    }
}
