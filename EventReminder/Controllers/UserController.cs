using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EventReminder.Controllers
{
    public class UserController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public UserController()
        {
            /*client.BaseAddress = new Uri("https://brmapi.azurewebsites.net/API/Batches");*/ //Link API to Client
            client.BaseAddress = new Uri("http://localhost:65279/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoginView()
        {
            return View(GetDataUser());
        }

        public JsonResult GetDataUser()
        {
            IEnumerable<User> user = null;
            var responseTask = client.GetAsync("User");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<User>>();
                readTask.Wait();
                user = readTask.Result;
            }
            else
            {
                user = Enumerable.Empty<User>();
                ModelState.AddModelError(string.Empty, "404 Not Found");
            }
            return Json(new { data = user }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Login(int id, User user)
        {
            var myContent = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var roles = client.PutAsync("Roles/" + id, byteContent).Result;
            return Json(new { data = user }, JsonRequestBehavior.AllowGet);
        }
    }

        
}