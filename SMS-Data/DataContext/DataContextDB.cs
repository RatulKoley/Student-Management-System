using Microsoft.EntityFrameworkCore;
using SMS_Data.DataContext.ModelBuilders;
using SMS_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.DataContext
{
    public class DataContextDB : DbContext
    {
        public DataContextDB(DbContextOptions<DataContextDB> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataContextClass.ClassModel(modelBuilder);
            DataContextMark.MarkModel(modelBuilder);
            DataContextSalary.SalaryModel(modelBuilder);
            DataContextStaff.StaffModel(modelBuilder);
            DataContextStudent.StudentModel(modelBuilder);
            DataContextSubject.SubjectModel(modelBuilder);
        }

        public DbSet<Class> classes { get; set; }
        public DbSet<Mark> marks { get; set; }
        public DbSet<Salary> salaries { get; set; }
        public DbSet<Staff> staffs { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Subject> subjects { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=BYOMKESH\\SQLEXPRESS;Initial Catalog=StudentManagement;Integrated Security = true; TrustServerCertificate=True");
            }
        }
    }
}
