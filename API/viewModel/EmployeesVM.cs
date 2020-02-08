using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.viewModel
{
    public class EmployeesVM
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birth_date { get; set; }
        public string gender { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string is_deleted { get; set; }
        public int hiring_location { get; set; }
        public DateTime create_date { get; set; }
        public string batchClasses { get; set; }
    }
}