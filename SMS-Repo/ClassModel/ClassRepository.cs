using SMS_Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Repo.ClassModel
{
    public class ClassRepository : IClassRepository
    {
        private readonly DataContextDB context;
        public ClassRepository(DataContextDB context)
        {
            this.context = context;
        }
    }
}
