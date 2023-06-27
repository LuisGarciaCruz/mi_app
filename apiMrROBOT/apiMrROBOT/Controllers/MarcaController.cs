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
using apiMrROBOT.Models;

namespace apiMrROBOT.Controllers
{
    public class MarcaController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Marca
        public IQueryable<marca> Getmarca()
        {
            return db.marca;
        }

        // GET: api/Marca/5
        [ResponseType(typeof(marca))]
        public IHttpActionResult Getmarca(int id)
        {
            marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        // PUT: api/Marca/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putmarca(int id, marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != marca.IdMarca)
            {
                return BadRequest();
            }

            db.Entry(marca).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!marcaExists(id))
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

        // POST: api/Marca
        [ResponseType(typeof(marca))]
        public IHttpActionResult Postmarca(marca marca)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.marca.Add(marca);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = marca.IdMarca }, marca);
        }

        // DELETE: api/Marca/5
        [ResponseType(typeof(marca))]
        public IHttpActionResult Deletemarca(int id)
        {
            marca marca = db.marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            db.marca.Remove(marca);
            db.SaveChanges();

            return Ok(marca);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool marcaExists(int id)
        {
            return db.marca.Count(e => e.IdMarca == id) > 0;
        }
    }
}