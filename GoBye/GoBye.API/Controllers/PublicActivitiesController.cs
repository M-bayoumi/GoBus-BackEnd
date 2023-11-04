using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Dtos.PolicyDtos;
using GoBye.BLL.Dtos.PublicActivityDtos;
using GoBye.BLL.Managers.PolicyManager;
using GoBye.BLL.Managers.PublicActivityManagers;
using GoBye.DAL.Data.Models;
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
            Response response = await _publicActivityManager.GetAllAsync();

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
            Response response = await _publicActivityManager.GetAllByDestinationIdAsync(id);

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
            Response response = await _publicActivityManager.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion

      
        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(PublicActivityAddDto publicActivityAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _publicActivityManager.AddAsync(publicActivityAddDto);

                if (response.Success)

                    return Ok(response);
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
                Response response = await _publicActivityManager.UpdateAsync(id, publicActivityUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(publicActivityUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _publicActivityManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
