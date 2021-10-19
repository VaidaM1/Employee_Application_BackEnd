using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using EmployeeApi.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Services
{
    public class EmployeeService
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<List<ShowEmployeeDtos>> GetAllAsync()
        {

            List<Employee> employeesDb = await _employeeRepository.GetAsync();

            var showEmployeesDto = new List<ShowEmployeeDtos>();

            foreach (var item in employeesDb)
            {

                ShowEmployeeDtos mappedEmployee = new()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Sex = item.Sex.ToString()
                };
                showEmployeesDto.Add(mappedEmployee);
            }
            return showEmployeesDto;
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        //public async Task AddAsync(Employee employee)
        //{
        //    if (employee.PointListId.HasValue)
        //    {
        //        var pointList = await _pointListRepository.GetById(employee.PointListId.Value);
        //        if (pointList == null)
        //        {
        //            throw new ArgumentException("Employee does not exist");
        //        }
        //    }
        //    await _employeeRepository.AddAsync(employee);
        //}
        public async Task<int> CreateAsync(CreateEmployeeDtos createEmployeeDtos)
        {
            Employee employeeDb = new()
            {
                FirstName = createEmployeeDtos.FirstName,
                LastName = createEmployeeDtos.LastName,
                Sex = Enum.Parse<GenterType>(createEmployeeDtos.Sex)
            };


            return await _employeeRepository.CreateAsync(employeeDb);
        }

        public async Task UpdateAsync(Employee employee)
        {
            var entity = new Employee()
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Sex = employee.Sex

            };
            await _employeeRepository.UpdateAsync(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var employee = await GetByIdAsync(id);
            await _employeeRepository.DeleteAsync(employee);
        }
    }
}