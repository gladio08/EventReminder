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
    public class RoomController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<Room> GetRoom()
        {
            return myContext.Room;
        }

        //[ResponseType(typeof(Roles))]
        [HttpGet]//Mendeklarasikan bahwa bagian ini merupakan GET
        public IHttpActionResult GetDivision(int Id)
        {
            Room room = myContext.Room.Find(Id);
            if (room != null)
            {
                return Ok(room);
            }
            return NotFound();
        }

        //[ResponseType(typeof(Roles))]
        [HttpPost]
        public IHttpActionResult Post(Room room)
        {
            if (!string.IsNullOrWhiteSpace(room.Name))//Bila data inputan Null
            {
                myContext.Room.Add(room);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(room);
                }
                //return CreatedAtRoute("DefaultApi", new { Id = role.Id }, role);
            }
            return BadRequest();
        }

        /*[ResponseType(typeof(void))]*///void tdk mengembalikan nilai
        [HttpPut]
        public IHttpActionResult Put(Room room, int Id)
        {
            var put = myContext.Room.Find(Id);
            //var put = GetRoles(Id);
            if (put != null)
            {
                //put.Name = role.Name;
                if (!string.IsNullOrWhiteSpace(room.Name))
                {
                    put.Name = room.Name;
                    myContext.Entry(put).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(room);
                    }
                }
                return BadRequest();
            }
            return NotFound();
            //return StatusCode(HttpStatusCode.NoContent);
        }

        //[ResponseType(typeof(Roles))]
        [HttpDelete]
        public IHttpActionResult Delete(Room room, int Id)
        {
            var del = myContext.Room.Find(Id);
            if (del != null)
            {
                myContext.Room.Remove(del);
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
