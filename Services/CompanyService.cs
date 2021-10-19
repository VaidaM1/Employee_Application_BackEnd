using EmployeeApi.Entities;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _companyRepository;

        public CompanyService(CompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public async Task<List<Company>> GetAllAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            var pointList = await _companyRepository.GetById(id);
            if (pointList == null)
            {
                throw new ArgumentException("Compoany not found");
            }
            return pointList;
        }

        public async Task CreateAsync(Company company)
        {
            var entity = new Company()
            {
                CompanyName = company.CompanyName
            };

            await _companyRepository.CreateAsync(entity);
        }
        public async Task UpdateAsync(Company company)
        {
            var entity = new Company()
            {
                CompanyName = company.CompanyName
            };

            await _companyRepository.CreateAsync(entity);
        }
        public async Task DeleteAsync(int id)
        {
            var point = await GetByIdAsync(id);
            await _companyRepository.DeleteAsync(point);
        }

    }
}