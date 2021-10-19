using EmployeeApi.Data;
using EmployeeApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApi.Repositories
{
    public class CompanyRepository
    {
        private readonly DataContext _dataContext;

        public CompanyRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _dataContext.Companys.ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _dataContext.Companys.FirstOrDefaultAsync(c => c.Id == id);

        }

        public async Task CreateAsync(Company company)
        {
            _dataContext.Add(company);
            await _dataContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _dataContext.Add(company);
            await _dataContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Company company)
        {
            _dataContext.Remove(company);
            await _dataContext.SaveChangesAsync();
        }
    }
}
