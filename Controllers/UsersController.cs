using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    [EnableCors("_myAllowAnyOrigin")]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;

        public UsersController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        [Route("addUser")]
        public async Task<IActionResult> AddUser(Users request)
        {
            //only For Admin
            if(request == null)
            {
                return BadRequest("Data Cannot be null");
            }
            request.Password = "123456";
            _context.Users.Add(request);
            await _context.SaveChangesAsync();
            return Ok("User Have been added");
        }
        [HttpGet]
        [Route("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _context.Users.ToListAsync();
            return Ok(allUsers);
        }
        [HttpPut]
        [Route("updateUser/{userID}")]
        public async Task<IActionResult> UpdateUser (Users request)
        {
            var existingUser = await _context.Users.FindAsync(request.Id);
            if(existingUser == null)
            {
                return NotFound("User Details not found");
            }
            existingUser.FirstName = request.FirstName;
            existingUser.LastName = request.LastName;
            _context.Entry(existingUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok("User Details Updated Successfully");
        }
        [HttpDelete]
        [Route("deleteUser/{userID}")]
        public async Task<IActionResult> DeleteUser (Guid id)
        {
            var existingUser = _context.Users.Find(id);
            if(existingUser == null)
            {
                return NotFound("User Not Found");
            }
            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return Ok("User Deleted Successfully");
        }
    }
}
