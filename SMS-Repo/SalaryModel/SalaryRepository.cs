using SMS_Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Repo.SalaryModel
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly DataContextDB context;
        public SalaryRepository(DataContextDB context)
        {
            this.context = context;
        }
    }
}
