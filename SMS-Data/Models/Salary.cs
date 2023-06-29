using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.Models
{
    public class Salary
    {
        public Salary()
        {
            stafftable = new HashSet<Staff>();
        }
        [Key]
        public long? SalaryId { get;set;}
        public string? TypeName { get;set;}
        public double? TotalAmount { get;set;}
        public double? TaxAmount { get; set; }
        public double? PFAmount { get; set; }
        public double? AmountPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public bool? IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public virtual ICollection<Staff>? stafftable { get;set;}

    }
}
