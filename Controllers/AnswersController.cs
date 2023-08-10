using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    [Route("add/answer")]
    public class AnswersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AnswersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> AddAnswers(Answers request)
        {
            if (request.AnswerText == null || request.AnswerText == "")
            {
                return BadRequest("Answer Cannot be Empty");
            }
            _context.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Answer Added Successfully");
        }
    }
}

