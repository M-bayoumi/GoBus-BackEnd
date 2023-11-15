
using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.BLL.Dtos.ReportDtos;
using GoBye.BLL.Managers.BusManagers;
using GoBye.BLL.Managers.ReportManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportManager _reportManager;

        public ReportsController(IReportManager reportManager)
        {
            _reportManager = reportManager;
        }
        

        #region GetAllWithUserInfoAsync
        [HttpGet]
        public async Task<IActionResult> GetAllWithUserInfoAsync()
        {
            Response response = await _reportManager.GetAllWithUserInfoAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllByUserIdAsync
        [HttpGet("userId/{id}")]
        public async Task<IActionResult> GetAllByUserIdAsync(string id)
        {
            Response response = await _reportManager.GetAllByUserIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
        

        #region GetByIdWithUserInfoAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithUserInfoAsync(int id)
        {
            Response response = await _reportManager.GetByIdWithUserInfoAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region AddAsync
        [HttpPost]
        [Authorize(Policy = "ForUser")]
        public async Task<IActionResult> AddAsync(ReportAddDto reportAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _reportManager.AddAsync(reportAddDto);

                if (response.Success)

                    return Ok(response);
            }

            return BadRequest(reportAddDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _reportManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
