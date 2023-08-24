using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public QuestionsController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context; 
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addquestion")]
        public async Task<IActionResult> AddQuestions(Questions request)
        {
            if(request.QuestionText == null || request.QuestionText == "")
            {
                return BadRequest("Question Cannot be empty");
            }
            _context.Questions.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Question Added Succesfully");
        }
        [HttpGet]
        [Route("getAllQuestions")]
        public async Task<IActionResult> GetAllQuestions()
        {
            var allQuestions = await _context.Questions.ToListAsync();
            return Ok(allQuestions);
        }
        [HttpGet]
        [Route("getQuestion/{questionId}")]
        public async Task<IActionResult> GetQuestion(Guid questionId)
        {
            var question = await _context.Questions.FindAsync(questionId);
            if(question == null)
            {
                return NotFound("Question Does not Exist");
            }
            return Ok(question);
        }

        [HttpPut]
        [Route("upadteQuestion/{questionId}")]
        public async Task<IActionResult> UpdateQuestion(Questions question)
        {
            var existingQuestion = await _context.Questions.FindAsync(question);
            if(existingQuestion == null)
            {
                return NotFound("Question Does not Exist");
            }
            existingQuestion.QuestionText = question.QuestionText;
            _context.Entry(existingQuestion).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(existingQuestion);
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500);
            }
        }
        [HttpDelete]
        [Route("deleteQuestion/{questionId}")]
        public async Task<IActionResult> DeleteQuestion(Guid questionId)
        {
            var existingQuestion = await _context.Questions.FindAsync(questionId);
            if(existingQuestion == null)
            {
                return NotFound("No such Question Exists");
            }
            _context.Questions.Remove(existingQuestion);
            await _context.SaveChangesAsync();
            return Ok("Question Deleted Successfully");
        }

    }
}
