using GoBye.BLL.Dtos.StartBranchDtos;
using GoBye.BLL.Managers.StartBranchManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StartBranchesController : ControllerBase
    {
        private readonly IStartBranchManager _startBranchManager;

        public StartBranchesController(IStartBranchManager startBranchManager)
        {
            _startBranchManager = startBranchManager;
        }


        #region GetAllWithDestinationNameAsync
        [HttpGet]
        public async Task<IActionResult> GetAllWithDestinationNameAsync()
        {
            Response response = await _startBranchManager.GetAllWithDestinationNameAsync();

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
            Response response = await _startBranchManager.GetAllByDestinationIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion

        #region FilterStartBranchesByEndBranchDestinationIdAsync
        [HttpGet("filter/destinationId/{id:int}")]
        public async Task<IActionResult> FilterStartBranchesByEndBranchDestinationIdAsync(int id)
        {
            Response response = await _startBranchManager.FilterStartBranchesByEndBranchDestinationIdAsync(id);

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
            Response response = await _startBranchManager.GetByIdWithDestinationNameAsync(id);

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
        public async Task<IActionResult> AddAsync(StartBranchAddDto startBranchAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _startBranchManager.AddAsync(startBranchAddDto);

                if (response.Success)

                    return Ok(response);
            }

            return BadRequest(startBranchAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync(int id, StartBranchUpdateDto startBranchUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _startBranchManager.UpdateAsync(id, startBranchUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(startBranchUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _startBranchManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


    }
}

