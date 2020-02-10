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
    public class CategoryController : ApiController
    {
        ApplicationDbContext myContext = new ApplicationDbContext();

        [HttpGet]
        public IQueryable<Category> GetCategory()
        {
            return myContext.Category;
        }

        //[ResponseType(typeof(Roles))]
        [HttpGet]//Mendeklarasikan bahwa bagian ini merupakan GET
        public IHttpActionResult GetCategory(int Id)
        {
            Category category = myContext.Category.Find(Id);
            if (category != null)
            {
                return Ok(category);
            }
            return NotFound();
        }

        //[ResponseType(typeof(Roles))]
        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            if (!string.IsNullOrWhiteSpace(category.Name))//Bila data inputan Null
            {
                myContext.Category.Add(category);
                var result = myContext.SaveChanges();
                if (result > 0)
                {
                    return Ok(category);
                }
                //return CreatedAtRoute("DefaultApi", new { Id = role.Id }, role);
            }
            return BadRequest();
        }

        /*[ResponseType(typeof(void))]*///void tdk mengembalikan nilai
        [HttpPut]
        public IHttpActionResult Put(Category category, int Id)
        {
            var put = myContext.Category.Find(Id);
            //var put = GetRoles(Id);
            if (put != null)
            {
                //put.Name = role.Name;
                if (!string.IsNullOrWhiteSpace(category.Name))
                {
                    put.Name = category.Name;
                    myContext.Entry(put).State = EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                    {
                        return Ok(category);
                    }
                }
                return BadRequest();
            }
            return NotFound();
            //return StatusCode(HttpStatusCode.NoContent);
        }

        //[ResponseType(typeof(Roles))]
        [HttpDelete]
        public IHttpActionResult Delete(Category category, int Id)
        {
            var del = myContext.Category.Find(Id);
            if (del != null)
            {
                myContext.Category.Remove(del);
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
