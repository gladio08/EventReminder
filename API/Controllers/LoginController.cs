using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace API.Controllers
{
    public class LoginController : ApiController
    {
        public async Task<ActionResult> Login(User user)
        {
            ApplicationDbContext myContext = new ApplicationDbContext();
            var check = await myContext.User.FirstOrDefaultAsync(a => a.Email.Equals(user.Email));
            //bool test = classHash.ValidatePassword(Logins.Password, check.Password);
            //if (check == true)
            //{
            return RedirectToAction("Index");
            //}
            //else
            //{
            //    return RedirectToAction("Login");
            //}
        }
        
    }
}
