using Microsoft.EntityFrameworkCore;
using SMS_Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS_Data.DataContext.ModelBuilders
{
    public static class DataContextSalary
    {
        public static ModelBuilder SalaryModel(ModelBuilder modelBuilder)
        {
            return modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasKey(e => e.SalaryId);

                entity.ToTable("salaries");

                entity.Property(e => e.SalaryId).HasColumnName("salary_id");
                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .HasColumnName("type_name");
                entity.Property(e => e.TotalAmount)
                    .HasColumnName("total_amount");
                entity.Property(e => e.TaxAmount)
                    .HasColumnName("tax_amount");
                entity.Property(e => e.PFAmount)
                    .HasColumnName("pf_amount");
                entity.Property(e => e.AmountPaid)
                    .HasColumnName("amount_paid");
                entity.Property(e => e.PaymentDate)
                   .HasColumnType("datetime")
                   .HasColumnName("payment_date");
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("created_on");
                entity.Property(e => e.IsActive).HasColumnName("is_active");
                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_on");
            });
        }
    }
}
