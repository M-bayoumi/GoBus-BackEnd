using GoBye.BLL.Dtos.ApplicationRoleDtos;
using GoBye.BLL.Managers.ApplicationRoleManagers;
using GoBye.DAL.Data.Models;
using GoBye.DAL.Repos.ApplicationRoleRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationRolesController : ControllerBase
    {
        private readonly IApplicationRoleManager _applicationRoleManager;

        public ApplicationRolesController(IApplicationRoleManager applicationRoleManager)
        {
            _applicationRoleManager = applicationRoleManager;
        }


        #region GetAllAsync
        [HttpGet]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllAsync()
        {
            Response response  = await _applicationRoleManager.GetAllAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion


        #region GetByIdAsync
        [HttpGet("{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            Response response = await _applicationRoleManager.GetByIdAsync(id);

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
        public async Task<IActionResult> AddAsync(ApplicationRoleAddDto applicationRoleAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationRoleManager.AddAsync(applicationRoleAddDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(applicationRoleAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync(string id, ApplicationRoleUpdateDto applicationRoleUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationRoleManager.UpdateAsync(id, applicationRoleUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(applicationRoleUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            Response response = await _applicationRoleManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
