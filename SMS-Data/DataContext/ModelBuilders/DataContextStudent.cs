using Microsoft.EntityFrameworkCore;
using SMS_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.DataContext.ModelBuilders
{
    public static class DataContextStudent
    {
        public static ModelBuilder StudentModel(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudentId);

                entity.ToTable("students");

                entity.Property(e => e.StudentId).HasColumnName("student_id");
                entity.Property(e => e.ClassId).HasColumnName("class_id");
                entity.Property(e => e.StudentName)
                    .HasMaxLength(100)
                    .HasColumnName("student_name");
                entity.Property(e => e.GuardianName)
                    .HasMaxLength(100)
                    .HasColumnName("guardian_name");
                entity.Property(e => e.RelationType)
                    .HasMaxLength(100)
                    .HasColumnName("relation_type");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");
                entity.Property(e => e.Mobile)
                    .HasMaxLength(10)
                    .HasColumnName("mobile");
                entity.Property(e => e.Age)
                    .HasMaxLength(20)
                    .HasColumnName("age");
                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .HasColumnName("gender");
                entity.Property(e => e.Religion)
                    .HasMaxLength(20)
                    .HasColumnName("religion");
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
                entity.Ignore(e => e.ProfilePicture);
                entity.Property(e => e.ProfilePictureData)
                      .HasColumnName("ProfilePicture")
                      .HasColumnType("varbinary(MAX)");
                entity.Property(e => e.AdmissionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("admission_date");
                entity.Property(e => e.BirthDate)
                    .HasColumnType("datetime")
                    .HasColumnName("birth_date");
                entity.Property(e => e.LastAttendense)
                    .HasColumnType("datetime")
                    .HasColumnName("last_attendence_date");
                entity.Property(e => e.NumberOfAttendances)
                    .HasColumnName("number_of_attendences");
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.HasMadicleCondition).HasColumnName("has_medical_condition");
                entity.Property(e => e.AttendSchoolBefore).HasColumnName("attend_school_before");
                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
                entity.HasOne(d => d.ClassTable).WithMany(p => p.studenttable)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_students_classes");

            });
        }
    }
}
