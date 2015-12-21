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
    public class CPGFD_UsersController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_Users
        public IQueryable<CPGFD_Users> GetCPGFD_Users()
        {
            return db.CPGFD_Users;
        }

        // GET: api/CPGFD_Users/5
        [ResponseType(typeof(CPGFD_Users))]
        public async Task<IHttpActionResult> GetCPGFD_Users(int id)
        {
            CPGFD_Users cPGFD_Users = await db.CPGFD_Users.FindAsync(id);
            if (cPGFD_Users == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_Users);
        }

        // PUT: api/CPGFD_Users/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_Users(int id, CPGFD_Users cPGFD_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_Users.UserID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_Users).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_UsersExists(id))
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

        // POST: api/CPGFD_Users
        [ResponseType(typeof(CPGFD_Users))]
        public async Task<IHttpActionResult> PostCPGFD_Users(CPGFD_Users cPGFD_Users)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_Users.Add(cPGFD_Users);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_Users.UserID }, cPGFD_Users);
        }

        // DELETE: api/CPGFD_Users/5
        [ResponseType(typeof(CPGFD_Users))]
        public async Task<IHttpActionResult> DeleteCPGFD_Users(int id)
        {
            CPGFD_Users cPGFD_Users = await db.CPGFD_Users.FindAsync(id);
            if (cPGFD_Users == null)
            {
                return NotFound();
            }

            db.CPGFD_Users.Remove(cPGFD_Users);
            await db.SaveChangesAsync();

            return Ok(cPGFD_Users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_UsersExists(int id)
        {
            return db.CPGFD_Users.Count(e => e.UserID == id) > 0;
        }
    }
}