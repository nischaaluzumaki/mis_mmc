#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mis_mmc.Models;

namespace mis_mmc.Controllers
{
    public class CollegeDetailsController : Controller
    {
        private readonly DataContext _context;

        public CollegeDetailsController(DataContext context)
        {
            _context = context;
        }

        // GET: CollegeDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeDetails.ToListAsync());
        }

        // GET: CollegeDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeDetails = await _context.CollegeDetails
                .FirstOrDefaultAsync(m => m.s_no == id);
            if (collegeDetails == null)
            {
                return NotFound();
            }

            return View(collegeDetails);
        }

        // GET: CollegeDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollegeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("s_no,college_name,phone_number_one,email,logo,address")] CollegeDetails collegeDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collegeDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            return View(collegeDetails);
        }

        // GET: CollegeDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeDetails = await _context.CollegeDetails.FindAsync(id);
            if (collegeDetails == null)
            {
                return NotFound();
            }
            return View(collegeDetails);
        }

        // POST: CollegeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("s_no,college_name,phone_number_one,email,logo,address")] CollegeDetails collegeDetails)
        {
            if (id != collegeDetails.s_no)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collegeDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeDetailsExists(collegeDetails.s_no))
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
            return View(collegeDetails);
        }

        // GET: CollegeDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeDetails = await _context.CollegeDetails
                .FirstOrDefaultAsync(m => m.s_no == id);
            if (collegeDetails == null)
            {
                return NotFound();
            }

            return View(collegeDetails);
        }

        // POST: CollegeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collegeDetails = await _context.CollegeDetails.FindAsync(id);
            _context.CollegeDetails.Remove(collegeDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeDetailsExists(int id)
        {
            return _context.CollegeDetails.Any(e => e.s_no == id);
        }
    }
}
