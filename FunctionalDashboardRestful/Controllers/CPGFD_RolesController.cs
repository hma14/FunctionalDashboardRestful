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
    public class CPGFD_RolesController : ApiController
    {
        private UPASSDASHDEVContext db = new UPASSDASHDEVContext();

        // GET: api/CPGFD_Roles
        public IQueryable<CPGFD_Roles> GetCPGFD_Roles()
        {
            return db.CPGFD_Roles;
        }

        // GET: api/CPGFD_Roles/5
        [ResponseType(typeof(CPGFD_Roles))]
        public async Task<IHttpActionResult> GetCPGFD_Roles(int id)
        {
            CPGFD_Roles cPGFD_Roles = await db.CPGFD_Roles.FindAsync(id);
            if (cPGFD_Roles == null)
            {
                return NotFound();
            }

            return Ok(cPGFD_Roles);
        }

        // PUT: api/CPGFD_Roles/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCPGFD_Roles(int id, CPGFD_Roles cPGFD_Roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cPGFD_Roles.RoleID)
            {
                return BadRequest();
            }

            db.Entry(cPGFD_Roles).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CPGFD_RolesExists(id))
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

        // POST: api/CPGFD_Roles
        [ResponseType(typeof(CPGFD_Roles))]
        public async Task<IHttpActionResult> PostCPGFD_Roles(CPGFD_Roles cPGFD_Roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CPGFD_Roles.Add(cPGFD_Roles);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = cPGFD_Roles.RoleID }, cPGFD_Roles);
        }

        // DELETE: api/CPGFD_Roles/5
        [ResponseType(typeof(CPGFD_Roles))]
        public async Task<IHttpActionResult> DeleteCPGFD_Roles(int id)
        {
            CPGFD_Roles cPGFD_Roles = await db.CPGFD_Roles.FindAsync(id);
            if (cPGFD_Roles == null)
            {
                return NotFound();
            }

            db.CPGFD_Roles.Remove(cPGFD_Roles);
            await db.SaveChangesAsync();

            return Ok(cPGFD_Roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CPGFD_RolesExists(int id)
        {
            return db.CPGFD_Roles.Count(e => e.RoleID == id) > 0;
        }
    }
}