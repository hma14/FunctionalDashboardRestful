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
    public class CPGFD_UsersInRolesController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_UsersInRoles
        public IQueryable<CPGFD_UsersInRoles> GetCPGFD_UsersInRoles()
        {
            return db.CPGFD_UsersInRoles;
        }

        // GET: api/CPGFD_UsersInRoles/5
        [ResponseType(typeof(CPGFD_UsersInRoles))]
        public async Task<IHttpActionResult> GetCPGFD_UsersInRoles(int id)
        {
            CPGFD_UsersInRoles cPGFD_UsersInRoles = await db.CPGFD_UsersInRoles.FindAsync(id);
            if (cPGFD_UsersInRoles == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_UsersInRoles);
        }

        // PUT: api/CPGFD_UsersInRoles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_UsersInRoles(int id, CPGFD_UsersInRoles cPGFD_UsersInRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_UsersInRoles.RoleID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_UsersInRoles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_UsersInRolesExists(id))
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

        // POST: api/CPGFD_UsersInRoles
        [ResponseType(typeof(CPGFD_UsersInRoles))]
        public async Task<IHttpActionResult> PostCPGFD_UsersInRoles(CPGFD_UsersInRoles cPGFD_UsersInRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_UsersInRoles.Add(cPGFD_UsersInRoles);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_UsersInRoles.RoleID }, cPGFD_UsersInRoles);
        }

        // DELETE: api/CPGFD_UsersInRoles/5
        [ResponseType(typeof(CPGFD_UsersInRoles))]
        public async Task<IHttpActionResult> DeleteCPGFD_UsersInRoles(int id)
        {
            CPGFD_UsersInRoles cPGFD_UsersInRoles = await db.CPGFD_UsersInRoles.FindAsync(id);
            if (cPGFD_UsersInRoles == null)
            {
                return NotFound();
            }

            db.CPGFD_UsersInRoles.Remove(cPGFD_UsersInRoles);
            await db.SaveChangesAsync();

            return Ok(cPGFD_UsersInRoles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_UsersInRolesExists(int id)
        {
            return db.CPGFD_UsersInRoles.Count(e => e.RoleID == id) > 0;
        }
    }
}