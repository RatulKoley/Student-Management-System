using SMS_Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Repo.SubjectModel
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly DataContextDB context;
        public SubjectRepository(DataContextDB context)
        {
            this.context = context;
        }
    }
}
