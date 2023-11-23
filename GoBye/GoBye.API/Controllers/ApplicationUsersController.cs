using GoBye.BLL.Dtos.ApplicationRoleDtos;
using GoBye.BLL.Dtos.ApplicationUserDtos;
using GoBye.BLL.Managers.ApplicationUserManager;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Data;
using System.Security.Claims;
using System.Text;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUsersController : ControllerBase
    {
        private readonly IApplicationUserManager _applicationUserManager;

        public ApplicationUsersController(IApplicationUserManager applicationUserManager)
        {
            _applicationUserManager = applicationUserManager;
        }

        #region GetAllUsersAsync
        [HttpGet]
        [Route("/api/users")]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            Response response = await _applicationUserManager.GetAllUsersAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllDriversAsync
        [HttpGet]
        [Route("/api/drivers")]
        public async Task<IActionResult> GetAllDriversAsync()
        {
            Response response = await _applicationUserManager.GetAllDriversAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllAdminsAsync
        [HttpGet]
        [Route("/api/admins")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllAdminsAsync()
        {
            Response response = await _applicationUserManager.GetAllAdminsAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllUsersWithDetailsAsync
        [HttpGet]
        [Route("/api/users/details")]
        public async Task<IActionResult> GetAllUsersWithDetailsAsync()
        {
            Response response = await _applicationUserManager.GetAllUsersWithDetailsAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion


        #region GetAllDriversWithDetailsAsync
        [HttpGet]
        [Route("/api/drivers/details")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllDriversWithDetailsAsync()
        {
            Response response = await _applicationUserManager.GetAllDriversWithDetailsAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion


        #region GetAllByRoleAsync
        [HttpGet]
        [Route("role/id")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAllByRoleAsync(string id)
        {
            Response response = await _applicationUserManager.GetAllByRoleAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion


        #region GetUserByIdWithDetailsAsync

        [HttpGet]
        [Route("/api/users/{id}")]
        public async Task<IActionResult> GetUserByIdWithDetailsAsync(string id)
        {
            Response response = await _applicationUserManager.GetUserByIdWithDetailsAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion


        #region GetDriverByIdWithDetailsAsync
        [HttpGet]
        [Route("/api/drivers/{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetDriverByIdWithDetailsAsync(string id)
        {
            Response response = await _applicationUserManager.GetDriverByIdWithDetailsAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }

        #endregion


        #region RegisterUserAsync
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationUserManager.RegisterAsync(registerDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(ModelState);
        }
        #endregion


        #region RegisterDriverAsync
        [HttpPost("register/driver")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> RegisterDriverAsync(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationUserManager.RegisterDriverAsync(registerDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(ModelState);
        }
        #endregion


        #region RegisterAdminAsync
        [HttpPost("register/admin")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> RegisterAdminAsync(RegisterDto registerDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationUserManager.RegisterAdminAsync(registerDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(ModelState);
        }
        #endregion


        #region GetAllUserNamesAsync
        [HttpGet]
        [Route("/api/users/usernames")]
        public async Task<IActionResult> GetAllUserNamesAsync()
        {
            Response response = await _applicationUserManager.GetAllUserNamesAsync();

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        #endregion


        #region GetAllEmailsAsync
        [HttpGet]
        [Route("/api/users/emails")]
        public async Task<IActionResult> GetAllEmailsAsync()
        {
            Response response = await _applicationUserManager.GetAllEmailsAsync();

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }
        #endregion


        #region BlockUserAsync
        [HttpGet("block/{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> BlockUserAsync(string id)
        {
            Response response = await _applicationUserManager.BlockUserAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

        #endregion


        #region LoginAsync
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationUserManager.LoginAsync(loginDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(loginDto);

        }
        #endregion


        #region UpdateAsync
        [HttpPut]
        [Route("{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync(string id, UserUpdateDto userUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _applicationUserManager.UpdateAsync(id, userUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return NotFound(response);

            }
            return BadRequest(userUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete]
        [Route("{id}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            Response response = await _applicationUserManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
        #endregion


        #region GetUserAsync
        [HttpGet("getUser")]
        [Authorize(Policy = "ForUser")]
        public async Task<IActionResult> GetUserAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            Response response = await _applicationUserManager.GetByIdAsync(userId);

            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
        #endregion


        #region GetAdminAsync
        [HttpGet("getAdmin")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> GetAdminAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            Response response = await _applicationUserManager.GetByIdAsync(userId);

            if (response.Success)
            {
                return Ok(response);
            }
            return NotFound(response);
        }
        #endregion

    }
}
