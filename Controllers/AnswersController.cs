using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public AnswersController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        //In case of MCQs only
        [HttpPost]
        [Route("add/answer/questionID")]
        public async Task<IActionResult> AddAnswersOptions(Answers request)
        {
            //teacher can add answer options for an MCQ
            //if (request.AnswerText == null || request.AnswerText == "")
            //{
            //    return BadRequest("Answer Cannot be Empty");
            //}
            _context.Answers.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Answer Added Successfully");
        }
        [HttpGet]
        [Route("getAllAnswers/questionId")]
        public async Task<IActionResult> GetAllAnswersOptions(Questions request)
        {
            var allAnswers = _context.Answers.Where(q => q.QuestionID == request.Id);
            return Ok(allAnswers);
        }
    }
}

