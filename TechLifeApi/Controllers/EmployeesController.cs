using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;

        public EmployeesController()
        {
            _applicationDbContext = new ApplicationDbContext();

            _applicationDbContext.Post.Load();
            _applicationDbContext.Employee.Load();
        }

        [HttpGet(Name = "GetEmployees")]
        public IEnumerable<Employee> GetEmployees()
        {
            List<Employee> Employees = new List<Employee>();
            Employees = _applicationDbContext.Employee.Local.ToList();

            return Employees;
        }

        [HttpDelete("{id}", Name = "DeleteEmployees")]
        public ActionResult DeleteEmployees(int id)
        {
            Employee? searchEmployee = _applicationDbContext.Employee.Where(employee => employee.Id == id).FirstOrDefault();

            if (searchEmployee != null && searchEmployee.Requests.Count == 0)
            {
                _applicationDbContext.Employee.Remove(searchEmployee);
                _applicationDbContext.SaveChanges();

                return Ok("Запись удалена");
            }
            else
            {
                return BadRequest("Эта запись уже используется или не найдена");
            }
        }
    }
}
