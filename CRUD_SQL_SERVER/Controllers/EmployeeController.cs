using CRUD_SQL_SERVER.Data;
using CRUD_SQL_SERVER.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace CRUD_SQL_SERVER.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // constuctor untuk terkoneksi dengan AppDbContext
        private readonly AppDbContext appDbContext;
        public EmployeeController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        // create data 
        [HttpPost]
        public async Task<ActionResult<List<Employee>>> AddEmployee(Employee newEmployee)
        {
            if (newEmployee != null)
            {
                appDbContext.Employees.Add(newEmployee);
                await appDbContext.SaveChangesAsync();
                return Ok(await appDbContext.Employees.ToListAsync());
            }
            return BadRequest("Employee data is required.");
        }

        // get all data 
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployee()
        {
            var employees = await appDbContext.Employees.ToListAsync();
            return Ok(employees);
        }

        // get employee by Id
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            var employee = await appDbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if(employee != null)
            {
                return Ok(employee);
            }
            return NotFound("Employee Not Found");
        }

    }
}
