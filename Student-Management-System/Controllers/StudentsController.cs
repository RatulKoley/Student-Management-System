using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMS_Data.DataContext;
using SMS_Data.Helpers;
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

        public async Task<IActionResult> Index()
        {
            var dataContextDB = _context.students.Include(s => s.ClassTable).Where(_=>_.IsActive == true);
            return View(await dataContextDB.ToListAsync());
        }

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

        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Student student, IFormFile profilePictureFile)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                student.AdmissionDate = DateTime.Now;
                student.IsActive = true;
                student.CreatedOn = DateTime.Now;
                student.NumberOfAttendances = 0;
                if (profilePictureFile != null && profilePictureFile.Length > 0)
                {
                    student.ProfilePictureData = ImageConverter.ConvertToByteArray(profilePictureFile);
                }

                var SeatDeduct = await _context.classes.FirstOrDefaultAsync(_ => _.ClassId == student.ClassId);

                if (SeatDeduct != null)
                {
                    if (SeatDeduct.TotalSpaceLeft != 0)
                    {
                        SeatDeduct.TotalSpaceLeft = SeatDeduct.TotalSpaceLeft - 1;
                        _context.classes.Update(SeatDeduct);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        ViewBag.Message = "No Seats Available";
                        ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", student.ClassId);
                        return View(student);
                    }
                }
                else
                {
                    ViewBag.Message = "Class Discontinued";
                    ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", student.ClassId);
                    return View(student);
                }

                _context.students.Add(student);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return View(student);
            }

            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", student.ClassId);
            return RedirectToAction(nameof(Index));
        }


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
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", student.ClassId);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [FromForm] Student student, IFormFile profilePictureFile)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var updatestudent = await _context.students.FirstOrDefaultAsync(_ => _.StudentId == student.StudentId);
                if (updatestudent != null)
                {
                    updatestudent.StudentName = student.StudentName;
                    updatestudent.Email = student.Email;
                    updatestudent.Mobile = student.Mobile;
                    updatestudent.BirthDate = student.BirthDate;
                    updatestudent.GuardianName = student.GuardianName;
                    updatestudent.Age = student.Age;
                    updatestudent.Gender = student.Gender;
                    updatestudent.Religion = student.Religion;
                    updatestudent.RelationType = student.RelationType;
                    if(updatestudent.ClassId != student.ClassId)
                    {
                        var SeatDeduct = await _context.classes.FirstOrDefaultAsync(_ => _.ClassId == student.ClassId);

                        if (SeatDeduct != null)
                        {
                            if (SeatDeduct.TotalSpaceLeft != 0)
                            {
                                SeatDeduct.TotalSpaceLeft = SeatDeduct.TotalSpaceLeft - 1;
                                _context.classes.Update(SeatDeduct);
                                await _context.SaveChangesAsync();
                                var SeatAdd = await _context.classes.FirstOrDefaultAsync(_ => _.ClassId == updatestudent.ClassId);

                                if (SeatAdd != null)
                                {
                                    SeatAdd.TotalSpaceLeft = SeatAdd.TotalSpaceLeft + 1;
                                    _context.classes.Update(SeatAdd);
                                    await _context.SaveChangesAsync();
                                }
                                updatestudent.ClassId = student.ClassId;
                            }
                            else
                            {
                                ViewBag.Message = "No Seats Available";
                                ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", student.ClassId);
                                return View(student);
                            }
                        }
                    }
                    updatestudent.AdmissionDate = student.AdmissionDate;
                    updatestudent.LastAttendense = student.LastAttendense;
                    updatestudent.Address = student.Address;
                    updatestudent.City = student.City;
                    updatestudent.State = student.State;
                    updatestudent.Pincode = student.Pincode;
                    updatestudent.BirthDate = student.BirthDate;
                    updatestudent.HasMadicleCondition = student.HasMadicleCondition;
                    updatestudent.NumberOfAttendances = student.NumberOfAttendances;
                    updatestudent.AttendSchoolBefore = student.AttendSchoolBefore;
                    updatestudent.UpdatedOn = DateTime.UtcNow;
                    updatestudent.IsActive = true;
                    if (profilePictureFile != null && profilePictureFile.Length > 0)
                    {
                        student.ProfilePictureData = ImageConverter.ConvertToByteArray(profilePictureFile);
                        updatestudent.ProfilePictureData = student.ProfilePictureData;
                    }
                    _context.students.Update(updatestudent);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return View(student);
            }
            ViewData["ClassId"] = new SelectList(_context.classes, "ClassId", "ClassName", student.ClassId);
            return RedirectToAction(nameof(Index));
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var updatestudent = await _context.students.FirstOrDefaultAsync(_ => _.StudentId == id);
                if (updatestudent != null)
                {
                    updatestudent.UpdatedOn = DateTime.UtcNow;
                    updatestudent.IsActive = false;
                    _context.students.Update(updatestudent);
                    var SeatDeduct = await _context.classes.FirstOrDefaultAsync(_ => _.ClassId == updatestudent.ClassId);

                    if (SeatDeduct != null)
                    {
                            SeatDeduct.TotalSpaceLeft = SeatDeduct.TotalSpaceLeft + 1;
                            _context.classes.Update(SeatDeduct);
                            await _context.SaveChangesAsync();
                    }
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(long? id)
        {
          return (_context.students?.Any(e => e.StudentId == id)).GetValueOrDefault();
        }
    }
}
