using GoBye.BLL.Dtos.EndBranchDtos;
using GoBye.BLL.Dtos.PolicyDtos;
using GoBye.BLL.Managers.EndBranchManagers;
using GoBye.BLL.Managers.PolicyManager;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly IPolicyManager _policyManager;

        public PoliciesController(IPolicyManager policyManager)
        { 
            _policyManager = policyManager;
        }


        #region GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            IEnumerable<PolicyReadDto>? policyReadDto = await _policyManager.GetAllAsync();

            if (policyReadDto is not null)
            {
                return Ok(policyReadDto);
            }

            return NotFound($"There is no Policies found");

        }
        #endregion
       

        #region GetByIdAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            PolicyReadDto? policyReadDto = await _policyManager.GetByIdAsync(id);

            if (policyReadDto is not null)
            {
                return Ok(policyReadDto);
            }

            return NotFound($"Policy with Id ({id}) not found");

        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(PolicyAddDto policyAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _policyManager.AddAsync(policyAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(policyAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, PolicyUpdateDto policyUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _policyManager.UpdateAsync(id, policyUpdateDto);

                if (result)
                {
                    return Ok("Updated");
                }
            }

            return BadRequest(policyUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _policyManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"Policy with id ({id}) is not found");
        }
        #endregion
    }
}
