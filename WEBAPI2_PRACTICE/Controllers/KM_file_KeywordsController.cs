using Newtonsoft.Json;
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
    /// 檔案關鍵字Service
    /// </summary>
    public class KM_file_KeywordsController : ApiController
    {
        private Model1 db = new Model1();

        /// GET: api/KM_file_Keywords/GetKM_file_Keywords
        /// <summary>
        /// 查詢所有關鍵字
        /// </summary>
        /// <returns></returns>
        public IQueryable<KM_file_Keywords> GetKM_file_Keywords()
        {
            return db.KM_file_Keywords;
        }

        // GET: api/KM_file_Keywords/GetKM_file_Keywords/5
        /// <summary>
        /// id取得單一關鍵字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Keywords))]
        public IHttpActionResult GetKM_file_Keywords(long id)
        {
            KM_file_Keywords kM_file_Keywords = db.KM_file_Keywords.Find(id);
            if (kM_file_Keywords == null)
            {
                return NotFound();
            }

            return Ok(kM_file_Keywords);
        }

        /// GET: api/KM_file_Keywords/GetTipList/5
        /// <summary>
        /// 取得10筆關鍵字列咬
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetTipList(string id)
        {
            List<string> kM_file_Keywords = db.KM_file_Keywords.Where(c => c.Keywords.Contains(id)).Select( c=>c.Keywords).Take(10).ToList();
            if (kM_file_Keywords.Count == 0)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(kM_file_Keywords));
        }

        /// GET: api/KM_file_Keywords/GetSearchResult/5
        /// <summary>
        /// 取得搜尋結果
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetSearchResult(string id)
        {
            ///取得Guid id
            var result = (from k in db.KM_file_Keywords.Where(c => c.Keywords.Contains(id)) select k.FlowId).Distinct();
            var file = from f in db.KM_file
                       join a in db.KM_file_Annotation on f.FlowId equals a.FlowId
                       join r in result on f.FlowId equals r
                       where (f.isDel == true)
                       orderby f.file_type ascending , f.file_name ascending
                       let Annotation = (string.IsNullOrEmpty(a.Annotation) ? "尚無檔案說明" : a.Annotation)
                       select new { f.file_path, f.file_type, f.file_name, f.isVirt, f.Link, Annotation };

            if (file == null)
            {
                return NotFound();
            }

            return Ok(JsonConvert.SerializeObject(file));
        }

        /// PUT: api/KM_file_Keywords/PutKM_file_Keywords/5
        /// <summary>
        /// 更新關鍵字
        /// </summary>
        /// <param name="id"></param>
        /// <param name="kM_file_Keywords"></param>
        /// <returns></returns>
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKM_file_Keywords(long id, KM_file_Keywords kM_file_Keywords)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kM_file_Keywords.SeqNo)
            {
                return BadRequest();
            }

            db.Entry(kM_file_Keywords).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KM_file_KeywordsExists(id))
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

        /// POST: api/KM_file_Keywords/PostKM_file_Keywords
        /// <summary>
        /// 更新關鍵字
        /// </summary>
        /// <param name="kM_file_Keywords"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Keywords))]
        public IHttpActionResult PostKM_file_Keywords(KM_file_Keywords kM_file_Keywords)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KM_file_Keywords.Add(kM_file_Keywords);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = kM_file_Keywords.SeqNo }, kM_file_Keywords);
        }

        // DELETE: api/KM_file_Keywords/DeleteKM_file_Keywords/5
        /// <summary>
        /// 刪除關鍵字
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(KM_file_Keywords))]
        public IHttpActionResult DeleteKM_file_Keywords(long id)
        {
            KM_file_Keywords kM_file_Keywords = db.KM_file_Keywords.Find(id);
            if (kM_file_Keywords == null)
            {
                return NotFound();
            }

            db.KM_file_Keywords.Remove(kM_file_Keywords);
            db.SaveChanges();

            return Ok(kM_file_Keywords);
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
        private bool KM_file_KeywordsExists(long id)
        {
            return db.KM_file_Keywords.Count(e => e.SeqNo == id) > 0;
        }
    }
}