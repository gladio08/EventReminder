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
    public class DivisionController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<Division> GetDivision()
        {
            return myContext.Division;
        }

        //[ResponseType(typeof(Roles))]
        [HttpGet]//Mendeklarasikan bahwa bagian ini merupakan GET
        public IHttpActionResult GetDivision(int Id)
        {
            Division division = myContext.Division.Find(Id);
            if (division != null)
            {
                return Ok(division);
            }
            return NotFound();
        }

        //[ResponseType(typeof(Roles))]
        [HttpPost]
        public IHttpActionResult Post(Division division)
        {
            if (!string.IsNullOrWhiteSpace(division.Name))//Bila data inputan Null
            {
                myContext.Division.Add(division);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(division);
                }
                //return CreatedAtRoute("DefaultApi", new { Id = role.Id }, role);
            }
            return BadRequest();
        }

        /*[ResponseType(typeof(void))]*///void tdk mengembalikan nilai
        [HttpPut]
        public IHttpActionResult Put(Division division, int Id)
        {
            var put = myContext.Division.Find(Id);
            //var put = GetRoles(Id);
            if (put != null)
            {
                //put.Name = role.Name;
                if (!string.IsNullOrWhiteSpace(division.Name))
                {
                    put.Name = division.Name;
                    myContext.Entry(put).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(division);
                    }
                }
                return BadRequest();
            }
            return NotFound();
            //return StatusCode(HttpStatusCode.NoContent);
        }

        //[ResponseType(typeof(Roles))]
        [HttpDelete]
        public IHttpActionResult Delete(Division division, int Id)
        {
            var del = myContext.Division.Find(Id);
            if (del != null)
            {
                myContext.Division.Remove(del);
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
