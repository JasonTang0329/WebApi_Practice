using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WEBAPI2_PRACTICE.Models;

namespace WEBAPI2_PRACTICE.Controllers
{
    public class KM_file_Temp_PathController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/KM_file_Temp_Path
        public IQueryable<KM_file_Temp_Path> GetKM_file_Temp_Path()
        {
            return db.KM_file_Temp_Path;
        }

        // GET: api/KM_file_Temp_Path/5
        [ResponseType(typeof(KM_file_Temp_Path))]
        public IHttpActionResult GetKM_file_Temp_Path(long id)
        {
            KM_file_Temp_Path kM_file_Temp_Path = db.KM_file_Temp_Path.Find(id);
            if (kM_file_Temp_Path == null)
            {
                return NotFound();
            }

            return Ok(kM_file_Temp_Path);
        }

        // PUT: api/KM_file_Temp_Path/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKM_file_Temp_Path(long id, KM_file_Temp_Path kM_file_Temp_Path)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kM_file_Temp_Path.idx)
            {
                return BadRequest();
            }

            db.Entry(kM_file_Temp_Path).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KM_file_Temp_PathExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KM_file_Temp_Path
        [ResponseType(typeof(KM_file_Temp_Path))]
        public IHttpActionResult PostKM_file_Temp_Path(KM_file_Temp_Path kM_file_Temp_Path)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KM_file_Temp_Path.Add(kM_file_Temp_Path);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kM_file_Temp_Path.idx }, kM_file_Temp_Path);
        }

        // DELETE: api/KM_file_Temp_Path/5
        [ResponseType(typeof(KM_file_Temp_Path))]
        public IHttpActionResult DeleteKM_file_Temp_Path(long id)
        {
            KM_file_Temp_Path kM_file_Temp_Path = db.KM_file_Temp_Path.Find(id);
            if (kM_file_Temp_Path == null)
            {
                return NotFound();
            }

            db.KM_file_Temp_Path.Remove(kM_file_Temp_Path);
            db.SaveChanges();

            return Ok(kM_file_Temp_Path);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KM_file_Temp_PathExists(long id)
        {
            return db.KM_file_Temp_Path.Count(e => e.idx == id) > 0;
        }
    }
}