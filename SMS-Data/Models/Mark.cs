using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.Models
{
    public class Mark
    {
        [Key]
        public long? MarkId { get;set;}
        public long? StudenId { get;set;}
        public long? ClassId { get;set;}
        public long? SubjectId { get;set;}
        public long? CheckId { get; set; }
        public double? ObtainedMarks { get;set;}
        public bool? Status { get;set;}
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual Student? studenttable { get;set;}
        public virtual Class? classtable { get;set;}
        public virtual Subject? subjecttable { get;set;}
        public virtual Staff? stafftable { get;set;}
    }
}
