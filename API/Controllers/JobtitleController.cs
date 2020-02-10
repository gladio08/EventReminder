using API.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class JobtitleController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<Jobtitle> GetJobtitle()
        {
            return myContext.Jobtitle;
        }

        //[ResponseType(typeof(Roles))]
        [HttpGet]//Mendeklarasikan bahwa bagian ini merupakan GET
        public IHttpActionResult GetJobtitle(int Id)
        {
            Jobtitle jobtitle = myContext.Jobtitle.Find(Id);
            if (jobtitle != null)
            {
                return Ok(jobtitle);
            }
            return NotFound();
        }

        //[ResponseType(typeof(Roles))]
        [HttpPost]
        public IHttpActionResult Post(Jobtitle jobtitle)
        {
            if (!string.IsNullOrWhiteSpace(jobtitle.Name))//Bila data inputan Null
            {
                myContext.Jobtitle.Add(jobtitle);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(jobtitle);
                }
                //return CreatedAtRoute("DefaultApi", new { Id = role.Id }, role);
            }
            return BadRequest();
        }

        /*[ResponseType(typeof(void))]*///void tdk mengembalikan nilai
        [HttpPut]
        public IHttpActionResult Put(Jobtitle jobtitle, int Id)
        {
            var put = myContext.Jobtitle.Find(Id);
            //var put = GetRoles(Id);
            if (put != null)
            {
                //put.Name = role.Name;
                if (!string.IsNullOrWhiteSpace(jobtitle.Name))
                {
                    put.Name = jobtitle.Name;
                    myContext.Entry(put).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(jobtitle);
                    }
                }
                return BadRequest();
            }
            return NotFound();
            //return StatusCode(HttpStatusCode.NoContent);
        }

        //[ResponseType(typeof(Roles))]
        [HttpDelete]
        public IHttpActionResult Delete(Jobtitle jobtitle, int Id)
        {
            var del = myContext.Jobtitle.Find(Id);
            if (del != null)
            {
                myContext.Jobtitle.Remove(del);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(del);
                }
            }
            return NotFound();
        }
    }
}
