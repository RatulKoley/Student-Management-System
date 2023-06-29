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
        public string? StaffName { get;set;}
        public string? Email { get;set;}
        public string? Mobile { get;set;}
        public string? Password { get;set;}
        public string? Gender { get;set;}
        public string? Designation { get; set; }
        public string? SubjectSpeciality { get;set;}
        public string? Qualification { get;set;}
        public string? EmployeeType { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Pincode { get; set; }
        public byte[]? ProfilePicture { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastPasswordChange { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? HasMadicleCondition { get; set; }
        public bool? AttendSchoolBefore { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Class> classtable { get;set;}
        public virtual ICollection<Mark> marktable { get;set;}
        public virtual Salary? salarytable { get;set;}
    }
}
