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
    public class PatientRegistrationsController : ControllerBase
    {
        private readonly HospitalManagementSystemContext _context;

        public PatientRegistrationsController(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/PatientRegistrations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PatientRegistration>>> GetPatientRegistration()
        {
            return await _context.PatientRegistration.ToListAsync();
        }

        // GET: api/PatientRegistrations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PatientRegistration>> GetPatientRegistration(int id)
        {
            var patientRegistration = await _context.PatientRegistration.FindAsync(id);

            if (patientRegistration == null)
            {
                return NotFound();
            }

            return patientRegistration;
        }

        // PUT: api/PatientRegistrations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPatientRegistration(int id, PatientRegistration patientRegistration)
        {
            if (id != patientRegistration.PatientId)
            {
                return BadRequest();
            }

            _context.Entry(patientRegistration).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PatientRegistrationExists(id))
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

        // POST: api/PatientRegistrations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PatientRegistration>> PostPatientRegistration(PatientRegistration patientRegistration)
        {
            _context.PatientRegistration.Add(patientRegistration);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPatientRegistration", new { id = patientRegistration.PatientId }, patientRegistration);
        }

        // DELETE: api/PatientRegistrations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatientRegistration(int id)
        {
            var patientRegistration = await _context.PatientRegistration.FindAsync(id);
            if (patientRegistration == null)
            {
                return NotFound();
            }

            _context.PatientRegistration.Remove(patientRegistration);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PatientRegistrationExists(int id)
        {
            return _context.PatientRegistration.Any(e => e.PatientId == id);
        }
    }
}
