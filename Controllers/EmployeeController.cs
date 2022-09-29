using HrManagementSystem.Dbcontext;
using HrManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HrManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly Hrms_DbContext hrms_DbContext;
        public EmployeeController(Hrms_DbContext hrms_DbContext)
        {
            this.hrms_DbContext = hrms_DbContext;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            try
            {
                var empList = await hrms_DbContext.Employees.ToListAsync();
                if (empList.Count != 0)
                    return Ok(empList);

                return NotFound("employee data not found");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId([FromRoute] int id)
        {
            try
            {
                var employee = await hrms_DbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (employee != null)
                    return Ok(employee);

                return NotFound("employee data not found");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Employee employee)
        {
            await hrms_DbContext.Employees.AddAsync(employee);
            await hrms_DbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetbyId), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Employee employee)
        {
            try
            {
                var emp = await hrms_DbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (emp != null)
                {
                    emp.Name = employee.Name;
                    emp.Mobile = employee.Mobile;
                    emp.Email = employee.Email;
                    emp.DOB = employee.DOB;
                    emp.Gender = employee.Gender;
                    emp.Role = employee.Role;
                    emp.IsActive = employee.IsActive;
                    await hrms_DbContext.SaveChangesAsync();
                    return Ok(emp);
                }
                return NotFound("employee not found");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var existingEmp = await hrms_DbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (existingEmp != null)
            {
                hrms_DbContext.Remove(existingEmp);
                await hrms_DbContext.SaveChangesAsync();
                return Ok(existingEmp);
            }

            return NotFound("employee not found");
        }

    }
}
