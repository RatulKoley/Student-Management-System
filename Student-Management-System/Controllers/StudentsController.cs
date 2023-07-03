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
    public class StudentsController : Controller
    {
        private readonly DataContextDB _context;

        public StudentsController(DataContextDB context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            var dataContextDB = _context.students.Include(s => s.ClassTable);
            return View(await dataContextDB.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .Include(s => s.ClassTable)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassId");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,GuardianName,RelationType,ClassId,Age,Gender,Religion,Email,Mobile,Address,City,State,Pincode,ProfilePicture,BirthDate,AdmissionDate,LastAttendense,NumberOfAttendances,IsActive,HasMadicleCondition,AttendSchoolBefore,CreatedBy,UpdatedBy,CreatedOn,UpdatedOn")] Student student)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                if (ModelState.IsValid)
                {
                    var classcheck = await _context.classes.FirstOrDefaultAsync(_ => _.ClassId == student.ClassId);
                    if (classcheck != null)
                    {
                        student.IsActive = true;
                        student.CreatedOn = DateTime.UtcNow;
                        _context.Add(student);
                        await _context.SaveChangesAsync();
                    }
                }
                ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassId", student.ClassId);
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                return View(student);
            }
            return RedirectToAction("Index", "Students");
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassId", student.ClassId);
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("StudentId,StudentName,GuardianName,RelationType,ClassId,Age,Gender,Religion,Email,Mobile,Address,City,State,Pincode,ProfilePicture,BirthDate,AdmissionDate,LastAttendense,NumberOfAttendances,IsActive,HasMadicleCondition,AttendSchoolBefore,CreatedBy,UpdatedBy,CreatedOn,UpdatedOn")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassId", student.ClassId);
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .Include(s => s.ClassTable)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.students == null)
            {
                return Problem("Entity set 'DataContextDB.students'  is null.");
            }
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                _context.students.Remove(student);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(long? id)
        {
          return (_context.students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
