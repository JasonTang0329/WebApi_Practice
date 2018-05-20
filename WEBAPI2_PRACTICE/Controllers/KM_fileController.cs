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
    /// <summary>
    /// 檔案Service
    /// </summary>
    public class KM_fileController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/KM_file
        /// <summary>
        /// 查詢所有檔案
        /// </summary>
        /// <returns></returns>
        public IQueryable<KM_file> GetKM_file()
        {
            return db.KM_file;
        }

        // GET: api/KM_file/5
        /// <summary>
        /// id取得單一檔案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file))]
        public IHttpActionResult GetKM_file(Guid id)
        {
            KM_file kM_file = db.KM_file.Find(id);
            if (kM_file == null)
            {
                return NotFound();
            }

            return Ok(kM_file);
        }

        // PUT: api/KM_file/5
        /// <summary>
        /// 更新檔案
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kM_file"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKM_file(Guid id, KM_file kM_file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kM_file.FlowId)
            {
                return BadRequest();
            }

            db.Entry(kM_file).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KM_fileExists(id))
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

        // POST: api/KM_file
        /// <summary>
        /// 新增檔案
        /// </summary>
        /// <param name="kM_file"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file))]
        public IHttpActionResult PostKM_file(KM_file kM_file)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             kM_file.FlowId = Guid.NewGuid();
            db.KM_file.Add(kM_file);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KM_fileExists(kM_file.FlowId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = kM_file.FlowId }, kM_file);
        }

        // DELETE: api/KM_file/5
        /// <summary>
        /// 刪除檔案
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file))]
        public IHttpActionResult DeleteKM_file(Guid id)
        {
            KM_file kM_file = db.KM_file.Find(id);
            if (kM_file == null)
            {
                return NotFound();
            }

            db.KM_file.Remove(kM_file);
            db.SaveChanges();

            return Ok(kM_file);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool KM_fileExists(Guid id)
        {
            return db.KM_file.Count(e => e.FlowId == id) > 0;
        }
    }
}