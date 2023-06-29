using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.Models
{
    public class Mark
    {
        public long? MarkId { get;set;}
        public long? StudenId { get;set;}
        public long? ClassId { get;set;}
        public long? SubjectId { get;set;}
        public double? ObtainedMarks { get;set;}

    }
}
