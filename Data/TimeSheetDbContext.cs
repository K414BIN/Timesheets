using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Timesheets.Data.Ef.Configurations;
using Timesheets.Models;

namespace Timesheets.Data
{
    public class TimeSheetDbContext : DbContext
    {
         public DbSet<Client>  Clients {get;set;}
         public DbSet<Contract>  Contracts {get;set;}
         public DbSet<Employee>  Employees {get;set;}
         public DbSet<Sheet>   Sheets {get;set;}
         public DbSet<Service>   Services {get;set;}
         public DbSet<User>   Users {get;set;}
         public DbSet<Invoice>   Invoices {get;set;}

        public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// CODE-FIRST version 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ContractConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SheetConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
