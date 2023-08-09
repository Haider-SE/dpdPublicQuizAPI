using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    [Route("add/questionType")]
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

    }
}
