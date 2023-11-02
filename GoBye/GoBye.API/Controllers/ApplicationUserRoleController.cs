using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.BLL.Dtos.ApplicationUserRoleDto;
using GoBye.BLL.Managers.ApplicationUserManager;
using GoBye.BLL.Managers.ApplicationUserRoleManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserRoleController : ControllerBase
    {
        private readonly IApplicationUserRoleManager _applicationUserRoleManager ;

        public ApplicationUserRoleController(IApplicationUserRoleManager applicationUserRoleManager)
        {
            _applicationUserRoleManager = applicationUserRoleManager;
        }


        #region AddUserToRoleAsync
        [HttpPost]
        public async Task<IActionResult> AddUserToRoleAsync(ApplicationUserRoleAddDto applicationUserRoleAddDto)
        {
            Response response = await _applicationUserRoleManager.AddAsync(applicationUserRoleAddDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
