using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMS_Data.DataContext
{
    public class DataContextFactory
    {
        public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<DataContextDB>
        {
            public DataContextDB CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DataContextDB>();
                optionsBuilder.UseSqlServer("Server=BYOMKESH\\SQLEXPRESS;Database=StudentManagement;Integrated Security = true;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate = True");
                return new DataContextDB(optionsBuilder.Options);
            }
        }
    }
}
