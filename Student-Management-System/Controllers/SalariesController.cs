using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS_Data.DataContext;
using SMS_Data.Models;

namespace Student_Management_System.Controllers
{
    public class SalariesController : Controller
    {
        private readonly DataContextDB _context;

        public SalariesController(DataContextDB context)
        {
            _context = context;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()
        {
              return _context.salaries != null ? 
                          View(await _context.salaries.ToListAsync()) :
                          Problem("Entity set 'DataContextDB.salaries'  is null.");
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.salaries
                .FirstOrDefaultAsync(m => m.SalaryId == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryId,TypeName,TotalAmount,TaxAmount,PFAmount,AmountPaid,PaymentDate,IsActive,CreatedBy,UpdatedBy,CreatedOn,UpdatedOn")] Salary salary)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("SalaryId,TypeName,TotalAmount,TaxAmount,PFAmount,AmountPaid,PaymentDate,IsActive,CreatedBy,UpdatedBy,CreatedOn,UpdatedOn")] Salary salary)
        {
            if (id != salary.SalaryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.SalaryId))
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
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.salaries
                .FirstOrDefaultAsync(m => m.SalaryId == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.salaries == null)
            {
                return Problem("Entity set 'DataContextDB.salaries'  is null.");
            }
            var salary = await _context.salaries.FindAsync(id);
            if (salary != null)
            {
                _context.salaries.Remove(salary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(long? id)
        {
          return (_context.salaries?.Any(e => e.SalaryId == id)).GetValueOrDefault();
        }
    }
}
