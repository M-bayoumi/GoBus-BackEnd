using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.DAL.Data.Models;
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
            Response response = await _destinationManager.GetAllAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion

        #region GetAllWithBranchesDetailsAsync
        [HttpGet("branches")]
        public async Task<IActionResult> GetAllWithBranchesDetailsAsync()
        {
            Response response = await _destinationManager.GetAllWithBranchesDetailsAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion

        #region GetByIdAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Response response = await _destinationManager.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(DestinationAddDto destinationAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _destinationManager.AddAsync(destinationAddDto);

                if (response.Success)

                    return Ok(response);
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
                Response response = await _destinationManager.UpdateAsync(id, destinationUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(destinationUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _destinationManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
