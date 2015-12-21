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
    public class CPGFD_KBController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_KB
        public IQueryable<CPGFD_KB> GetCPGFD_KB()
        {
            return db.CPGFD_KB;
        }

        // GET: api/CPGFD_KB/5
        [ResponseType(typeof(CPGFD_KB))]
        public async Task<IHttpActionResult> GetCPGFD_KB(int id)
        {
            CPGFD_KB cPGFD_KB = await db.CPGFD_KB.FindAsync(id);
            if (cPGFD_KB == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_KB);
        }

        // PUT: api/CPGFD_KB/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_KB(int id, CPGFD_KB cPGFD_KB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_KB.ID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_KB).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_KBExists(id))
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

        // POST: api/CPGFD_KB
        [ResponseType(typeof(CPGFD_KB))]
        public async Task<IHttpActionResult> PostCPGFD_KB(CPGFD_KB cPGFD_KB)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_KB.Add(cPGFD_KB);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_KB.ID }, cPGFD_KB);
        }

        // DELETE: api/CPGFD_KB/5
        [ResponseType(typeof(CPGFD_KB))]
        public async Task<IHttpActionResult> DeleteCPGFD_KB(int id)
        {
            CPGFD_KB cPGFD_KB = await db.CPGFD_KB.FindAsync(id);
            if (cPGFD_KB == null)
            {
                return NotFound();
            }

            db.CPGFD_KB.Remove(cPGFD_KB);
            await db.SaveChangesAsync();

            return Ok(cPGFD_KB);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_KBExists(int id)
        {
            return db.CPGFD_KB.Count(e => e.ID == id) > 0;
        }
    }
}