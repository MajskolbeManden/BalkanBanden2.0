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
    public class SignalRUsersController : ApiController
    {
        private ChatContext db = new ChatContext();

        // GET: api/SignalRUsers
        public IQueryable<SignalRUser> GetSignalRUsers()
        {
            return db.SignalRUsers;
        }
        
        // GET: api/SignalRUsers/5
        [ResponseType(typeof(SignalRUser))]
        public async Task<IHttpActionResult> GetSignalRUser(int id)
        {
            SignalRUser signalRUser = await db.SignalRUsers.FindAsync(id);
            if (signalRUser == null)
            {
                return NotFound();
            }

            return Ok(signalRUser);
        }

        // PUT: api/SignalRUsers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSignalRUser(int id, SignalRUser signalRUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signalRUser.UserID)
            {
                return BadRequest();
            }

            db.Entry(signalRUser).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignalRUserExists(id))
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

        // POST: api/SignalRUsers
        [ResponseType(typeof(SignalRUser))]
        public async Task<IHttpActionResult> PostSignalRUser(SignalRUser signalRUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SignalRUsers.Add(signalRUser);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = signalRUser.UserID }, signalRUser);
        }

        // DELETE: api/SignalRUsers/5
        [ResponseType(typeof(SignalRUser))]
        public async Task<IHttpActionResult> DeleteSignalRUser(int id)
        {
            SignalRUser signalRUser = await db.SignalRUsers.FindAsync(id);
            if (signalRUser == null)
            {
                return NotFound();
            }

            db.SignalRUsers.Remove(signalRUser);
            await db.SaveChangesAsync();

            return Ok(signalRUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignalRUserExists(int id)
        {
            return db.SignalRUsers.Count(e => e.UserID == id) > 0;
        }
    }
}