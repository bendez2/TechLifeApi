using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeRequestesController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;
        
        public TypeRequestesController()
        {
            _applicationDbContext = new ApplicationDbContext();

            _applicationDbContext.Priority.Load();
            _applicationDbContext.TypeRequest.Load();
        }

        [HttpGet(Name = "GetTypeRequests")]
        public IEnumerable<TypeRequest> GetTypeRequests()
        {
            List<TypeRequest> typeRequests = new List<TypeRequest>();
            typeRequests = _applicationDbContext.TypeRequest.Local.ToList();

            return typeRequests;
        }

        [HttpDelete("{id}", Name = "DeleteTypeRequestes")]
        public ActionResult DeleteTypeRequestes(int id)
        {
            TypeRequest searchTypeRequest = _applicationDbContext.TypeRequest.Where(status => (status.Id == id)).FirstOrDefault();

            if (searchTypeRequest != null && searchTypeRequest.Requests.Count == 0)
            {
                _applicationDbContext.TypeRequest.Remove(searchTypeRequest);
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
