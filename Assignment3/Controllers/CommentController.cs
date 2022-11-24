using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly AppDbContext context;

        public CommentController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return context.Comments;
        }

        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            try
            {
                return context.Comments.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public Comment Post([FromBody] Comment comment)
        {
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var comment = context.Comments.Find(id);
            context.Comments.Remove(comment);
            context.SaveChanges();
        }
    }
}
