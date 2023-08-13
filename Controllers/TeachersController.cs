using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public TeachersController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        [Route("addTeacher")]
        public async Task<IActionResult> AddTeacher (Teachers request)
        {
            if(request.FirstName == null || request.LastName == null)
            {
                return BadRequest("First Name or Last Name cannot be empty");
            }
            var addTeacher = await _context.Teachers.AddAsync(request);
            return Ok(addTeacher);
        }

    }
}
