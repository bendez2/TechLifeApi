using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TechLifeApi.Models;

namespace TechLifeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private ApplicationDbContext _applicationDbContext;

        public PostsController()
        {
            _applicationDbContext = new ApplicationDbContext();

            _applicationDbContext.Post.Load();
        }

        [HttpGet(Name = "GetPosts")]
        public IEnumerable<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();
            posts = _applicationDbContext.Post.Local.ToList();

            return posts;
        }

        [HttpDelete("{id}", Name = "DeletePost")]
        public ActionResult DeleteInitiator(int id)
        {
            Post ?searchPost = _applicationDbContext.Post.Where(post => (post.Id == id)).FirstOrDefault();

            if (searchPost != null && searchPost.Employees.Count == 0)
            {
                _applicationDbContext.Post.Remove(searchPost);
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
