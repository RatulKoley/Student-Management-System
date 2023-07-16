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
    public class StaffsController : Controller
    {
        private readonly DataContextDB _context;

        public StaffsController(DataContextDB context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataContextDB = _context.staffs.Include(s => s.salarytable);
            return View(await dataContextDB.ToListAsync());
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.staffs == null)
            {
                return NotFound();
            }

            var staff = await _context.staffs
                .Include(s => s.salarytable)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        public IActionResult Create()
        {
            ViewData["SalaryId"] = new SelectList(_context.salaries, "SalaryId", "TypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] Staff staff, IFormFile profilePictureFile)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                staff.JoinedDate = DateTime.Now;
                staff.IsActive = true;
                staff.CreatedOn = DateTime.Now;
                if (profilePictureFile != null && profilePictureFile.Length > 0)
                    {
                        staff.ProfilePictureData = ImageConverter.ConvertToByteArray(profilePictureFile);
                    }
                _context.staffs.Add(staff);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                await transaction.RollbackAsync();
                return View(staff);
            }
            ViewData["SalaryId"] = new SelectList(_context.salaries, "SalaryId", "TypeName", staff.SalaryId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.staffs == null)
            {
                return NotFound();
            }

            var staff = await _context.staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            ViewData["SalaryId"] = new SelectList(_context.salaries, "SalaryId", "TypeName", staff.SalaryId);
            return View(staff);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [FromForm] Staff staff, IFormFile profilePictureFile)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var updatestaff = await _context.staffs.FirstOrDefaultAsync(_=>_.StaffId == staff.StaffId);
                if(updatestaff!= null)
                {
                    updatestaff.StaffName = staff.StaffName;
                    updatestaff.Email = staff.Email;
                    updatestaff.Mobile = staff.Mobile;
                    updatestaff.BirthDate = staff.BirthDate;
                    updatestaff.SalaryId = staff.SalaryId;
                    updatestaff.Age = staff.Age;
                    updatestaff.Gender = staff.Gender;
                    updatestaff.Religion = staff.Religion;
                    updatestaff.Designation = staff.Designation;
                    updatestaff.SubjectSpeciality = staff.SubjectSpeciality;
                    updatestaff.Qualification = staff.Qualification;
                    updatestaff.EmployeeType = staff.EmployeeType;
                    updatestaff.Address = staff.Address;
                    updatestaff.City = staff.City;
                    updatestaff.State = staff.State;
                    updatestaff.Pincode = staff.Pincode;
                    updatestaff.JoinedDate = staff.JoinedDate;
                    updatestaff.HasMadicleCondition = staff.HasMadicleCondition;
                    updatestaff.PreviousExperience = staff.PreviousExperience;
                    updatestaff.UpdatedOn = DateTime.UtcNow;
                    updatestaff.IsActive = true;
                    if (profilePictureFile != null && profilePictureFile.Length > 0)
                    {
                        staff.ProfilePictureData = ImageConverter.ConvertToByteArray(profilePictureFile);
                        updatestaff.ProfilePictureData = staff.ProfilePictureData;
                    }
                    _context.staffs.Update(updatestaff);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception ex)
             {
                 await transaction.RollbackAsync();
                 return View(staff);
             }
            ViewData["SalaryId"] = new SelectList(_context.salaries, "SalaryId", "TypeName", staff.SalaryId);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.staffs == null)
            {
                return NotFound();
            }

            var staff = await _context.staffs
                .Include(s => s.salarytable)
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var updatestaff = await _context.staffs.FirstOrDefaultAsync(_ => _.StaffId == id);
                if (updatestaff != null)
                {
                    updatestaff.UpdatedOn = DateTime.UtcNow;
                    updatestaff.IsActive = false;
                    _context.staffs.Update(updatestaff);
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

        private bool StaffExists(long? id)
        {
          return (_context.staffs?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
    }
}
