using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using MyFirstWebAPI.Data;
using System.Diagnostics.CodeAnalysis;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var employee = await _db.Employees.ToListAsync();
            return Ok(employee);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _db.Employees.ToListAsync();
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            return Ok(employee);
        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Employee employee)
        {
            if (employee.Salary <= 0)
            {
                return BadRequest("Salary must be greater than zero");

            }
            _db.Employees.Add(employee);
            await _db.SaveChangesAsync();
            return Ok("Employee Added Successfully" + employee.Name);

        }
        [HttpPut]

        public async Task<IActionResult> Update(int id, [FromBody] Employee employee)
        {
            var emp = await _db.Employees.FirstOrDefaultAsync(emp => emp.Id == id);
            if (employee == null)
            {
                return Ok();
            }
            employee.Name = employee.Name;
            employee.Department = employee.Department;
            employee.Salary = employee.Salary;
            await _db.SaveChangesAsync();
            return Ok("Employee updated succesfully" + employee.Name);
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var emp = await _db.Employees.FirstOrDefaultAsync();
            if (emp == null)
            {
                return NotFound("Employee not found");
            }

            _db.Employees.Remove(emp);
            await _db.SaveChangesAsync();

            return Ok("Employee deleted succesfully" + emp.Name);


        }
    }
}
