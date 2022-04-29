using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Data;
using HospitalManagementSystem.Models;

namespace HospitalManagementSystem.Controllers
{
    public class BloodListsController : Controller
    {
        private readonly HospitalManagementSystemContext _context;

        public BloodListsController(HospitalManagementSystemContext context)
        {
            _context = context;
        }

        // GET: BloodLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.BloodList.ToListAsync());
        }

        // GET: BloodLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodList = await _context.BloodList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodList == null)
            {
                return NotFound();
            }

            return View(bloodList);
        }

        // GET: BloodLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BloodGroup,BloodAvilability")] BloodList bloodList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bloodList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bloodList);
        }

        // GET: BloodLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodList = await _context.BloodList.FindAsync(id);
            if (bloodList == null)
            {
                return NotFound();
            }
            return View(bloodList);
        }

        // POST: BloodLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BloodGroup,BloodAvilability")] BloodList bloodList)
        {
            if (id != bloodList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bloodList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BloodListExists(bloodList.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bloodList);
        }

        // GET: BloodLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bloodList = await _context.BloodList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bloodList == null)
            {
                return NotFound();
            }

            return View(bloodList);
        }

        // POST: BloodLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bloodList = await _context.BloodList.FindAsync(id);
            _context.BloodList.Remove(bloodList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BloodListExists(int id)
        {
            return _context.BloodList.Any(e => e.Id == id);
        }
    }
}
