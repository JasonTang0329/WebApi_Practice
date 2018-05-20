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
    /// 檔案說明Service
    /// </summary>
    public class KM_file_AnnotationController : ApiController
    {
        private Model1 db = new Model1();

        /// GET: api/KM_file_Annotation/GetKM_file_Annotation
        /// <summary>
        /// 查詢所有檔案說明
        /// </summary>
        /// <returns></returns>
        public IQueryable<KM_file_Annotation> GetKM_file_Annotation()
        {
            return db.KM_file_Annotation;
        }

        /// GET: api/KM_file_Annotation/GetKM_file_Annotation/5
        /// <summary>
        /// id取得單一檔案說明
        /// </summary>
        /// <param name="id">檔案關聯id</param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Annotation))]
        public IHttpActionResult GetKM_file_Annotation(long id)
        {
            KM_file_Annotation kM_file_Annotation = db.KM_file_Annotation.Find(id);
            if (kM_file_Annotation == null)
            {
                return NotFound();
            }

            return Ok(kM_file_Annotation);
        }

        /// PUT: api/KM_file_Annotation/PutKM_file_Annotation/5
        /// <summary>
        /// 更新檔案說明
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kM_file_Annotation"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKM_file_Annotation(long id, KM_file_Annotation kM_file_Annotation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kM_file_Annotation.SeqNo)
            {
                return BadRequest();
            }

            db.Entry(kM_file_Annotation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KM_file_AnnotationExists(id))
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

        /// POST: api/KM_file_Annotation/PostKM_file_Annotation/
        /// <summary>
        /// 新增檔案說明
        /// </summary>
        /// <param name="kM_file_Annotation"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Annotation))]
        public IHttpActionResult PostKM_file_Annotation(KM_file_Annotation kM_file_Annotation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KM_file_Annotation.Add(kM_file_Annotation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kM_file_Annotation.SeqNo }, kM_file_Annotation);
        }

        /// DELETE: api/KM_file_Annotation/DeleteKM_file_Annotation/5
        /// <summary>
        /// 刪除檔案說明
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Annotation))]
        public IHttpActionResult DeleteKM_file_Annotation(long id)
        {
            KM_file_Annotation kM_file_Annotation = db.KM_file_Annotation.Find(id);
            if (kM_file_Annotation == null)
            {
                return NotFound();
            }

            db.KM_file_Annotation.Remove(kM_file_Annotation);
            db.SaveChanges();

            return Ok(kM_file_Annotation);
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
        private bool KM_file_AnnotationExists(long id)
        {
            return db.KM_file_Annotation.Count(e => e.SeqNo == id) > 0;
        }
    }
}