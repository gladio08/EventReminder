using API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("TB_M_Roles")]
    public class Roles : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Jobtile")]
    public class Jobtitle : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Registration")]
    public class Registration : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Divison")]
    public class Division : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Employee")]
    public class Employee : BaseModel
    {
        public string Name { get; set; }
    }
}