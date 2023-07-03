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
    public class ClassesController : Controller
    {
        private readonly DataContextDB _context;

        public ClassesController(DataContextDB context)
        {
            _context = context;
        }

        // GET: Classes
        public async Task<IActionResult> Index()
        {
            var dataContextDB = _context.classes.Include(_=>_.stafftable);
            return View(await dataContextDB.ToListAsync());
        }

        // GET: Classes/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes
                .Include(_ => _.stafftable)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // GET: Classes/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.staffs, "StaffId", "StaffId");
            return View();
        }

        // POST: Classes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassId,ClassName,TotalSection,ClassCode,StaffId,TotalSpaceLeft,IsActive,CreatedBy,UpdatedBy,CreatedOn,UpdatedOn")] Class @class)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@class);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.staffs, "StaffId", "StaffId", @class.StaffId);
            return View(@class);
        }

        // GET: Classes/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes.FindAsync(id);
            if (@class == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.staffs, "StaffId", "StaffId", @class.StaffId);
            return View(@class);
        }

        // POST: Classes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("ClassId,ClassName,TotalSection,ClassCode,StaffId,TotalSpaceLeft,IsActive,CreatedBy,UpdatedBy,CreatedOn,UpdatedOn")] Class @class)
        {
            if (id != @class.ClassId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@class);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassExists(@class.ClassId))
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
            ViewData["StaffId"] = new SelectList(_context.staffs, "StaffId", "StaffId", @class.StaffId);
            return View(@class);
        }

        // GET: Classes/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.classes == null)
            {
                return NotFound();
            }

            var @class = await _context.classes
                .Include(_ => _.stafftable)
                .FirstOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            return View(@class);
        }

        // POST: Classes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.classes == null)
            {
                return Problem("Entity set 'DataContextDB.classes'  is null.");
            }
            var @class = await _context.classes.FindAsync(id);
            if (@class != null)
            {
                _context.classes.Remove(@class);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassExists(long? id)
        {
          return (_context.classes?.Any(e => e.ClassId == id)).GetValueOrDefault();
        }
    }
}
