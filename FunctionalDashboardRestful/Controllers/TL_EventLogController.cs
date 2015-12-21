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
    public class TL_EventLogController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/TL_EventLog
        public IQueryable<TL_EventLog> GetTL_EventLog()
        {
            return db.TL_EventLog;
        }

        // GET: api/TL_EventLog/5
        [ResponseType(typeof(TL_EventLog))]
        public async Task<IHttpActionResult> GetTL_EventLog(long id)
        {
            TL_EventLog tL_EventLog = await db.TL_EventLog.FindAsync(id);
            if (tL_EventLog == null)
            {
                return NotFound();
            }

            return Ok(tL_EventLog);
        }

        // PUT: api/TL_EventLog/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTL_EventLog(long id, TL_EventLog tL_EventLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tL_EventLog.ID)
            {
                return BadRequest();
            }

            db.Entry(tL_EventLog).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TL_EventLogExists(id))
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

        // POST: api/TL_EventLog
        [ResponseType(typeof(TL_EventLog))]
        public async Task<IHttpActionResult> PostTL_EventLog(TL_EventLog tL_EventLog)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TL_EventLog.Add(tL_EventLog);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tL_EventLog.ID }, tL_EventLog);
        }

        // DELETE: api/TL_EventLog/5
        [ResponseType(typeof(TL_EventLog))]
        public async Task<IHttpActionResult> DeleteTL_EventLog(long id)
        {
            TL_EventLog tL_EventLog = await db.TL_EventLog.FindAsync(id);
            if (tL_EventLog == null)
            {
                return NotFound();
            }

            db.TL_EventLog.Remove(tL_EventLog);
            await db.SaveChangesAsync();

            return Ok(tL_EventLog);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TL_EventLogExists(long id)
        {
            return db.TL_EventLog.Count(e => e.ID == id) > 0;
        }
    }
}