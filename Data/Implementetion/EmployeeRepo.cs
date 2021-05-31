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


        /// <summary>
        /// Добавление работника 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task Add(Employee item)
        {
            // Такая запись 
           await    _context.Employees.AddAsync(item);
           // и такая запись проходят 
           //  await _context.AddAsync(item);
           // Как правильно - я не понял.
                
           await _context.SaveChangesAsync();
        }

        public async Task Delete(Employee item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
        }

        public async  Task<Employee> GetItem(Guid Id)
        {
            return await _context.Employees.FindAsync(Id);
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
