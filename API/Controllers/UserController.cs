using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace API.Controllers
{
    public class UserController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<User> GetUsers()
        {
            return myContext.User;
        }

        [HttpGet]
        public IHttpActionResult GetUser(int Id)
        {
            User users = myContext.User.Find(Id);
            if (users != null)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Login (User user)
        {
            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                var slog = myContext.User.Where(e => e.Email == user.Email).SingleOrDefault();
                if (slog.Email == user.Email)
                {
                    var check = myContext.User.FirstOrDefault(a => a.Id == slog.Id);
                    if(check.Id == slog.Id)
                    {
                        return Ok();
                    }
                    return NotFound();
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}
