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
    public class EventController : Controller
    {
        readonly HttpClient client = new HttpClient();
        public EventController()
        {
            /*client.BaseAddress = new Uri("https://brmapi.azurewebsites.net/API/Batches");*/ //Link API to Client
            client.BaseAddress = new Uri("http://localhost:65279/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public ActionResult Event()
        {
            return View();
        }

        public JsonResult List()
        {
            IEnumerable<Event> events = null;
            var responseTask = client.GetAsync("Event");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<Event>>();
                readTask.Wait();
                events = readTask.Result;
            }
            else
            {
                events = Enumerable.Empty<Event>();
                ModelState.AddModelError(String.Empty, "404 Not Found");
            }
            return Json(new { data = events }, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Create(Event events)
        {
            var myContent = JsonConvert.SerializeObject(events);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var affectedRow = client.PostAsync("Event", byteContent).Result;
            return Json(new { data = affectedRow }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Edit(int id, Event events)
        {
            var myContent = JsonConvert.SerializeObject(events);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var roles = client.PutAsync("Event/" + id, byteContent).Result;
            return Json(new { data = events }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Details(int id)
        {
            var cek = client.GetAsync("Event/" + id.ToString()).Result;
            var read = cek.Content.ReadAsAsync<Event>().Result;
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

        public ActionResult Delete(Event events, int id)
        {
            var affectedRow = client.DeleteAsync("Event/" + id).ToString();
            return Json(new { data = affectedRow }, JsonRequestBehavior.AllowGet);
        }
    }
}