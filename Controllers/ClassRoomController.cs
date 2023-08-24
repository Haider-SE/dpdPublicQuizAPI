using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    public class ClassRoomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public ClassRoomController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [Route("add-classRoom")]
        public async Task<IActionResult> AddClassRooms(ClassRoom request)
        {
            if (request.ClassName == null || request.ClassName == "")
            {
                return BadRequest("ClassName cannot be empty");
            }
            _context.ClassRoom.Add(request);
            await _context.SaveChangesAsync();
            return Ok("ClassRoom has been added successfully");
        }
        [HttpGet]
        [Route("getAllClassRoomes")]
        public async Task<IActionResult> GetAllClassRooms()
        {
            var allClassRooms = await _context.ClassRoom.ToListAsync();
            return Ok(allClassRooms);
        }
        [HttpPut]
        [Route("getClassRoom/{classRoomID}")]
        public async Task<IActionResult> GetClassRoom (Guid classRoomID)
        {
            var ifExist = await _context.ClassRoom.FindAsync(classRoomID);
            if (ifExist == null)
            {
                return NotFound();
            }
            return Ok(ifExist);
        }
    }
}
