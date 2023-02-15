using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InitiatorsController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;
        
        public InitiatorsController()
        {
            _applicationDbContext = new ApplicationDbContext();

            _applicationDbContext.Initiator.Load();
        }

        [HttpGet(Name = "GetInitiators")]
        public IEnumerable<Initiator> GetInitiators()
        {
            List<Initiator> initiators = new List<Initiator>();
            initiators = _applicationDbContext.Initiator.Local.ToList();

            return initiators;
        }

        [HttpDelete("{id}", Name = "DeleteInitiator")]
        public ActionResult DeleteInitiator(int id)
        {
            Initiator ?searchInitiator = _applicationDbContext.Initiator.Where(initiator => (initiator.Id == id)).FirstOrDefault();

            if (searchInitiator != null && searchInitiator.Requests.Count == 0)
            {
                _applicationDbContext.Initiator.Remove(searchInitiator);
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
