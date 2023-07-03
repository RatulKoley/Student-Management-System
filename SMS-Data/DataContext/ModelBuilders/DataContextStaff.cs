using Microsoft.EntityFrameworkCore;
using SMS_Data.Helpers;
using SMS_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.DataContext.ModelBuilders
{
    public static class DataContextStaff
    {
        public static ModelBuilder StaffModel(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Staff>(entity =>
            {
                entity.HasKey(e => e.StaffId);

                entity.ToTable("staffs");

                entity.Property(e => e.StaffId).HasColumnName("staff_id");
                entity.Property(e => e.SalaryId).HasColumnName("salary_id");
                entity.Property(e => e.StaffName)
                    .HasMaxLength(100)
                    .HasColumnName("staff_name");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .HasColumnName("mobile");
                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");
                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .HasColumnName("gender");
                entity.Property(e => e.Age)
                    .HasColumnName("age");
                entity.Property(e => e.Religion)
                    .HasMaxLength(20)
                    .HasColumnName("religion");
                entity.Property(e => e.Designation)
                    .HasMaxLength(50)
                    .HasColumnName("designation");
                entity.Property(e => e.SubjectSpeciality)
                    .HasMaxLength(200)
                    .HasColumnName("subject_speciality");
                entity.Property(e => e.Qualification)
                    .HasMaxLength(100)
                    .HasColumnName("qualification");
                entity.Property(e => e.EmployeeType)
                    .HasMaxLength(100)
                    .HasColumnName("employee_type");
                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .HasColumnName("address");
                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .HasColumnName("city");
                entity.Property(e => e.State)
                    .HasMaxLength(100)
                    .HasColumnName("state");
                entity.Property(e => e.Pincode)
                    .HasMaxLength(10)
                    .HasColumnName("pincode");
                entity.Ignore(s => s.ProfilePicture);
                entity.Property(s => s.ProfilePictureData)
                      .HasColumnName("ProfilePicture")
                      .HasColumnType("varbinary(MAX)");
                entity.Property(e => e.JoinedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("joined_date");
                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birth_date");
                entity.Property(e => e.ReleaseDate)
                    .HasColumnType("datetime")
                    .HasColumnName("release_date");
                entity.Property(e => e.PreviousExperience)
                    .HasMaxLength(300)
                    .HasColumnName("previous_experience");
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.HasMadicleCondition).HasColumnName("has_medical_condition");
                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
                entity.HasOne(d => d.salarytable).WithMany(p => p.stafftable)
                    .HasForeignKey(d => d.SalaryId)
                    .HasConstraintName("FK_staffs_salaries");

            });
        }
    }
}
