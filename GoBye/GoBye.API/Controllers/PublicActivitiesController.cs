using GoBye.BLL.Dtos.PolicyDtos;
using GoBye.BLL.Dtos.PublicActivityDtos;
using GoBye.BLL.Managers.PolicyManager;
using GoBye.BLL.Managers.PublicActivityManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublicActivitiesController : ControllerBase
    {
        private readonly IPublicActivityManager _publicActivityManager;

        public PublicActivitiesController(IPublicActivityManager publicActivityManager)
        {
            _publicActivityManager = publicActivityManager;
        }


        #region GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<PublicActivityReadDto>? publicActivityReadDtos = await _publicActivityManager.GetAllAsync();

            if (publicActivityReadDtos is not null)
            {
                return Ok(publicActivityReadDtos);
            }

            return NotFound($"There is no PublicActivity found");

        }
        #endregion


        #region GetAllByDestinationIdAsync
        [HttpGet("destinationId/{id:int}")]
        public async Task<IActionResult> GetAllByDestinationIdAsync(int id)
        {
            IEnumerable<PublicActivityReadDto>? publicActivityReadDtos = await _publicActivityManager.GetAllByDestinationIdAsync(id);

            if (publicActivityReadDtos is not null)
            {
                return Ok(publicActivityReadDtos);
            }

            return NotFound($"There is no PublicActivity with DestinationId ({id}) found");

        }
        #endregion


        #region GetByIdAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            PublicActivityReadDto? publicActivityReadDto = await _publicActivityManager.GetByIdAsync(id);

            if (publicActivityReadDto is not null)
            {
                return Ok(publicActivityReadDto);
            }

            return NotFound($"PublicActivity with Id ({id}) not found");

        }
        #endregion

      
        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(PublicActivityAddDto publicActivityAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _publicActivityManager.AddAsync(publicActivityAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(publicActivityAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, PublicActivityUpdateDto publicActivityUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _publicActivityManager.UpdateAsync(id, publicActivityUpdateDto);

                if (result)
                {
                    return Ok("Updated");
                }
            }

            return BadRequest(publicActivityUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _publicActivityManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"PublicActivity with id ({id}) is not found");
        }
        #endregion
    }
}
