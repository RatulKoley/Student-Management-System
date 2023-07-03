using Microsoft.EntityFrameworkCore;
using SMS_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.DataContext.ModelBuilders
{
    public static class DataContextClass
    {
        public static ModelBuilder ClassModel(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.ToTable("classes");

                entity.Property(e => e.ClassId).HasColumnName("class_id");
                entity.Property(e => e.ClassName)
                    .HasMaxLength(20)
                    .HasColumnName("class_name");
                entity.Property(e => e.TotalSection)
                    .HasColumnName("total_section");
                entity.Property(e=>e.ClassCode).HasMaxLength(10).HasColumnName("class_code");
                entity.Property(e => e.StaffId).HasColumnName("staff_id");
                entity.Property(e => e.TotalSpaceLeft)
                    .HasColumnName("total_space_left");
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
                entity.HasOne(d => d.stafftable).WithMany(p => p.classtable)
                    .HasForeignKey(d => d.StaffId)
                    .HasConstraintName("FK_classes_staffs");

            });
        }
    }
}
