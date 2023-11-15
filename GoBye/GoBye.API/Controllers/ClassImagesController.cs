using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.ClassImageDto;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.ClassImageManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassImagesController : ControllerBase
    {
        private readonly IClassImageManager _classImageManager;

        public ClassImagesController(IClassImageManager classImageManager)
        {
            _classImageManager = classImageManager;
        }


        #region GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response response = await _classImageManager.GetAllAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion


        #region GetAllByBusClassIdAsync
        [HttpGet("busClassId/{id:int}")]
        public async Task<IActionResult> GetAllByBusClassIdAsync(int id)
        {
            Response response = await _classImageManager.GetAllByBusClassIdAsync(id);

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
        Response response = await _classImageManager.GetByIdAsync(id);

        if (response.Success)
        {
            return Ok(response);
        }

        return NotFound(response);
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(ClassImageAddDto classImageAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _classImageManager.AddAsync(classImageAddDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }
            return BadRequest(classImageAddDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _classImageManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
