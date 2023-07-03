using Microsoft.EntityFrameworkCore;
using SMS_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.DataContext.ModelBuilders
{
    public static class DataContextSubject
    {
        public static ModelBuilder SubjectModel(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.SubjectId);

                entity.ToTable("subjects");

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");
                entity.Property(e => e.ClassId).HasColumnName("class_id");
                entity.Property(e => e.SubjectName)
                    .HasMaxLength(100)
                    .HasColumnName("subject_name");
                entity.Property(e => e.TotalMarks)
                    .HasColumnName("total_marks");
                entity.Property(e => e.SubjectCode).HasMaxLength(20).HasColumnName("subject_code");
                entity.Property(e => e.SubjectType).HasMaxLength(20).HasColumnName("subject_type");
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
                entity.HasOne(d => d.classtable).WithMany(p => p.subjecttable)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK_subjects_classes");

            });
        }
    }
}
