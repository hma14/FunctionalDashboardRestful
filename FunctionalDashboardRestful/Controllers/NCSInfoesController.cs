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
    public class NCSInfoesController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/NCSInfoes
        public IQueryable<NCSInfo> GetNCSInfoes()
        {
            return db.NCSInfoes;
        }

        // GET: api/NCSInfoes/5
        [ResponseType(typeof(NCSInfo))]
        public async Task<IHttpActionResult> GetNCSInfo(string id)
        {
            NCSInfo nCSInfo = await db.NCSInfoes.FindAsync(id);
            if (nCSInfo == null)
            {
                return NotFound();
            }

            return Ok(nCSInfo);
        }

        // PUT: api/NCSInfoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNCSInfo(string id, NCSInfo nCSInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCSInfo.InstitutionId)
            {
                return BadRequest();
            }

            db.Entry(nCSInfo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCSInfoExists(id))
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

        // POST: api/NCSInfoes
        [ResponseType(typeof(NCSInfo))]
        public async Task<IHttpActionResult> PostNCSInfo(NCSInfo nCSInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCSInfoes.Add(nCSInfo);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NCSInfoExists(nCSInfo.InstitutionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCSInfo.InstitutionId }, nCSInfo);
        }

        // DELETE: api/NCSInfoes/5
        [ResponseType(typeof(NCSInfo))]
        public async Task<IHttpActionResult> DeleteNCSInfo(string id)
        {
            NCSInfo nCSInfo = await db.NCSInfoes.FindAsync(id);
            if (nCSInfo == null)
            {
                return NotFound();
            }

            db.NCSInfoes.Remove(nCSInfo);
            await db.SaveChangesAsync();

            return Ok(nCSInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCSInfoExists(string id)
        {
            return db.NCSInfoes.Count(e => e.InstitutionId == id) > 0;
        }
    }
}