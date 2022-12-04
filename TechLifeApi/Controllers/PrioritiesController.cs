using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrioritiesController : ControllerBase
    {
        ApplicationDbContext _applicationDbContext;

        public PrioritiesController()
        {
            _applicationDbContext = new ApplicationDbContext();
            _applicationDbContext.Priority.Load();
        }

        [HttpGet(Name = "GetPriorities")]
        public IEnumerable<Priority> GetPriorities()
        {
            List<Priority> priorities = new List<Priority>();
            priorities = _applicationDbContext.Priority.Local.ToList();

            return priorities;
        }

        [HttpDelete("{id}", Name = "DeletePriority")]
        public ActionResult DeletePriority(int id)
        {
            Priority searchPriority = _applicationDbContext.Priority.Where(priority => (priority.Id == id)).FirstOrDefault();

            if (searchPriority != null && searchPriority.RequestTypes.Count == 0)
            {
                _applicationDbContext.Priority.Remove(searchPriority);
                _applicationDbContext.SaveChanges();

                return Ok("This record deleted");
            }
            else
            {
                return BadRequest("This record not found or use other table");
            }
        }
    }
}
