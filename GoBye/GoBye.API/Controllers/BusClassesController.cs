using GoBye.BLL.Dtos;
using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.BusDtos;
using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BusClassesController(IBusClassManager busClassManager, IWebHostEnvironment webHostEnvironment)
        {
            _busClassManager = busClassManager;
            _webHostEnvironment = webHostEnvironment;

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
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> AddAsync([FromForm] IFormFile file, [FromForm] string name, [FromForm] string averagePrice)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            string folderPath;

            if (!Directory.Exists(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images")))
            {
                folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images"));
                folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
            }


            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(folderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var imageUrl = "https://localhost:44331/Images/" + uniqueFileName;

            var busClassAddDto = new BusClassAddDto
            {
                Name = name,
                AveragePrice = averagePrice,
                ClassImageURLs = new List<string>() { imageUrl },
            };


            Response response = await _busClassManager.AddAsync(busClassAddDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);

        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromForm] IFormFile file, [FromForm] string name, [FromForm] string averagePrice)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file");
            }

            string folderPath;

            if (!Directory.Exists(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images")))
            {
                folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
            }
            else
            {
                Directory.CreateDirectory(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images"));
                folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
            }


            string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            string filePath = Path.Combine(folderPath, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            var newImageUrl = "https://localhost:44331/Images/" + uniqueFileName;

            var busClassUpdateDto = new BusClassUpdateDto
            {
                Name = name,
                AveragePrice = averagePrice,
                ClassImageURLs = new List<string> { newImageUrl },
            };


            Response response = await _busClassManager.UpdateAsync(id, busClassUpdateDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);

        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
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
