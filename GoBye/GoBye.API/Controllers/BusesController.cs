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
        public async Task<IActionResult> GetAllWithBusClassAsync()
        {
            IEnumerable<BusReadDto>? busReadDtos = await _busManager.GetAllWithBusClassAsync();

            if (busReadDtos is not null)
            {
                return Ok(busReadDtos);
            }

            return NotFound("There is no Buses");
        }
        #endregion


        #region GetAllByBusClassIdAsync
        [HttpGet("ClassId/{id:int}")]
        public async Task<IActionResult> GetAllByBusClassIdAsync(int id)
        {
            IEnumerable<BusReadDto>? busReadDtos = await _busManager.GetAllByBusClassIdAsync(id);

            if (busReadDtos is not null)
            {
                return Ok(busReadDtos);
            }

            return NotFound($"Buses with BusClassId ({id}) are not found");
        }
        #endregion


        #region GetAllAvailableBusesAsync
        [HttpGet("Available")]
        public async Task<IActionResult> GetAllAvailableBusesAsync()
        {
            IEnumerable<BusAvailableDto>? busAvailableDtos = await _busManager.GetAllAvailableBusesAsync();

            if (busAvailableDtos is not null)
            {
                return Ok(busAvailableDtos);
            }

            return NotFound($"There is no Available Buses are found");
        }
        #endregion


        #region GetByIdWithBusClassAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithBusClassAsync(int id)
        {
            BusReadDto? busReadDtos = await _busManager.GetByIdWithBusClassAsync(id);

            if (busReadDtos is not null)
            {
                return Ok(busReadDtos);
            }

            return NotFound($"Bus with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(BusAddDto busAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _busManager.AddAsync(busAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }
            
            return BadRequest(busAddDto); 
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, BusUpdateDto busUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _busManager.UpdateAsync(id, busUpdateDto);

                if (result)
                {
                    return Ok("Updated");
                }
            }
           
            return BadRequest(busUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _busManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"BusClass with id ({id}) is not found");
        }
        #endregion

    }
}
