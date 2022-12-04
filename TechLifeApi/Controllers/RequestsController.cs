using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;

        public RequestsController()
        {
            _applicationDbContext = new ApplicationDbContext();

            _applicationDbContext.Initiator.Load();
            _applicationDbContext.Priority.Load();
            _applicationDbContext.TypeRequest.Load();
            _applicationDbContext.Status.Load();
            _applicationDbContext.Request.Load();

        }

        [HttpGet(Name = "GetRequest")]
        public IEnumerable<Request> GetRequest()
        {
            List<Request> requests = new List<Request>();
            requests = _applicationDbContext.Request.Local.ToList();

            return requests;
        }

        [HttpDelete("{id}", Name = "DeleteRequest")]
        public ActionResult DeleteRequest(string id)
        {
            Request searchRequest = _applicationDbContext.Request.Find(Convert.ToInt32(id));

            if (searchRequest != null)
            {
                _applicationDbContext.Request.Remove(searchRequest);
                _applicationDbContext.SaveChanges();

                return Ok("This record deleted");
            }
            else
            {
                return BadRequest("This record not found");
            }
        }


    }
}
