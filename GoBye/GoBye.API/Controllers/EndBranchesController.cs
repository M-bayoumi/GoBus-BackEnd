using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Dtos.EndBranchDtos;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.BLL.Managers.EndBranchManagers;
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
            IEnumerable<EndBranchWithDestinationNameDto>? endBranchWithDestinationNameDtos = await _endBranchManager.GetAllWithDestinationNameAsync();

            if (endBranchWithDestinationNameDtos is not null)
            {
                return Ok(endBranchWithDestinationNameDtos);
            }

            return NotFound($"There is no EndBranches found");

        }
        #endregion


        #region GetAllByDestinationIdAsync
        [HttpGet("destinationId/{id:int}")]
        public async Task<IActionResult> GetAllByDestinationIdAsync(int id)
        {
            IEnumerable<EndBranchReadDto>? endBranchReadDtos = await _endBranchManager.GetAllByDestinationIdAsync(id);

            if (endBranchReadDtos is not null)
            {
                return Ok(endBranchReadDtos);
            }

            return NotFound($"There is no EndBranches with DestinationId ({id}) not found");

        }
        #endregion


        #region GetByIdWithDestinationNameAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithDestinationNameAsync(int id)
        {
            EndBranchReadDto? endBranchReadDto = await _endBranchManager.GetByIdWithDestinationNameAsync(id);

            if (endBranchReadDto is not null)
            {
                return Ok(endBranchReadDto);
            }

            return NotFound($"EndBranch with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(EndBranchAddDto endBranchAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _endBranchManager.AddAsync(endBranchAddDto);

                if (result)
                {
                    return Ok("Created");
                }
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
                bool result = await _endBranchManager.UpdateAsync(id, endBranchUpdateDto);

                if (result)
                {
                    return Ok("Updated");
                }
            }

            return BadRequest(endBranchUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _endBranchManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"EndBranch with id ({id}) is not found");
        }
        #endregion


    }
}
