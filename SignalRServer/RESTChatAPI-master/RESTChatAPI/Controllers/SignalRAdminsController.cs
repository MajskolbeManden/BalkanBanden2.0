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
using RESTChatAPI;

namespace RESTChatAPI.Controllers
{
    public class SignalRAdminsController : ApiController
    {
        private ChatContext db = new ChatContext();

        // GET: api/SignalRAdmins
        public IQueryable<SignalRAdmin> GetSignalRAdmins()
        {
            return db.SignalRAdmins;
        }

        // GET: api/SignalRAdmins/5
        [ResponseType(typeof(SignalRAdmin))]
        public async Task<IHttpActionResult> GetSignalRAdmin(int id)
        {
            SignalRAdmin signalRAdmin = await db.SignalRAdmins.FindAsync(id);
            if (signalRAdmin == null)
            {
                return NotFound();
            }

            return Ok(signalRAdmin);
        }

        // PUT: api/SignalRAdmins/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSignalRAdmin(int id, SignalRAdmin signalRAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signalRAdmin.AdminID)
            {
                return BadRequest();
            }

            db.Entry(signalRAdmin).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignalRAdminExists(id))
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

        // POST: api/SignalRAdmins
        [ResponseType(typeof(SignalRAdmin))]
        public async Task<IHttpActionResult> PostSignalRAdmin(SignalRAdmin signalRAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SignalRAdmins.Add(signalRAdmin);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = signalRAdmin.AdminID }, signalRAdmin);
        }

        // DELETE: api/SignalRAdmins/5
        [ResponseType(typeof(SignalRAdmin))]
        public async Task<IHttpActionResult> DeleteSignalRAdmin(int id)
        {
            SignalRAdmin signalRAdmin = await db.SignalRAdmins.FindAsync(id);
            if (signalRAdmin == null)
            {
                return NotFound();
            }

            db.SignalRAdmins.Remove(signalRAdmin);
            await db.SaveChangesAsync();

            return Ok(signalRAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignalRAdminExists(int id)
        {
            return db.SignalRAdmins.Count(e => e.AdminID == id) > 0;
        }
    }
}