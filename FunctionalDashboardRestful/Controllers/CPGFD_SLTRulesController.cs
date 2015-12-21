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
    public class CPGFD_SLTRulesController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_SLTRules
        public IQueryable<CPGFD_SLTRules> GetCPGFD_SLTRules()
        {
            return db.CPGFD_SLTRules;
        }

        // GET: api/CPGFD_SLTRules/5
        [ResponseType(typeof(CPGFD_SLTRules))]
        public async Task<IHttpActionResult> GetCPGFD_SLTRules(int id)
        {
            CPGFD_SLTRules cPGFD_SLTRules = await db.CPGFD_SLTRules.FindAsync(id);
            if (cPGFD_SLTRules == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_SLTRules);
        }

        // PUT: api/CPGFD_SLTRules/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_SLTRules(int id, CPGFD_SLTRules cPGFD_SLTRules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_SLTRules.ID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_SLTRules).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_SLTRulesExists(id))
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

        // POST: api/CPGFD_SLTRules
        [ResponseType(typeof(CPGFD_SLTRules))]
        public async Task<IHttpActionResult> PostCPGFD_SLTRules(CPGFD_SLTRules cPGFD_SLTRules)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_SLTRules.Add(cPGFD_SLTRules);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_SLTRules.ID }, cPGFD_SLTRules);
        }

        // DELETE: api/CPGFD_SLTRules/5
        [ResponseType(typeof(CPGFD_SLTRules))]
        public async Task<IHttpActionResult> DeleteCPGFD_SLTRules(int id)
        {
            CPGFD_SLTRules cPGFD_SLTRules = await db.CPGFD_SLTRules.FindAsync(id);
            if (cPGFD_SLTRules == null)
            {
                return NotFound();
            }

            db.CPGFD_SLTRules.Remove(cPGFD_SLTRules);
            await db.SaveChangesAsync();

            return Ok(cPGFD_SLTRules);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_SLTRulesExists(int id)
        {
            return db.CPGFD_SLTRules.Count(e => e.ID == id) > 0;
        }
    }
}