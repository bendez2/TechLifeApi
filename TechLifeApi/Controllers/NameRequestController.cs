using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameRequestController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;

        public NameRequestController()
        {
            _applicationDbContext = new ApplicationDbContext();

            _applicationDbContext.NameRequest.Load();
        }

        [HttpGet(Name = "GetNameRequestes")]
        public IEnumerable<NameRequest> GetNameRequestes()
        {
            List<NameRequest> nameRequest = new List<NameRequest>();
            nameRequest = _applicationDbContext.NameRequest.Local.ToList();

            return nameRequest;
        }

        [HttpDelete("{id}", Name = "DeleteNameRequestes")]
        public ActionResult DeleteNameRequestes(int id)
        {
            NameRequest? searchName = _applicationDbContext.NameRequest.Where(name => (name.Id == id)).FirstOrDefault();

            if (searchName != null && searchName.TypeRequests.Count == 0)
            {
                _applicationDbContext.NameRequest.Remove(searchName);
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
