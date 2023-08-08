using System;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    [Route("questionType")]
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
        public async Task<IActionResult> AddQuestionType(QuestionTypeRequest request)
        {
            // Find the user with the provided username
            var type = await _context.QuestionType.FirstOrDefaultAsync(q => q.Type == request.Type);

            if (type == null)
            {
                return BadRequest("Invalid Type");
            }

            var response = new QuestionTypeResponse
            {
                Id = type.Id,
                Type = type.Type,
            };
            _context.Add(response);
            await _context.SaveChangesAsync();
            return Ok("Tech skill added successfully.");

        }

        public class QuestionTypeRequest
        {
            public string Type { get; set; }
        }
        public class QuestionTypeResponse
        {
            public Guid Id { get; set; }
            public string Type { get; set; }
        }
    }
}
