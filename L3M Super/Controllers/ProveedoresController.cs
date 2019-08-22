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
        /// <summary>
        /// Base de datos segun el contexto Proveedores
        /// </summary>
        private ProveedoresDbContext db = new ProveedoresDbContext();

        /// <summary>
        /// Obtiene todas los proveedores guardados en la base
        /// </summary>
        /// <returns>Proveedores almacenados</returns>
        // GET: api/Proveedores
        public IQueryable<Proveedor> GetProveedores()
        {
            return db.Proveedores;
        }
        /// <summary>
        /// Obtiene un proveedor segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El proveedor con el id colocado</returns>
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

        /// <summary>
        /// Metodo para modificar la entidad proveedor
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El proveedor con los datos modificados</returns>
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

        /// <summary>
        /// Metodo para agregar una nuevo rol a la base de datos
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El nuevo Rol</returns>
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

        /// <summary>
        /// Elimina un proveedor de la base de datos segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna el proveedor eliminada</returns>
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