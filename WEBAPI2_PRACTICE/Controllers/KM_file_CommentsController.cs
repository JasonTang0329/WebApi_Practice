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
    /// 檔案評論Service
    /// </summary>
    public class KM_file_CommentsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/KM_file_Comments
        /// <summary>
        /// 取得所有檔案論
        /// </summary>
        /// <returns></returns>
        public IQueryable<KM_file_Comments> GetKM_file_Comments()
        {
            return db.KM_file_Comments;
        }

        // GET: api/KM_file_Comments/5
        /// <summary>
        /// id取得單一檔案評論
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Comments))]
        public IHttpActionResult GetKM_file_Comments(long id)
        {
            KM_file_Comments kM_file_Comments = db.KM_file_Comments.Find(id);
            if (kM_file_Comments == null)
            {
                return NotFound();
            }

            return Ok(kM_file_Comments);
        }

        // PUT: api/KM_file_Comments/5
        /// <summary>
        /// 更新檔案評論
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kM_file_Comments"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKM_file_Comments(long id, KM_file_Comments kM_file_Comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kM_file_Comments.SeqNo)
            {
                return BadRequest();
            }

            db.Entry(kM_file_Comments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KM_file_CommentsExists(id))
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

        // POST: api/KM_file_Comments
        /// <summary>
        /// 新增檔案評論
        /// </summary>
        /// <param name="kM_file_Comments"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Comments))]
        public IHttpActionResult PostKM_file_Comments(KM_file_Comments kM_file_Comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KM_file_Comments.Add(kM_file_Comments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kM_file_Comments.SeqNo }, kM_file_Comments);
        }

        // DELETE: api/KM_file_Comments/5
        /// <summary>
        /// 刪除檔案評論
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Comments))]
        public IHttpActionResult DeleteKM_file_Comments(long id)
        {
            KM_file_Comments kM_file_Comments = db.KM_file_Comments.Find(id);
            if (kM_file_Comments == null)
            {
                return NotFound();
            }

            db.KM_file_Comments.Remove(kM_file_Comments);
            db.SaveChanges();

            return Ok(kM_file_Comments);
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
        private bool KM_file_CommentsExists(long id)
        {
            return db.KM_file_Comments.Count(e => e.SeqNo == id) > 0;
        }
    }
}