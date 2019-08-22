using System;
using System.Collections;
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
        /// <summary>
        /// Base de datos segun el contexto sucursal
        /// </summary>
        private Sucursales2DbContext db = new Sucursales2DbContext();

        // GET: api/Sucursales
        /// <summary>
        /// Obtiene todas las sucursales guardadas en la base
        /// </summary>
        /// <returns>Sucursales almacenadas</returns>
        public IQueryable<Sucursal> GetSucursales2()
        {
            return db.Sucursales2;
        }
        /// <summary>
        /// Obtiene una sucursal segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La sucursal con el id colocado</returns>
        // GET: api/Sucursales/id
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

        /// <summary>
        /// Metodo para modificar la entidad sucursal
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>La sucursal con los datos modificados</returns>
        // PUT: api/Sucursales
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
        /// <summary>
        /// Metodo para agregar una nueva sucursal a la base de datos
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>La nueva sucursal</returns>
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
        /// <summary>
        /// Elimina una sucursal de la base de datos segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna la sucursal eliminada</returns>
        // DELETE: api/Sucursales/id
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