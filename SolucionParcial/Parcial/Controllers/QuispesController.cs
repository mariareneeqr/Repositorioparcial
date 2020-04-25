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
using Parcial.Models;

namespace Parcial.Controllers
{
    public class QuispesController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Quispes
        public IQueryable<Quispe> GetQuispes()
        {
            return db.Quispes;
        }

        // GET: api/Quispes/5
        [ResponseType(typeof(Quispe))]
        public IHttpActionResult GetQuispe(int id)
        {
            Quispe quispe = db.Quispes.Find(id);
            if (quispe == null)
            {
                return NotFound();
            }

            return Ok(quispe);
        }

        // PUT: api/Quispes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuispe(int id, Quispe quispe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quispe.QuispeId)
            {
                return BadRequest();
            }

            db.Entry(quispe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuispeExists(id))
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

        // POST: api/Quispes
        [ResponseType(typeof(Quispe))]
        public IHttpActionResult PostQuispe(Quispe quispe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quispes.Add(quispe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quispe.QuispeId }, quispe);
        }

        // DELETE: api/Quispes/5
        [ResponseType(typeof(Quispe))]
        public IHttpActionResult DeleteQuispe(int id)
        {
            Quispe quispe = db.Quispes.Find(id);
            if (quispe == null)
            {
                return NotFound();
            }

            db.Quispes.Remove(quispe);
            db.SaveChanges();

            return Ok(quispe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuispeExists(int id)
        {
            return db.Quispes.Count(e => e.QuispeId == id) > 0;
        }
    }
}