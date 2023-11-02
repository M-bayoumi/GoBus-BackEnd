using GoBye.BLL.Dtos.PublicActivityDtos;
using GoBye.BLL.Dtos.QuestionDtos;
using GoBye.BLL.Managers.PublicActivityManagers;
using GoBye.BLL.Managers.QuestionManagers;
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
            IEnumerable<QuestionReadDto>? questionReadDtos = await _questionManager.GetAllAsync();

            if (questionReadDtos is not null)
            {
                return Ok(questionReadDtos);
            }

            return NotFound($"There is no Questions found");

        }
        #endregion


        #region GetByIdAsync
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            QuestionReadDto? questionReadDto = await _questionManager.GetByIdAsync(id);

            if (questionReadDto is not null)
            {
                return Ok(questionReadDto);
            }

            return NotFound($"Question with Id ({id}) not found");

        }
        #endregion
       

        #region AddAsync
        [HttpPost]
        public async Task<IActionResult> AddAsync(QuestionAddDto questionAddDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _questionManager.AddAsync(questionAddDto);

                if (result)
                {
                    return Ok("Created");
                }
            }

            return BadRequest(questionAddDto);
        }
        #endregion


        #region UpdateAsync
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, QuestionUpdateDto questionUpdateDto)
        {
            if (ModelState.IsValid)
            {
                bool result = await _questionManager.UpdateAsync(id, questionUpdateDto);

                if (result)
                {
                    return Ok("Updated");
                }
            }

            return BadRequest(questionUpdateDto);
        }
        #endregion


        #region DeleteAsync
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            bool result = await _questionManager.DeleteAsync(id);

            if (result)
            {
                return Ok("Deleted");
            }

            return NotFound($"Question with id ({id}) is not found");
        }
        #endregion
    }
}
