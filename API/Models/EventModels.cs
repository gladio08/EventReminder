using API.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace API.Models
{
    [Table("TB_M_Role")]
    public class Role : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_User")]
    public class User : BaseModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
    }

    [Table("TB_M_Jobtile")]
    public class Jobtitle : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Category")]
    public class Category : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Divison")]
    public class Division : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Room")]
    public class Room : BaseModel
    {
        public string Name { get; set; }
    }

    [Table("TB_M_Employee")]
    public class Employee : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Division Division { get; set; }
        public Jobtitle Jobtitle { get; set; }
    }

    [Table("TB_T_Event")]
    public class Event : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Division Division { get; set; }
        public Category Category { get; set; }
        public Room Room { get; set; }
    }
}