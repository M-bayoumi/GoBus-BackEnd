using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.ReportDtos;
using GoBye.BLL.Managers.BusManagers;
using GoBye.BLL.Managers.ReportManagers;
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
            IEnumerable<ReportDetailsDto>? reportDetailsDtos = await _reportManager.GetAllWithUserInfoAsync();

            if (reportDetailsDtos is not null)
            {
                return Ok(reportDetailsDtos);
            }

            return NotFound("There is no Reports found");
        }
        #endregion


        #region GetAllByUserIdAsync
        [HttpGet("userId/{id}")]
        public async Task<IActionResult> GetAllByUserIdAsync(string id)
        {
            IEnumerable<ReportUserDto>? reportUserDtos = await _reportManager.GetAllByUserIdAsync(id);

            if (reportUserDtos is not null)
            {
                return Ok(reportUserDtos);
            }

            return NotFound($"Repoerts with UserId ({id}) are not found");
        }
        #endregion
        

        #region GetByIdWithUserInfoAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdWithUserInfoAsync(int id)
        {
            ReportDetailsDto? reportDetailsDto = await _reportManager.GetByIdWithUserInfoAsync(id);

            if (reportDetailsDto is not null)
            {
                return Ok(reportDetailsDto);
            }

            return NotFound($"Report with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(ReportAddDto reportAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _reportManager.AddAsync(reportAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(reportAddDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _reportManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"Report with id ({id}) is not found");
        }
        #endregion
    }
}
