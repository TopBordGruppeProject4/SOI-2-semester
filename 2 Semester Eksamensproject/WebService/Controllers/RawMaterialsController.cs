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
using WebService;

namespace WebService.Controllers
{
    public class RawMaterialsController : ApiController
    {
        private WorkerDBContext db = new WorkerDBContext();

        // GET: api/RawMaterials
        public IQueryable<RawMaterial> GetRawMaterials()
        {
            return db.RawMaterials;
        }

        // GET: api/RawMaterials/5
        [ResponseType(typeof(RawMaterial))]
        public IHttpActionResult GetRawMaterial(int id)
        {
            RawMaterial rawMaterial = db.RawMaterials.Find(id);
            if (rawMaterial == null)
            {
                return NotFound();
            }

            return Ok(rawMaterial);
        }

        // PUT: api/RawMaterials/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRawMaterial(int id, RawMaterial rawMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rawMaterial.Id)
            {
                return BadRequest();
            }

            db.Entry(rawMaterial).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RawMaterialExists(id))
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

        // POST: api/RawMaterials
        [ResponseType(typeof(RawMaterial))]
        public IHttpActionResult PostRawMaterial(RawMaterial rawMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RawMaterials.Add(rawMaterial);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rawMaterial.Id }, rawMaterial);
        }

        // DELETE: api/RawMaterials/5
        [ResponseType(typeof(RawMaterial))]
        public IHttpActionResult DeleteRawMaterial(int id)
        {
            RawMaterial rawMaterial = db.RawMaterials.Find(id);
            if (rawMaterial == null)
            {
                return NotFound();
            }

            db.RawMaterials.Remove(rawMaterial);
            db.SaveChanges();

            return Ok(rawMaterial);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RawMaterialExists(int id)
        {
            return db.RawMaterials.Count(e => e.Id == id) > 0;
        }
    }
}