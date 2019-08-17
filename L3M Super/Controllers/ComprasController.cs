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
using L3M_Super.Models;

namespace L3M_Super.Controllers
{
    public class ComprasController : ApiController
    {
        private ComprasDbContext db = new ComprasDbContext();

        // GET: api/Compras
        public IQueryable<Compra> GetCompras()
        {
            return db.Compras;
        }

        // GET: api/Compras/id
        [ResponseType(typeof(Compra))]
        public IHttpActionResult GetCompra(string id)
        {
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return NotFound();
            }

            return Ok(compra);
        }

        // PUT: api/Compras
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompra(Compra compra)
        {
            string id = compra.fotoCompra;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compra.fotoCompra)
            {
                return BadRequest();
            }

            db.Entry(compra).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
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

        // POST: api/Compras
        [ResponseType(typeof(Compra))]
        public IHttpActionResult PostCompra(Compra compra)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Compras.Add(compra);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CompraExists(compra.fotoCompra))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = compra.fotoCompra }, compra);
        }

        // DELETE: api/Compras/id
        [ResponseType(typeof(Compra))]
        public IHttpActionResult DeleteCompra(string id)
        {
            Compra compra = db.Compras.Find(id);
            if (compra == null)
            {
                return NotFound();
            }

            db.Compras.Remove(compra);
            db.SaveChanges();

            return Ok(compra);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompraExists(string id)
        {
            return db.Compras.Count(e => e.fotoCompra == id) > 0;
        }
    }
}