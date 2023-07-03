using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.Models
{
    public class Subject
    {
        public Subject()
        {
            marktable = new HashSet<Mark>();
        }
        [Key]
        public long? SubjectId { get;set;}
        public string? SubjectName { get;set;}
        public long? ClassId { get;set;}
        public int? TotalMarks { get;set;}
        public string? SubjectCode { get;set;}
        public string? SubjectType { get;set;}
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public virtual Class? classtable { get;set;}
        public virtual ICollection<Mark>? marktable { get;set;}

    }
}
