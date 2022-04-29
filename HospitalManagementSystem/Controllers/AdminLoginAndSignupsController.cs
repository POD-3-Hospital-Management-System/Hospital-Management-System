using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminLoginAndSignupsController : ControllerBase
    {
        private readonly HospitalManagementSystemContext _context;

        public AdminLoginAndSignupsController(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/AdminLoginAndSignups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminLoginAndSignup>>> GetAdminLoginAndSignup()
        {
            return await _context.AdminLoginAndSignup.ToListAsync();
        }

        // GET: api/AdminLoginAndSignups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminLoginAndSignup>> GetAdminLoginAndSignup(int id)
        {
            var adminLoginAndSignup = await _context.AdminLoginAndSignup.FindAsync(id);

            if (adminLoginAndSignup == null)
            {
                return NotFound();
            }

            return adminLoginAndSignup;
        }

        // PUT: api/AdminLoginAndSignups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminLoginAndSignup(int id, AdminLoginAndSignup adminLoginAndSignup)
        {
            if (id != adminLoginAndSignup.Id)
            {
                return BadRequest();
            }

            _context.Entry(adminLoginAndSignup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminLoginAndSignupExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AdminLoginAndSignups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminLoginAndSignup>> PostAdminLoginAndSignup(AdminLoginAndSignup adminLoginAndSignup)
        {
            _context.AdminLoginAndSignup.Add(adminLoginAndSignup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminLoginAndSignup", new { id = adminLoginAndSignup.Id }, adminLoginAndSignup);
        }

        // DELETE: api/AdminLoginAndSignups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminLoginAndSignup(int id)
        {
            var adminLoginAndSignup = await _context.AdminLoginAndSignup.FindAsync(id);
            if (adminLoginAndSignup == null)
            {
                return NotFound();
            }

            _context.AdminLoginAndSignup.Remove(adminLoginAndSignup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminLoginAndSignupExists(int id)
        {
            return _context.AdminLoginAndSignup.Any(e => e.Id == id);
        }
    }
}
