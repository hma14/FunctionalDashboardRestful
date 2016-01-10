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
using FunctionalDashboardRestful.DTO;

namespace FunctionalDashboardRestful.Controllers
{
    public class CPGFD_SLTTrackingController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_SLTTracking
        [CacheClient(Duration = 120)]
        public IQueryable<SLTTrackingDto> GetCPGFD_SLTTracking()
        {
            var result = from s in db.CPGFD_SLTTracking
                         where s.Status == 2 || s.Status == 3
                         select new SLTTrackingDto
                         {
                             ProgramID = s.ProgramID,
                             InstitutionID = s.InstitutionID,
                             Institution = (from n in db.NCSInfoes where n.InstitutionId == s.InstitutionID select n.Name).FirstOrDefault(),
                             CategoryID = s.CategoryID,
                             Category = (from c in db.CategoryIDLists where c.CategoryID == s.CategoryID select c.CategoryName).FirstOrDefault(),
                             EventID = s.EventID,
                             Event = (from e in db.EventIDLists where e.EventID == s.EventID select e.EventName).FirstOrDefault(),
                             RuleDescription = s.RuleDescription,
                             SLTWarningDatetime = s.SLTWarningDatetime,
                             SLTBreachDatetime  = s.SLTBreachDatetime,
                             Status = s.Status
                         };

            return result;
        }

        // GET: api/CPGFD_SLTTracking/5
        [ResponseType(typeof(CPGFD_SLTTracking))]
        public async Task<IHttpActionResult> GetCPGFD_SLTTracking(long id)
        {
            CPGFD_SLTTracking cPGFD_SLTTracking = await db.CPGFD_SLTTracking.FindAsync(id);
            if (cPGFD_SLTTracking == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_SLTTracking);
        }

        // PUT: api/CPGFD_SLTTracking/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_SLTTracking(long id, CPGFD_SLTTracking cPGFD_SLTTracking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_SLTTracking.ID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_SLTTracking).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_SLTTrackingExists(id))
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

        // POST: api/CPGFD_SLTTracking
        [ResponseType(typeof(CPGFD_SLTTracking))]
        public async Task<IHttpActionResult> PostCPGFD_SLTTracking(CPGFD_SLTTracking cPGFD_SLTTracking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_SLTTracking.Add(cPGFD_SLTTracking);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_SLTTracking.ID }, cPGFD_SLTTracking);
        }

        // DELETE: api/CPGFD_SLTTracking/5
        [ResponseType(typeof(CPGFD_SLTTracking))]
        public async Task<IHttpActionResult> DeleteCPGFD_SLTTracking(long id)
        {
            CPGFD_SLTTracking cPGFD_SLTTracking = await db.CPGFD_SLTTracking.FindAsync(id);
            if (cPGFD_SLTTracking == null)
            {
                return NotFound();
            }

            db.CPGFD_SLTTracking.Remove(cPGFD_SLTTracking);
            await db.SaveChangesAsync();

            return Ok(cPGFD_SLTTracking);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_SLTTrackingExists(long id)
        {
            return db.CPGFD_SLTTracking.Count(e => e.ID == id) > 0;
        }
    }
}