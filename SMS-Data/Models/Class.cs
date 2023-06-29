using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.Models
{
    public class Class
    {
        public Class()
        {
            subjecttable = new HashSet<Subject>();
            studenttable = new HashSet<Student>();
        }
        [Key]
        public long? ClassId { get;set;}
        public string? ClassName { get;set;}
        public int? TotalSection { get;set;}
        public string? ClassCode { get;set;}
        public long? StaffId { get;set;} 
        public int? TotalSpaceLeft { get;set;}
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Staff? stafftable { get;set;}
        public virtual ICollection<Subject>? subjecttable { get;set;}
        public virtual ICollection<Student>? studenttable { get;set;}
    }
}
