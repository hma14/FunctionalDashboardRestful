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
    public class EventIDListsController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/EventIDLists
        public IQueryable<EventIDList> GetEventIDLists()
        {
            return db.EventIDLists;
        }

        // GET: api/EventIDLists/5
        [ResponseType(typeof(EventIDList))]
        public async Task<IHttpActionResult> GetEventIDList(int id)
        {
            EventIDList eventIDList = await db.EventIDLists.FindAsync(id);
            if (eventIDList == null)
            {
                return NotFound();
            }

            return Ok(eventIDList);
        }

        // PUT: api/EventIDLists/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventIDList(int id, EventIDList eventIDList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventIDList.EventID)
            {
                return BadRequest();
            }

            db.Entry(eventIDList).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventIDListExists(id))
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

        // POST: api/EventIDLists
        [ResponseType(typeof(EventIDList))]
        public async Task<IHttpActionResult> PostEventIDList(EventIDList eventIDList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EventIDLists.Add(eventIDList);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventIDList.EventID }, eventIDList);
        }

        // DELETE: api/EventIDLists/5
        [ResponseType(typeof(EventIDList))]
        public async Task<IHttpActionResult> DeleteEventIDList(int id)
        {
            EventIDList eventIDList = await db.EventIDLists.FindAsync(id);
            if (eventIDList == null)
            {
                return NotFound();
            }

            db.EventIDLists.Remove(eventIDList);
            await db.SaveChangesAsync();

            return Ok(eventIDList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventIDListExists(int id)
        {
            return db.EventIDLists.Count(e => e.EventID == id) > 0;
        }
    }
}