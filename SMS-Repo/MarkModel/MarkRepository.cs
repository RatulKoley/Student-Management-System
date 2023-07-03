using SMS_Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Repo.MarkModel
{
    public class MarkRepository : IMarkRepository
    {
        private readonly DataContextDB context;
        public MarkRepository(DataContextDB context)
        {
            this.context = context;
        }
    }
}
