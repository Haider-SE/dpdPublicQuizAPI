using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    [Route("add/question")]

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
        public async Task<IActionResult> AddQuestions(Questions request)
        {
            if(request.QuestionText == null || request.QuestionText == "")
            {
                return BadRequest("Question Cannot be empty");
            }
            _context.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Question Added Succesfully");
        }
    }
}
