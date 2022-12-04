using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusesController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;

        public StatusesController()
        {
            _applicationDbContext = new ApplicationDbContext();

            _applicationDbContext.Status.Load();
        }

        [HttpGet(Name = "GetStatuses")]
        public IEnumerable<Status> GetStatuses()
        {
            List<Status> statuses = new List<Status>();
            statuses = _applicationDbContext.Status.Local.ToList();

            return statuses;
        }

        [HttpDelete("{id}", Name = "DeleteStatus")]
        public ActionResult DeleteStatus(int id)
        {
            Status searchStatus = _applicationDbContext.Status.Where(status => (status.Id == id)).FirstOrDefault();

            if (searchStatus != null && searchStatus.Requests.Count == 0)
            {
                _applicationDbContext.Status.Remove(searchStatus);
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
