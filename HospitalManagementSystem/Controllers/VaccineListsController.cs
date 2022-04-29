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
    public class VaccineListsController : ControllerBase
    {
        private readonly HospitalManagementSystemContext _context;

        public VaccineListsController(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        // GET: api/VaccineLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VaccineList>>> GetVaccineList()
        {
            return await _context.VaccineList.ToListAsync();
        }

        // GET: api/VaccineLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VaccineList>> GetVaccineList(int id)
        {
            var vaccineList = await _context.VaccineList.FindAsync(id);

            if (vaccineList == null)
            {
                return NotFound();
            }

            return vaccineList;
        }

        // PUT: api/VaccineLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVaccineList(int id, VaccineList vaccineList)
        {
            if (id != vaccineList.Id)
            {
                return BadRequest();
            }

            _context.Entry(vaccineList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VaccineListExists(id))
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

        // POST: api/VaccineLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VaccineList>> PostVaccineList(VaccineList vaccineList)
        {
            _context.VaccineList.Add(vaccineList);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVaccineList", new { id = vaccineList.Id }, vaccineList);
        }

        // DELETE: api/VaccineLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVaccineList(int id)
        {
            var vaccineList = await _context.VaccineList.FindAsync(id);
            if (vaccineList == null)
            {
                return NotFound();
            }

            _context.VaccineList.Remove(vaccineList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VaccineListExists(int id)
        {
            return _context.VaccineList.Any(e => e.Id == id);
        }
    }
}
