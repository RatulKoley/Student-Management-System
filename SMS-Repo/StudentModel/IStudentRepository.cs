using SMS_Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Repo.StudentModel
{
    public interface IStudentRepository
    {
        public Task<studentviewmodel> AddStudent(studentviewmodel objModel);
    }
}
