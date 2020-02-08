using API.viewModel;
using EventReminder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace EventReminder.Controllers
{
    public class EmployeeController : Controller
    {
        //// GET: Employee
        //public ActionResult Index()
        //{
        //    return View();
        //}
        readonly HttpClient client = new HttpClient();
        public EmployeeController()
        {
            client.BaseAddress = new Uri("https://brmapi.azurewebsites.net/API/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View(List());
        }
        public JsonResult List()
        {
            IEnumerable<EmployeesVM> employee = null;
            var responseTask = client.GetAsync("Employees");
            responseTask.Wait();
            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IList<EmployeesVM>>();
                readTask.Wait();
                employee = readTask.Result;
            }
            else
            {
                employee = Enumerable.Empty<EmployeesVM>();
                ModelState.AddModelError(String.Empty, "404 Not Found");
            }
            return Json(new { data = employee }, JsonRequestBehavior.AllowGet);

        }
    }
}