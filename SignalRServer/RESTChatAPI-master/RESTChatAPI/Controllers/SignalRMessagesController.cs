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
    public class SignalRMessagesController : ApiController
    {
        private ChatContext db = new ChatContext();

        // GET: api/SignalRMessages
        public IQueryable<SignalRMessage> GetSignalRMessages()
        {
            return db.SignalRMessages;
        }

        // GET: api/SignalRMessages/5
        [ResponseType(typeof(SignalRMessage))]
        public async Task<IHttpActionResult> GetSignalRMessage(int id)
        {
            SignalRMessage signalRMessage = await db.SignalRMessages.FindAsync(id);
            if (signalRMessage == null)
            {
                return NotFound();
            }

            return Ok(signalRMessage);
        }

        // PUT: api/SignalRMessages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSignalRMessage(int id, SignalRMessage signalRMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != signalRMessage.MessageID)
            {
                return BadRequest();
            }

            db.Entry(signalRMessage).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SignalRMessageExists(id))
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

        // POST: api/SignalRMessages
        [ResponseType(typeof(SignalRMessage))]
        public async Task<IHttpActionResult> PostSignalRMessage(SignalRMessage signalRMessage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SignalRMessages.Add(signalRMessage);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = signalRMessage.MessageID }, signalRMessage);
        }

        // DELETE: api/SignalRMessages/5
        [ResponseType(typeof(SignalRMessage))]
        public async Task<IHttpActionResult> DeleteSignalRMessage(int id)
        {
            SignalRMessage signalRMessage = await db.SignalRMessages.FindAsync(id);
            if (signalRMessage == null)
            {
                return NotFound();
            }

            db.SignalRMessages.Remove(signalRMessage);
            await db.SaveChangesAsync();

            return Ok(signalRMessage);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SignalRMessageExists(int id)
        {
            return db.SignalRMessages.Count(e => e.MessageID == id) > 0;
        }
    }
}