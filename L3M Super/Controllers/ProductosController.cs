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
    public class ProductosController : ApiController
    {
        /// <summary>
        /// Base de datos segun el contexto Productos
        /// </summary>
        private Productos2DbContext db = new Productos2DbContext();

        /// <summary>
        /// Obtiene todas los productos guardados en la base
        /// </summary>
        /// <returns>Productos almacenados</returns>
        // GET: api/Productos
        public IQueryable<Producto> GetProductos2()
        {
            return db.Productos2;
        }
        /// <summary>
        /// Obtiene un producto segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El producto con el id colocado</returns>
        // GET: api/Productos/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult GetProducto(int id)
        {
            Producto producto = db.Productos2.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        /// <summary>
        /// Metodo para modificar la entidad producto
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El producto con los datos modificados</returns>
        //GET: api/Productos/Sucursal
        [ResponseType(typeof(Trabajador))]
        [Route("api/Productos/Sucursal/{sucursal}")]
        public IHttpActionResult GetProductosSucursal(string sucursal)
        {
            ArrayList array = new ArrayList();

            foreach (Producto element in db.Productos2)
            {
                if (element.sucursalProducto.Equals(sucursal))
                {
                    array.Add(element);
                }
            }
            if(array.Count == 0)
            {
                return NotFound();
            }
            else
            {
                return Ok(array);
            }
            
        }


        /// <summary>
        /// Metodo para modificar la entidad producto
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El producto con los datos modificados</returns>
        // PUT: api/Productos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProducto(Producto producto)
        {
            int id = producto.codigoBarraProducto;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != producto.codigoBarraProducto)
            {
                return BadRequest();
            }

            db.Entry(producto).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductoExists(id))
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
        /// Metodo para agregar una nuevo producto a la base de datos
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El nuevo producto</returns>
        // POST: api/Productos
        [ResponseType(typeof(Producto))]
        public IHttpActionResult PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Productos2.Add(producto);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProductoExists(producto.codigoBarraProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = producto.codigoBarraProducto }, producto);
        }

        /// <summary>
        /// Elimina un producto de la base de datos segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna el producto eliminada</returns>
        // DELETE: api/Productos/5
        [ResponseType(typeof(Producto))]
        public IHttpActionResult DeleteProducto(int id)
        {
            Producto producto = db.Productos2.Find(id);
            if (producto == null)
            {
                return NotFound();
            }

            db.Productos2.Remove(producto);
            db.SaveChanges();

            return Ok(producto);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductoExists(int id)
        {
            return db.Productos2.Count(e => e.codigoBarraProducto == id) > 0;
        }
    }
}