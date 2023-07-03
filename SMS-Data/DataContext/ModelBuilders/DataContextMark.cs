using Microsoft.EntityFrameworkCore;
using SMS_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.DataContext.ModelBuilders
{
    public static class DataContextMark
    {
        public static ModelBuilder MarkModel(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Mark>(entity =>
            {
                entity.HasKey(e => e.MarkId);

                entity.ToTable("marks");

                entity.Property(e => e.MarkId).HasColumnName("mark_id");
                entity.Property(e => e.StudenId).HasColumnName("student_id");
                entity.Property(e => e.ClassId).HasColumnName("class_id");
                entity.Property(e => e.SubjectId).HasColumnName("subject_id");
                entity.Property(e => e.CheckId).HasColumnName("check_id");
                entity.Property(e => e.ObtainedMarks)
                    .HasColumnName("obtain_marks");
                entity.Property(e => e.Status)
                    .HasColumnName("status");
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
                entity.HasOne(d => d.studenttable).WithMany(p => p.marktable)
                    .HasForeignKey(d => d.StudenId)
                    .HasConstraintName("FK_marks_students");
                entity.HasOne(d => d.classtable).WithMany(p => p.marktable)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_marks_classes");
                entity.HasOne(d => d.subjecttable).WithMany(p => p.marktable)
                    .HasForeignKey(d => d.SubjectId)
                    .HasConstraintName("FK_marks_subjects");
                entity.HasOne(d => d.stafftable).WithMany(p => p.marktable)
                    .HasForeignKey(d => d.CheckId)
                    .HasConstraintName("FK_marks_staffs");

            });
        }
    }
}
