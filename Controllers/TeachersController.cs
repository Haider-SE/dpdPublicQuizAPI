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
        [HttpGet]
        [Route("getAllTeachers")]
        public async Task<IActionResult> GetAllTeachers()
        {
            var allTeachers = await _context.Teachers.ToListAsync();
            return Ok(allTeachers);
        }
        [HttpPut]
        [Route("upadteTeacher/{teaccherID}")]
        public async Task<IActionResult> UpdateTeacher(Teachers request)
        {
            var existingTeacher = await _context.Teachers.FindAsync(request.Id);
            if(existingTeacher == null)
            {
                return NotFound("Teacher Details Not Found");
            }
            existingTeacher.FirstName = request.FirstName;
            existingTeacher.LastName = request.LastName;
            _context.Entry(existingTeacher).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return Ok(existingTeacher);
        }
        [HttpDelete]
        [Route("deleteTeacher/{teacherID}")]
        public async Task<IActionResult> DeleteTeacher(Guid id)
        {
            var existingTeacher = await _context.Teachers.FindAsync(id);
            if(existingTeacher == null)
            {
                return NotFound("No Such Teacher Exist");
            }
            _context.Teachers.Remove(existingTeacher);
            await _context.SaveChangesAsync();
            return Ok("Teacher Deleted Successfully");

        }
    }
}
