using GoBye.BLL.Dtos.BusClassDtos;
using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Managers.BusClassManagers;
using GoBye.BLL.Managers.DestinationManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationsController : ControllerBase
    {
        private readonly IDestinationManager _destinationManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DestinationsController(IDestinationManager destinationManager, IWebHostEnvironment webHostEnvironment)
        {
            _destinationManager = destinationManager;
            _webHostEnvironment = webHostEnvironment;
        }




        #region GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response response = await _destinationManager.GetAllAsync();

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);

        }
        #endregion

        #region GetAllWithBranchesDetailsAsync
        [HttpGet("branches")]
        public async Task<IActionResult> GetAllWithBranchesDetailsAsync()
        {
            Response response = await _destinationManager.GetAllWithBranchesDetailsAsync();

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
            Response response = await _destinationManager.GetByIdAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion

        /*
        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(DestinationAddDto destinationAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _destinationManager.AddAsync(destinationAddDto);

                if (response.Success)

                    return Ok(response);
            }

            return BadRequest(destinationAddDto);
        }

        #endregion
        */


      
        [HttpPost]
        public async Task<IActionResult> AddAsync([FromForm] IFormFile file, [FromForm] string name)
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

            var destinationAddDto = new DestinationAddDto
            {
                Name = name,
                ImageURL = imageUrl
            };


            Response response = await _destinationManager.AddAsync(destinationAddDto);

            if (response.Success)
            {
                return Ok(response);
            }
        
            return BadRequest(response);

        }

        /*
        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, DestinationUpdateDto destinationUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _destinationManager.UpdateAsync(id, destinationUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(destinationUpdateDto);
        }
        #endregion
        */

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]int id, [FromForm] IFormFile file, [FromForm] string name)
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

            var destinationUpdateDto = new DestinationUpdateDto
            {
                Name = name,
                ImageURL = newImageUrl
            };


            Response response = await _destinationManager.UpdateAsync(id,destinationUpdateDto);

            if (response.Success)
            {
                return Ok(response);
            }

            return BadRequest(response);

        }

        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _destinationManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
