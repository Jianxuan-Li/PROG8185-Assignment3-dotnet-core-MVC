using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment3.Controllers
{



    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext context;

        public UsersController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return context.Users;
        }

        [HttpGet("{id}")]
        public User Get(int id)
        {
            try
            {
                return context.Users.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
        }

        [HttpPost]
        public User Post([FromBody] User users)
        {
            context.Users.Add(users);
            context.SaveChanges();
            return users;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
        }
    }

}

