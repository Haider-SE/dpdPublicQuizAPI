using dpdPublicQuizAPI.Data.ContextConfiguration;
using dpdPublicQuizAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace dpdPublicQuizAPI.Controllers
{
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public RolesController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost]
        [Route("addRole")]
        public async Task<IActionResult> AddRoles(Roles request)
        {
            if(request == null)
            {
                return BadRequest("Data Cannot be null");
            }
            _context.Roles.Add(request);
            await _context.SaveChangesAsync();
            return Ok("Role Have been added");
        } 
    }
}
