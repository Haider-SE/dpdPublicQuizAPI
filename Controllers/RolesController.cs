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
        [HttpGet]
        [Route("getAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            var allRoles = await _context.Roles.ToListAsync();
            return Ok(allRoles);
        }
        [HttpPut]
        [Route("updateRole/{roleId}")]
        public async Task<IActionResult> UpdateRole(Roles request)
        {
            if (request == null)
            {
                return BadRequest("Data Cannot be null");
            }
            var existingRole = await _context.Roles.FindAsync(request.RoleID);
            if(existingRole == null)
            {
                return NotFound("The Role was not found");

            }
            existingRole.RoleName = request.RoleName;
            _context.Entry(existingRole).State = EntityState.Modified;
            _context.SaveChangesAsync();
            return Ok("Roles Detail Updated Successfully");
        }
        [HttpDelete]
        [Route("deleteRole/{roleId}")]
        public async Task<IActionResult> DeleteRole(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }
            var existingRole = await _context.Roles.FindAsync(id);
            if (existingRole == null)
            {
                return NotFound("Role Not Found");
            }
            _context.Roles.Remove(existingRole);
            await _context.SaveChangesAsync();
            return Ok("Role deleted successfully");
        }
    }
}
