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
    public class CPGFD_ErrorExceptionsController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_ErrorExceptions
        public IQueryable<CPGFD_ErrorExceptions> GetCPGFD_ErrorExceptions()
        {
            return db.CPGFD_ErrorExceptions;
        }

        // GET: api/CPGFD_ErrorExceptions/5
        [ResponseType(typeof(CPGFD_ErrorExceptions))]
        public async Task<IHttpActionResult> GetCPGFD_ErrorExceptions(int id)
        {
            CPGFD_ErrorExceptions cPGFD_ErrorExceptions = await db.CPGFD_ErrorExceptions.FindAsync(id);
            if (cPGFD_ErrorExceptions == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_ErrorExceptions);
        }

        // PUT: api/CPGFD_ErrorExceptions/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_ErrorExceptions(int id, CPGFD_ErrorExceptions cPGFD_ErrorExceptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_ErrorExceptions.ID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_ErrorExceptions).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_ErrorExceptionsExists(id))
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

        // POST: api/CPGFD_ErrorExceptions
        [ResponseType(typeof(CPGFD_ErrorExceptions))]
        public async Task<IHttpActionResult> PostCPGFD_ErrorExceptions(CPGFD_ErrorExceptions cPGFD_ErrorExceptions)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_ErrorExceptions.Add(cPGFD_ErrorExceptions);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_ErrorExceptions.ID }, cPGFD_ErrorExceptions);
        }

        // DELETE: api/CPGFD_ErrorExceptions/5
        [ResponseType(typeof(CPGFD_ErrorExceptions))]
        public async Task<IHttpActionResult> DeleteCPGFD_ErrorExceptions(int id)
        {
            CPGFD_ErrorExceptions cPGFD_ErrorExceptions = await db.CPGFD_ErrorExceptions.FindAsync(id);
            if (cPGFD_ErrorExceptions == null)
            {
                return NotFound();
            }

            db.CPGFD_ErrorExceptions.Remove(cPGFD_ErrorExceptions);
            await db.SaveChangesAsync();

            return Ok(cPGFD_ErrorExceptions);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_ErrorExceptionsExists(int id)
        {
            return db.CPGFD_ErrorExceptions.Count(e => e.ID == id) > 0;
        }
    }
}