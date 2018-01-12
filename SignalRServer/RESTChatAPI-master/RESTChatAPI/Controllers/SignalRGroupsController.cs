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
    public class SignalRGroupsController : ApiController
    {
        private ChatContext db = new ChatContext();

        // GET: api/SignalRGroups
        public IQueryable<SignalRGroup> GetSignalRGroups()
        {
            return db.SignalRGroups;
        }

        // GET: api/SignalRGroups/5
        [ResponseType(typeof(SignalRGroup))]
        public async Task<IHttpActionResult> GetSignalRGroup(int id)
        {
            SignalRGroup signalRGroup = await db.SignalRGroups.FindAsync(id);
            if (signalRGroup == null)
            {
                return NotFound();
            }

            return Ok(signalRGroup);
        }

        // PUT: api/SignalRGroups/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSignalRGroup(int id, SignalRGroup signalRGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signalRGroup.GroupID)
            {
                return BadRequest();
            }

            db.Entry(signalRGroup).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignalRGroupExists(id))
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

        // POST: api/SignalRGroups
        [ResponseType(typeof(SignalRGroup))]
        public async Task<IHttpActionResult> PostSignalRGroup(SignalRGroup signalRGroup)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SignalRGroups.Add(signalRGroup);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = signalRGroup.GroupID }, signalRGroup);
        }

        // DELETE: api/SignalRGroups/5
        [ResponseType(typeof(SignalRGroup))]
        public async Task<IHttpActionResult> DeleteSignalRGroup(int id)
        {
            SignalRGroup signalRGroup = await db.SignalRGroups.FindAsync(id);
            if (signalRGroup == null)
            {
                return NotFound();
            }

            db.SignalRGroups.Remove(signalRGroup);
            await db.SaveChangesAsync();

            return Ok(signalRGroup);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignalRGroupExists(int id)
        {
            return db.SignalRGroups.Count(e => e.GroupID == id) > 0;
        }
    }
}