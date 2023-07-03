using Microsoft.EntityFrameworkCore;
using SMS_Data.DataContext;
using SMS_Repo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Repo.StudentModel
{
    public class StudentRepository  : IStudentRepository
    {
        private readonly DataContextDB context;
        public StudentRepository(DataContextDB context)
        {
            this.context = context;
        }
        public async Task<studentviewmodel> AddStudent(studentviewmodel objModel)
        {
            using var transaction = await context.Database.BeginTransactionAsync();
            try
            {
                var classcheck = await context.classes.FirstOrDefaultAsync(_=>_.ClassId == objModel.studentmodel.ClassId);
                if(classcheck!= null)
                {
                    objModel.studentmodel.IsActive = true;
                    objModel.studentmodel.CreatedBy = objModel.User;
                    objModel.studentmodel.CreatedOn = DateTime.UtcNow;
                    context.students.Add(objModel.studentmodel);
                    await context.SaveChangesAsync();
                    objModel.Massage = "Student Successfully Added";
                    objModel.Success = true;
                }
                else
                {
                    objModel.Massage = "Student Not Added: Invalid ClassId";
                    objModel.Success = false;
                }
              await transaction.CommitAsync();
            }
            catch(Exception ex)
            {
                objModel.Massage = "An error occurred while adding the student." + ex.ToString();
                objModel.Success = false;
                await transaction.RollbackAsync();
            }
            return objModel;
        }
    }
}
