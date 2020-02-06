using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace API.Base
{
    [Key]
    public class BaseModel
    {
        public int Id { get; set; }
    }
}