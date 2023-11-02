using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.ClassImageDto;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.ClassImageManagers;
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
            IEnumerable<ClassImageReadDto>? classImageReadDtos = await _classImageManager.GetAllAsync();

            if (classImageReadDtos is not null)
            {
                return Ok(classImageReadDtos);
            }

            return NotFound("There is no ClassImages");
        }
        #endregion


        #region GetAllByBusClassIdAsync
        [HttpGet("busClassId/{id:int}")]
        public async Task<IActionResult> GetAllByBusClassIdAsync(int id)
        {
            IEnumerable<ClassImageReadDto>? classImageReadDtos = await _classImageManager.GetAllByBusClassIdAsync(id);

            if (classImageReadDtos is not null)
            {
                return Ok(classImageReadDtos);
            }

            return NotFound($"ClassImage with BusClassId ({id}) is not found");
        }
        #endregion


        #region GetByIdAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            ClassImageReadDto? classImageReadDto = await _classImageManager.GetByIdAsync(id);

            if (classImageReadDto is not null)
            {
                return Ok(classImageReadDto);
            }

            return NotFound($"ClassImage with id ({id}) is not found");
        }
        #endregion


        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(ClassImageAddDto classImageAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _classImageManager.AddAsync(classImageAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(classImageAddDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _classImageManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"ClassImage with id ({id}) is not found");
        }
        #endregion
    }
}
