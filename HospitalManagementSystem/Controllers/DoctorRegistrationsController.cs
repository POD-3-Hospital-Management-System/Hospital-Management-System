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
    public class DoctorRegistrationsController : ControllerBase
    {
        private readonly HospitalManagementSystemContext _context;

        public DoctorRegistrationsController(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/DoctorRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorRegistration>>> GetDoctorRegistration()
        {
            return await _context.DoctorRegistration.ToListAsync();
        }

        // GET: api/DoctorRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorRegistration>> GetDoctorRegistration(int id)
        {
            var doctorRegistration = await _context.DoctorRegistration.FindAsync(id);

            if (doctorRegistration == null)
            {
                return NotFound();
            }

            return doctorRegistration;
        }

        // PUT: api/DoctorRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorRegistration(int id, DoctorRegistration doctorRegistration)
        {
            if (id != doctorRegistration.DoctorId)
            {
                return BadRequest();
            }

            _context.Entry(doctorRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorRegistrationExists(id))
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

        // POST: api/DoctorRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorRegistration>> PostDoctorRegistration(DoctorRegistration doctorRegistration)
        {
            _context.DoctorRegistration.Add(doctorRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorRegistration", new { id = doctorRegistration.DoctorId }, doctorRegistration);
        }

        // DELETE: api/DoctorRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorRegistration(int id)
        {
            var doctorRegistration = await _context.DoctorRegistration.FindAsync(id);
            if (doctorRegistration == null)
            {
                return NotFound();
            }

            _context.DoctorRegistration.Remove(doctorRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorRegistrationExists(int id)
        {
            return _context.DoctorRegistration.Any(e => e.DoctorId == id);
        }
    }
}
