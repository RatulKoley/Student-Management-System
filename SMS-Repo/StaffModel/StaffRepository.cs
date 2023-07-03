using SMS_Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Repo.StaffModel
{
    public class StaffRepository : IStaffRepository
    {
        private readonly DataContextDB context;
        public StaffRepository(DataContextDB context)
        {
            this.context = context;
        }
    }
}
