using GoBye.BLL.Dtos.DestinationDtos;
using GoBye.BLL.Dtos.PublicActivityDtos;
using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.BLL.Managers.PublicActivityManagers;
using GoBye.BLL.Managers.QuestionManagers;
using GoBye.DAL.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoBye.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionManager _questionManager;

        public QuestionsController(IQuestionManager questionManager)
        {
            _questionManager = questionManager;
        }


        #region GetAllAsync
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            Response response = await _questionManager.GetAllAsync();

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
            Response response = await _questionManager.GetByIdAsync(id);

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
        public async Task<IActionResult> AddAsync(QuestionAddDto questionAddDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _questionManager.AddAsync(questionAddDto);

                if (response.Success)

                    return Ok(response);
            }

            return BadRequest(questionAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> UpdateAsync(int id, QuestionUpdateDto questionUpdateDto)
        {
            if (ModelState.IsValid)
            {
                Response response = await _questionManager.UpdateAsync(id, questionUpdateDto);

                if (response.Success)
                {
                    return Ok(response);
                }
                return BadRequest(response);

            }

            return BadRequest(questionUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        [Authorize(Policy = "ForAdmin")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            Response response = await _questionManager.DeleteAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }

            return NotFound(response);
        }
        #endregion
    }
}
