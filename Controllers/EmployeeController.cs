using EmployeeApi.Dtos;
using EmployeeApi.Entities;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShowEmployeeDtos>>> GetAll()
        {
            return Ok(await _employeeService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            //throw new NotImplementedException();
            var employee = await _employeeService.GetByIdAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDtos createEmployeeDtos)
        {
            var id = await _employeeService.CreateAsync(createEmployeeDtos);
            return Ok(id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Employee employee)
        {
            await _employeeService.UpdateAsync(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteAsync(id);

            return NoContent();
        }

        [HttpPut("{id},Employees")]
        public async Task<IActionResult> PullEmployee(Employee employee)
        {
            await _employeeService.UpdateAsync(employee);
            return NoContent();
        }


    }
}
