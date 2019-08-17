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
    public class ProveedoresController : ApiController
    {
        private ProveedoresDbContext db = new ProveedoresDbContext();

        // GET: api/Proveedores
        public IQueryable<Proveedor> GetProveedores()
        {
            return db.Proveedores;
        }

        // GET: api/Proveedores/id
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult GetProveedor(string id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        // PUT: api/Proveedores
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProveedor(Proveedor proveedor)
        {
            string id = proveedor.cedulaProveedor;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedor.cedulaProveedor)
            {
                return BadRequest();
            }

            db.Entry(proveedor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedorExists(id))
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

        // POST: api/Proveedores
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult PostProveedor(Proveedor proveedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proveedores.Add(proveedor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProveedorExists(proveedor.cedulaProveedor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = proveedor.cedulaProveedor }, proveedor);
        }

        // DELETE: api/Proveedores/id
        [ResponseType(typeof(Proveedor))]
        public IHttpActionResult DeleteProveedor(string id)
        {
            Proveedor proveedor = db.Proveedores.Find(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            db.Proveedores.Remove(proveedor);
            db.SaveChanges();

            return Ok(proveedor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedorExists(string id)
        {
            return db.Proveedores.Count(e => e.cedulaProveedor == id) > 0;
        }
    }
}