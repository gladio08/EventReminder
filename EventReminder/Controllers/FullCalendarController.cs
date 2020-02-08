using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventReminder.Controllers
{
    public class FullCalendarController : Controller
    {
        // GET: FullCalendar
        public ActionResult Index()
        {
            return View();
        }
    }
}