using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.DestinationManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationManager _destinationManager;

        public DestinationsController(IDestinationManager destinationManager)
        {
            _destinationManager = destinationManager;
        }


        #region GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<DestinationReadDto>? destinationReadDtos = await _destinationManager.GetAllAsync();

            if (destinationReadDtos is not null)
            {
                return Ok(destinationReadDtos);
            }

            return NotFound($"There is no Destinations found");

        }
        #endregion


        #region GetByIdAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            DestinationReadDto? destinationReadDto = await _destinationManager.GetByIdAsync(id);

            if (destinationReadDto is not null)
            {
                return Ok(destinationReadDto);
            }

            return NotFound($"Destination with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(DestinationAddDto destinationAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _destinationManager.AddAsync(destinationAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(destinationAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _destinationManager.UpdateAsync(id, destinationUpdateDto);

                if (result)
                {
                    return Ok("Updated");
                }
            }

            return BadRequest(destinationUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _destinationManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"Destination with id ({id}) is not found");
        }
        #endregion
    }
}
