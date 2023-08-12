using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    public class QuestionsTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public QuestionsTypeController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("add/questionType")]
        public async Task<IActionResult> AddQuestionType(QuestionsType request)
        {
            // Find the user with the provided username
            var typeAlreadyExist = await _context.QuestionType.FirstOrDefaultAsync(q => q.Type == request.Type);

            if (typeAlreadyExist != null)
            {
                return BadRequest("It Already Exist");
            }

            _context.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Question Type added successfully.");

        }
        [HttpGet]
        [Route("all-question-types")]
        public async Task<IActionResult> GetAllQuestionTypes()
        {
            var questionTypes = await _context.QuestionType.ToListAsync();
            return Ok(questionTypes);
        }
        [HttpGet]
        [Route("getQuestionType/{questionId}")]
        public async Task<IActionResult> GetQuestionTypeDetail (Guid questionId)
        {
            var getQuestionDetail = await _context.QuestionType.FindAsync(questionId);
            if (getQuestionDetail == null)
            {
                return NotFound(); // Return a 404 response if the question is not found
            }
            return Ok(getQuestionDetail);
            Console.Read();
        }

        [HttpPut]
        [Route("updateQuestionType/{questionId}")]
        public async Task<IActionResult> UpdateQuestionTypeDetail (QuestionsType updatedQuestionType)
        {
            var questionId = updatedQuestionType.Id;
            var existingQuestionType = await _context.QuestionType.FindAsync(questionId);
            if(existingQuestionType == null)
            {
                return NotFound();
            }

            existingQuestionType.Type = updatedQuestionType.Type;
            _context.Entry(existingQuestionType).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return Ok(existingQuestionType);
            }
            catch (DbUpdateConcurrencyException)
            {
                // Handle concurrency exception if needed
                return StatusCode(500); // Internal Server Error
            }
        }
        [HttpDelete]
        [Route("deleteQuestionType{questionId}")]
        public async Task<IActionResult> DeleteQuestionType (Guid questionId)
        {
            var existingQuestionType = await _context.QuestionType.FindAsync(questionId);
            if (existingQuestionType == null)
            {
                return NotFound("No such type exists");
            }

            _context.QuestionType.Remove(existingQuestionType);
            await _context.SaveChangesAsync();

            return Ok("Question type deleted successfully");
        }


    }
}
