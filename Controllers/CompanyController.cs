using EmployeeApi.Entities;
using EmployeeApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _companyService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _companyService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Company company)
        {
            await _companyService.CreateAsync(company);
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Company company)
        {
            await _companyService.UpdateAsync(company);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);
            return NoContent();
        }

        //[HttpGet("{id}/CountEmplouee")]
        //public async Task<IActionResult> GetByIdCount(int id)
        //{
        //    await _companyService.GetByIdCountAsync(id);
        //    return Ok(new { Count = company.Employee.Count });
        //}
    }
}