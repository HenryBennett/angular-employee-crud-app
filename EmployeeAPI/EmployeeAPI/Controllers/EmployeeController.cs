using EmployeeAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;

        public EmployeeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployees()
        {
            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employee)
        {
            var dbEmployee = await _context.Employees.FindAsync(employee.Id);
            if (dbEmployee == null)
                return BadRequest("Employee not found.");

            dbEmployee.FirstName = employee.FirstName;
            dbEmployee.LastName = employee.LastName;
            dbEmployee.Position = employee.Position;
            dbEmployee.Location = employee.Location;

            await _context.SaveChangesAsync();

            return Ok(await _context.Employees.ToListAsync());
        }
    }
}
