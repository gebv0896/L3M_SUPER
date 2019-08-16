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
    public class SucursalesController : ApiController
    {
        private Sucursales2DbContext db = new Sucursales2DbContext();

        // GET: api/Sucursales
        public IQueryable<Sucursal> GetSucursales2()
        {
            return db.Sucursales2;
        }

        // GET: api/Sucursales/5
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult GetSucursal(string id)
        {
            Sucursal sucursal = db.Sucursales2.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return Ok(sucursal);
        }

        // PUT: api/Sucursales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSucursal(Sucursal sucursal)
        {

            string id = sucursal.nombreSucursal;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sucursal.nombreSucursal)
            {
                return BadRequest();
            }

            db.Entry(sucursal).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExists(id))
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

        // POST: api/Sucursales
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult PostSucursal(Sucursal sucursal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sucursales2.Add(sucursal);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SucursalExists(sucursal.nombreSucursal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sucursal.nombreSucursal }, sucursal);
        }

        // DELETE: api/Sucursales/5
        [ResponseType(typeof(Sucursal))]
        public IHttpActionResult DeleteSucursal(string id)
        {
            Sucursal sucursal = db.Sucursales2.Find(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            db.Sucursales2.Remove(sucursal);
            db.SaveChanges();

            return Ok(sucursal);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SucursalExists(string id)
        {
            return db.Sucursales2.Count(e => e.nombreSucursal == id) > 0;
        }
    }
}