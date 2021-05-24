using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public TimeSheetDbContext(DbContextOptions<TimeSheetDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// CODE-FIRST version 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("clients");
            modelBuilder.Entity<Contract>().ToTable("contracts");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Service>().ToTable("services");
            modelBuilder.Entity<Sheet>().ToTable("sheets");
            modelBuilder.Entity<Employee>().ToTable("employees");

            modelBuilder.Entity<Sheet>()
                .HasOne(sheet => sheet.Service)
                .WithMany(service => service.Sheets)
                .HasForeignKey("ServiceID");
                
            
            modelBuilder.Entity<Sheet>()
                .HasOne(sheet => sheet.Contract)
                .WithMany(contract => contract.Sheets)
                .HasForeignKey("ContractID");
                

            modelBuilder.Entity<Sheet>()
                .HasOne(sheet => sheet.Employee)
                .WithMany(employee => employee.Sheets)
                .HasForeignKey("EmployeeID");
             
             
        }
    }
}
