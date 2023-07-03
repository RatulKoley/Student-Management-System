using Microsoft.AspNetCore.Http;
using SMS_Data.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.Models
{
    public class Staff 
    {
        public Staff()
        {
            marktable = new HashSet<Mark>();
            classtable = new HashSet<Class>();
        }
        [Key]
        public long? StaffId { get;set;}
        public long? SalaryId { get;set;}
        [Required(ErrorMessage = "Staff Name is required")]
        public string? StaffName { get;set;}
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get;set;}
        [Required(ErrorMessage = "Mobile is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid mobile number")]
        public string? Mobile { get;set;}
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*\W).{8,}$", 
            ErrorMessage = "Enter Min. 8 Characters Long With Lowercase, Uppercase, Digits & Special Characters")]
        public string? Password { get;set;}
        [Required(ErrorMessage = "Age is required")]
        [Range(0, 70, ErrorMessage = "Age must be between 0 and 70.")]
        public int? Age { get; set; }
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get;set;}
        public string? Religion { get;set;}
        [Required(ErrorMessage = "Designation is required")]
        public string? Designation { get; set; }
        [Required(ErrorMessage = "Speciality is required")]
        public string? SubjectSpeciality { get;set;}
        [Required(ErrorMessage = "Qualification is required")]
        public string? Qualification { get;set;}
        [Required(ErrorMessage = "Employee Type is required")]
        public string? EmployeeType { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string? City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string? State { get; set; }
        public string? Pincode { get; set; }
        public IFormFile? ProfilePicture { get; set; }
        public byte[]? ProfilePictureData { get; set; }
        public DateTime? JoinedDate { get; set; }
        [Required(ErrorMessage = "Birth Date is required")]
        public DateTime? BirthDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool? IsActive { get; set; }
        public bool HasMadicleCondition { get; set; }
        public string? PreviousExperience { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Class> classtable { get;set;}
        public virtual ICollection<Mark> marktable { get;set;}
        public virtual Salary? salarytable { get;set;}
    }
}
