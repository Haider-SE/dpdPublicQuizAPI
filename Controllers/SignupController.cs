using Microsoft.AspNetCore.Mvc;
using dpdPublicQuizAPI.Models;
using dpdPublicQuizAPI.Data.ContextConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    [Route("teacher-Signup")]
    public class SignupController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public SignupController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> TeacherSignup(Users model)
        {
            // TODO: Implement signup logic using model data
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == model.UserName);
            if (existingUser != null)
            {
                return BadRequest("Username is already taken, please select another one");
            }
            var teacher = new Users
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                RoleId = model.RoleId,
            };

            var addedTeacher = await _context.Users.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return Ok(addedTeacher);
        }
    }
}
