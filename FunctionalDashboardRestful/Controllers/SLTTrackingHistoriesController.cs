using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using FunctionalDashboardRestful.Models;

namespace FunctionalDashboardRestful.Controllers
{
    public class SLTTrackingHistoriesController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/SLTTrackingHistories
        public IQueryable<SLTTrackingHistory> GetSLTTrackingHistories()
        {
            return db.SLTTrackingHistories;
        }

        // GET: api/SLTTrackingHistories/5
        [ResponseType(typeof(SLTTrackingHistory))]
        public async Task<IHttpActionResult> GetSLTTrackingHistory(int id)
        {
            SLTTrackingHistory sLTTrackingHistory = await db.SLTTrackingHistories.FindAsync(id);
            if (sLTTrackingHistory == null)
            {
                return NotFound();
            }

            return Ok(sLTTrackingHistory);
        }

        // PUT: api/SLTTrackingHistories/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSLTTrackingHistory(int id, SLTTrackingHistory sLTTrackingHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sLTTrackingHistory.ID)
            {
                return BadRequest();
            }

            db.Entry(sLTTrackingHistory).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SLTTrackingHistoryExists(id))
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

        // POST: api/SLTTrackingHistories
        [ResponseType(typeof(SLTTrackingHistory))]
        public async Task<IHttpActionResult> PostSLTTrackingHistory(SLTTrackingHistory sLTTrackingHistory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SLTTrackingHistories.Add(sLTTrackingHistory);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = sLTTrackingHistory.ID }, sLTTrackingHistory);
        }

        // DELETE: api/SLTTrackingHistories/5
        [ResponseType(typeof(SLTTrackingHistory))]
        public async Task<IHttpActionResult> DeleteSLTTrackingHistory(int id)
        {
            SLTTrackingHistory sLTTrackingHistory = await db.SLTTrackingHistories.FindAsync(id);
            if (sLTTrackingHistory == null)
            {
                return NotFound();
            }

            db.SLTTrackingHistories.Remove(sLTTrackingHistory);
            await db.SaveChangesAsync();

            return Ok(sLTTrackingHistory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SLTTrackingHistoryExists(int id)
        {
            return db.SLTTrackingHistories.Count(e => e.ID == id) > 0;
        }
    }
}