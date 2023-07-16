using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.Models
{
    public class Student
    {
        public Student()
        {
            marktable = new HashSet<Mark>();
        }
        [Key]
        public long? StudentId { get;set;}
        [Required(ErrorMessage = "Student Name is required")]
        public string? StudentName { get;set;}
        [Required(ErrorMessage = "Guardian Name is required")]
        public string? GuardianName { get;set;}
        [Required(ErrorMessage = "Relationship Status is required")]
        public string? RelationType { get;set;}
        [Required(ErrorMessage = "Class is required")]
        public long? ClassId { get;set;}
        [Required(ErrorMessage = "Age is required")]
        [Range(0, 20, ErrorMessage = "Age must be between 0 and 20.")]
        public int? Age { get;set;}
        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get;set;}
        [Required(ErrorMessage = "Religion is required")]
        public string? Religion { get;set;}
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get;set;}
        [Required(ErrorMessage = "Mobile is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid mobile number")]
        public string? Mobile { get;set;}
        [Required(ErrorMessage = "Address is required")]
        public string? Address { get;set;}
        [Required(ErrorMessage = "City is required")]
        public string? City { get;set;}
        [Required(ErrorMessage = "State is required")]
        public string? State { get;set;}
        [Required(ErrorMessage = "Pincode is required")]
        public string? Pincode { get;set;}
        public IFormFile? ProfilePicture { get; set; }
        public byte[]? ProfilePictureData { get; set; }
        [Required(ErrorMessage = "BirthDate is required")]
        public DateTime? BirthDate { get;set;}
        public DateTime? AdmissionDate { get;set;}
        public DateTime? LastAttendense { get;set;}
        public int? NumberOfAttendances { get;set;}
        public bool? IsActive { get;set;}
        public bool HasMadicleCondition { get;set;}
        public bool AttendSchoolBefore { get;set;}
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual Class? ClassTable { get;set;}
        public virtual ICollection<Mark>? marktable { get; set; }


    }
}
