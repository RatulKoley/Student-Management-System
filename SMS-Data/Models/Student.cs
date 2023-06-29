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
        [Key]
        public long? StudentId { get;set;}
        public string? StudentName { get;set;}
        public string? GuardianName { get;set;}
        public string? RelationType { get;set;}
        public long? ClassId { get;set;}
        public int? Age { get;set;}
        public string? Gender { get;set;}
        public string? Religion { get;set;}
        public string? Email { get;set;}
        public string? Mobile { get;set;}
        public string? Address { get;set;}
        public string? City { get;set;}
        public string? State { get;set;}
        public string? Pincode { get;set;}
        public byte[]? ProfilePicture { get;set;}
        public DateTime? BirthDate { get;set;}
        public DateTime? AdmissionDate { get;set;}
        public DateTime? LastAttendense { get;set;}
        public int? NumberOfAttendances { get;set;}
        public bool? IsActive { get;set;}
        public bool? HasMadicleCondition { get;set;}
        public bool? AttendSchoolBefore { get;set;}
        public string? CreatedBy { get;set;}
        public string? UpdatedBy { get;set;}
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual Class? ClassTable { get;set;} 


    }
}
