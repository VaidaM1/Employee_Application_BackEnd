using EmployeeApi.Data;
using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task<int> AddAsync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }
        public async Task<int> CreateAsync(Employee employee)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return employee.Id;
        }
        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Employee employee)
        {
            _context.Remove(employee);
            await _context.SaveChangesAsync();
        }

        internal Task<int> CreateAsync(ShowEmployeeDtos employeesDb)
        {
            throw new NotImplementedException();
        }
    }
}
