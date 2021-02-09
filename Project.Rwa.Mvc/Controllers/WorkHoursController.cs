using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.Rwa.Mvc.Controllers
{
    public class WorkHoursController : ApiController
    {
        private readonly WorkHoursEntities db = new WorkHoursEntities();


        [HttpPost]
        public IHttpActionResult Start(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var workHour = db.RadniSatis.FirstOrDefault(r => r.IDRadniSati == id);

            if (workHour == null)
            {
                return BadRequest($"Invalid id: {id}");
            }

            db.RadniSatis.Remove(workHour);
            db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        { 
            if(!ModelState.IsValid)
            {
                return BadRequest("Invalid data");
            }

            var workHour = db.RadniSatis.FirstOrDefault(r => r.IDRadniSati == id);

            if(workHour == null)
            {
                return BadRequest($"Invalid id: {id}");
            }

            db.RadniSatis.Remove(workHour);
            db.SaveChanges();

            return Ok();
        }
    }
}
