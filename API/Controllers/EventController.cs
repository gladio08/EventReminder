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
    public class EventController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<Event> GetEvent()
        {
            return myContext.Event;
        }

        //[ResponseType(typeof(Roles))]
        [HttpGet]//Mendeklarasikan bahwa bagian ini merupakan GET
        public IHttpActionResult GetEvent(int Id)
        {
            Event events = myContext.Event.Find(Id);
            if (events != null)
            {
                return Ok(events);
            }
            return NotFound();
        }

        //[ResponseType(typeof(Roles))]
        [HttpPost]
        public IHttpActionResult Post(Event events)
        {
            if (!string.IsNullOrWhiteSpace(events.Title))//Bila data inputan Null
            {
                myContext.Event.Add(events);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(events);
                }
                //return CreatedAtRoute("DefaultApi", new { Id = role.Id }, role);
            }
            return BadRequest();
        }

        /*[ResponseType(typeof(void))]*///void tdk mengembalikan nilai
        [HttpPut]
        public IHttpActionResult Put(Event events, int Id)
        {
            var put = myContext.Event.Find(Id);
            //var put = GetRoles(Id);
            if (put != null)
            {
                //put.Name = role.Name;
                if (!string.IsNullOrWhiteSpace(events.Title))
                {
                    put.Title = events.Title;
                    myContext.Entry(put).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(events);
                    }
                }
                return BadRequest();
            }
            return NotFound();
            //return StatusCode(HttpStatusCode.NoContent);
        }

        //[ResponseType(typeof(Roles))]
        [HttpDelete]
        public IHttpActionResult Delete(Event events, int Id)
        {
            var del = myContext.Event.Find(Id);
            if (del != null)
            {
                myContext.Event.Remove(del);
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
