using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Models;
using Microsoft.EntityFrameworkCore;

namespace Timesheets.Data.Implementetion
{
    public class EmployeeRepo : IEmployeeRepo
    {
       private readonly TimeSheetDbContext _context;

        public EmployeeRepo(TimeSheetDbContext context)
        {
            _context = context;
        }

        public async Task Add(Employee item)
        {
           await _context.Employees.AddAsync(item);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(Employee item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async  Task<Employee> GetItem(Guid ID)
        {
            var result = await _context.Employees.FindAsync(ID);
            return result;
        }

        public async Task<IEnumerable<Employee>> GetItems()
        {
            var result = await _context.Employees.ToListAsync();
            return result;
        }

         public async Task Update(Employee item)
        {
             _context.Employees.Update(item);
            await _context.SaveChangesAsync();
        }
    }
}
