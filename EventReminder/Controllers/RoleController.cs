using API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EventReminder.Controllers
{
    public class RoleController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public RoleController()
        {
            /*client.BaseAddress = new Uri("https://brmapi.azurewebsites.net/API/Batches");*/ //Link API to Client
            client.BaseAddress = new Uri("http://localhost:65279/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Tables()
        {
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<Role> role = null;
            var responseTask = client.GetAsync("Role");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Role>>();
                readTask.Wait();
                role = readTask.Result;
            }
            else
            {
                role = Enumerable.Empty<Role>();
                ModelState.AddModelError(String.Empty, "404 Not Found");
            }
            return Json(new { data = role }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Create(Role role)
        {
            var myContent = JsonConvert.SerializeObject(role);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = client.PostAsync("Role", byteContent).Result;
            return Json(new { data = affectedRow }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id, Role role)
        {
            var myContent = JsonConvert.SerializeObject(role);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var roles = client.PutAsync("Role/" + id, byteContent).Result;
            return Json(new { data = roles }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Details(int id)
        {
            var cek = client.GetAsync("Role/" + id.ToString()).Result;
            var read = cek.Content.ReadAsAsync<Role>().Result;
            //Roles role = null;
            //var responseTask = client.GetAsync("Roles/" + id);
            //responseTask.Wait();

            //var result = responseTask.Result;
            //if (result.IsSuccessStatusCode)
            //{
            //    var readTask = result.Content.ReadAsAsync<Roles>();
            //    readTask.Wait();
            //    role = readTask.Result;
            //}
            //else
            //{
            //    ModelState.AddModelError(string.Empty, "404 Not Found");
            //}
            return Json(new { data = read }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(Role role, int id)
        {
            var affectedRow = client.DeleteAsync("Role/" + id).ToString();
            return Json(new { data = affectedRow }, JsonRequestBehavior.AllowGet);
        }
    }
}