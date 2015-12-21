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
    public class CPGFD_ErrorMsgController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_ErrorMsg
        public IQueryable<CPGFD_ErrorMsg> GetCPGFD_ErrorMsg()
        {
            return db.CPGFD_ErrorMsg;
        }

        // GET: api/CPGFD_ErrorMsg/5
        [ResponseType(typeof(CPGFD_ErrorMsg))]
        public async Task<IHttpActionResult> GetCPGFD_ErrorMsg(int id)
        {
            CPGFD_ErrorMsg cPGFD_ErrorMsg = await db.CPGFD_ErrorMsg.FindAsync(id);
            if (cPGFD_ErrorMsg == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_ErrorMsg);
        }

        // PUT: api/CPGFD_ErrorMsg/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_ErrorMsg(int id, CPGFD_ErrorMsg cPGFD_ErrorMsg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_ErrorMsg.ID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_ErrorMsg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_ErrorMsgExists(id))
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

        // POST: api/CPGFD_ErrorMsg
        [ResponseType(typeof(CPGFD_ErrorMsg))]
        public async Task<IHttpActionResult> PostCPGFD_ErrorMsg(CPGFD_ErrorMsg cPGFD_ErrorMsg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_ErrorMsg.Add(cPGFD_ErrorMsg);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_ErrorMsg.ID }, cPGFD_ErrorMsg);
        }

        // DELETE: api/CPGFD_ErrorMsg/5
        [ResponseType(typeof(CPGFD_ErrorMsg))]
        public async Task<IHttpActionResult> DeleteCPGFD_ErrorMsg(int id)
        {
            CPGFD_ErrorMsg cPGFD_ErrorMsg = await db.CPGFD_ErrorMsg.FindAsync(id);
            if (cPGFD_ErrorMsg == null)
            {
                return NotFound();
            }

            db.CPGFD_ErrorMsg.Remove(cPGFD_ErrorMsg);
            await db.SaveChangesAsync();

            return Ok(cPGFD_ErrorMsg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_ErrorMsgExists(int id)
        {
            return db.CPGFD_ErrorMsg.Count(e => e.ID == id) > 0;
        }
    }
}