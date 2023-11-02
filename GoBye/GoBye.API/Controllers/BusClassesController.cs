using GoBye.BLL.Dtos;
using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusClassesController : ControllerBase
    {
        private readonly IBusClassManager _busClassManager;

        public BusClassesController(IBusClassManager busClassManager)
        {
            _busClassManager = busClassManager;
        }


        #region GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response response = await _busClassManager.GetAllAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllWithDetailsAsync
        [HttpGet("details")]
        public async Task<IActionResult> GetAllWithDetailsAsync()
        {
            Response response = await _busClassManager.GetAllWithDetailsAsync();

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
            Response response = await _busClassManager.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetByIdWithDetailsAsync
        [HttpGet("details/{id:int}")]
        public async Task<IActionResult> GetByIdWithDetailsAsync(int id)
        {
            Response response = await _busClassManager.GetByIdWithDetailsAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(BusClassAddDto busClassAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _busClassManager.AddAsync(busClassAddDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(busClassAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, BusClassUpdateDto busClassUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _busClassManager.UpdateAsync(id, busClassUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(busClassUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _busClassManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
