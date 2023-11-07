using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Dtos.EndBranchDtos;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.BLL.Managers.EndBranchManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndBranchesController : ControllerBase
    {
        private readonly IEndBranchManager _endBranchManager;

        public EndBranchesController(IEndBranchManager endBranchManager)
        {
            _endBranchManager = endBranchManager;
        }


        #region GetAllWithDestinationNameAsync
        [HttpGet]
        public async Task<IActionResult> GetAllWithDestinationNameAsync()
        {
            Response response = await _endBranchManager.GetAllWithDestinationNameAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion


        #region GetAllByDestinationIdAsync
        [HttpGet("destinationId/{id:int}")]
        public async Task<IActionResult> GetAllByDestinationIdAsync(int id)
        {
            Response response = await _endBranchManager.GetAllByDestinationIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion

        #region FilterEndBranchesByStartBranchDestinationIdAsync
        [HttpGet("filter/destinationId/{id:int}")]
        public async Task<IActionResult> FilterEndBranchesByStartBranchDestinationIdAsync(int id)
        {
            Response response = await _endBranchManager.FilterEndBranchesByStartBranchDestinationIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion

        #region GetByIdWithDestinationNameAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithDestinationNameAsync(int id)
        {
            Response response = await _endBranchManager.GetByIdWithDestinationNameAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(EndBranchAddDto endBranchAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _endBranchManager.AddAsync(endBranchAddDto);

                if (response.Success)

                    return Ok(response);
            }

            return BadRequest(endBranchAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, EndBranchUpdateDto endBranchUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _endBranchManager.UpdateAsync(id, endBranchUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(endBranchUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _endBranchManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


    }
}
