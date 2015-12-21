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
    public class CPGFD_ErrorListController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_ErrorList
        public IQueryable<CPGFD_ErrorList> GetCPGFD_ErrorList()
        {
            return db.CPGFD_ErrorList;
        }

        // GET: api/CPGFD_ErrorList/5
        [ResponseType(typeof(CPGFD_ErrorList))]
        public async Task<IHttpActionResult> GetCPGFD_ErrorList(int id)
        {
            CPGFD_ErrorList cPGFD_ErrorList = await db.CPGFD_ErrorList.FindAsync(id);
            if (cPGFD_ErrorList == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_ErrorList);
        }

        // PUT: api/CPGFD_ErrorList/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_ErrorList(int id, CPGFD_ErrorList cPGFD_ErrorList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_ErrorList.ID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_ErrorList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_ErrorListExists(id))
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

        // POST: api/CPGFD_ErrorList
        [ResponseType(typeof(CPGFD_ErrorList))]
        public async Task<IHttpActionResult> PostCPGFD_ErrorList(CPGFD_ErrorList cPGFD_ErrorList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_ErrorList.Add(cPGFD_ErrorList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_ErrorList.ID }, cPGFD_ErrorList);
        }

        // DELETE: api/CPGFD_ErrorList/5
        [ResponseType(typeof(CPGFD_ErrorList))]
        public async Task<IHttpActionResult> DeleteCPGFD_ErrorList(int id)
        {
            CPGFD_ErrorList cPGFD_ErrorList = await db.CPGFD_ErrorList.FindAsync(id);
            if (cPGFD_ErrorList == null)
            {
                return NotFound();
            }

            db.CPGFD_ErrorList.Remove(cPGFD_ErrorList);
            await db.SaveChangesAsync();

            return Ok(cPGFD_ErrorList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_ErrorListExists(int id)
        {
            return db.CPGFD_ErrorList.Count(e => e.ID == id) > 0;
        }
    }
}