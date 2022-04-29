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
    public class DoctorListsController : ControllerBase
    {
        private readonly HospitalManagementSystemContext _context;

        public DoctorListsController(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/DoctorLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorList>>> GetDoctorList()
        {
            return await _context.DoctorList.ToListAsync();
        }

        // GET: api/DoctorLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorList>> GetDoctorList(int id)
        {
            var doctorList = await _context.DoctorList.FindAsync(id);

            if (doctorList == null)
            {
                return NotFound();
            }

            return doctorList;
        }

        // PUT: api/DoctorLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDoctorList(int id, DoctorList doctorList)
        {
            if (id != doctorList.Id)
            {
                return BadRequest();
            }

            _context.Entry(doctorList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoctorListExists(id))
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

        // POST: api/DoctorLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DoctorList>> PostDoctorList(DoctorList doctorList)
        {
            _context.DoctorList.Add(doctorList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDoctorList", new { id = doctorList.Id }, doctorList);
        }

        // DELETE: api/DoctorLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorList(int id)
        {
            var doctorList = await _context.DoctorList.FindAsync(id);
            if (doctorList == null)
            {
                return NotFound();
            }

            _context.DoctorList.Remove(doctorList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DoctorListExists(int id)
        {
            return _context.DoctorList.Any(e => e.Id == id);
        }
    }
}
