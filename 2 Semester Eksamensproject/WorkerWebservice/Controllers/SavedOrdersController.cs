using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WorkerWebservice;

namespace WorkerWebservice.Controllers
{
    public class SavedOrdersController : ApiController
    {
        private DbWorkerContext db = new DbWorkerContext();

        // GET: api/SavedOrders
        public IQueryable<SavedOrder> GetSavedOrders()
        {
            return db.SavedOrders;
        }

        // GET: api/SavedOrders/5
        [ResponseType(typeof(SavedOrder))]
        public IHttpActionResult GetSavedOrder(int id)
        {
            SavedOrder savedOrder = db.SavedOrders.Find(id);
            if (savedOrder == null)
            {
                return NotFound();
            }

            return Ok(savedOrder);
        }

        // PUT: api/SavedOrders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSavedOrder(int id, SavedOrder savedOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != savedOrder.Id)
            {
                return BadRequest();
            }

            db.Entry(savedOrder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SavedOrderExists(id))
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

        // POST: api/SavedOrders
        [ResponseType(typeof(SavedOrder))]
        public IHttpActionResult PostSavedOrder(SavedOrder savedOrder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SavedOrders.Add(savedOrder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = savedOrder.Id }, savedOrder);
        }

        // DELETE: api/SavedOrders/5
        [ResponseType(typeof(SavedOrder))]
        public IHttpActionResult DeleteSavedOrder(int id)
        {
            SavedOrder savedOrder = db.SavedOrders.Find(id);
            if (savedOrder == null)
            {
                return NotFound();
            }

            db.SavedOrders.Remove(savedOrder);
            db.SaveChanges();

            return Ok(savedOrder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SavedOrderExists(int id)
        {
            return db.SavedOrders.Count(e => e.Id == id) > 0;
        }
    }
}