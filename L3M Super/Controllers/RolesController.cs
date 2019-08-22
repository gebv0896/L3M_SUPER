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
    public class RolesController : ApiController
    {
        /// <summary>
        /// Base de datos segun el contexto Roles
        /// </summary>
        private RolesDbContext db = new RolesDbContext();

        /// <summary>
        /// Obtiene todas las roles guardados en la base
        /// </summary>
        /// <returns>Roles almacenados</returns>
        // GET: api/Roles
        public IQueryable<Rol> GetRoles()
        {
            return db.Roles;
        }

        /// <summary>
        /// Obtiene un rol segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El rol con el id colocado</returns>
        // GET: api/Roles/id
        [ResponseType(typeof(Rol))]
        public IHttpActionResult GetRol(string id)
        {
            Rol rol = db.Roles.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        /// <summary>
        /// Metodo para modificar la entidad rol
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El rol con los datos modificados</returns>
        // PUT: api/Roles
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRol(Rol rol)
        {
            string id = rol.nombreRol;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rol.nombreRol)
            {
                return BadRequest();
            }

            db.Entry(rol).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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
        // POST: api/Roles
        [ResponseType(typeof(Rol))]
        public IHttpActionResult PostRol(Rol rol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(rol);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RolExists(rol.nombreRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = rol.nombreRol }, rol);
        }

        /// <summary>
        /// Elimina un rol de la base de datos segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna el rol eliminada</returns>
        // DELETE: api/Roles/id
        [ResponseType(typeof(Rol))]
        public IHttpActionResult DeleteRol(string id)
        {
            Rol rol = db.Roles.Find(id);
            if (rol == null)
            {
                return NotFound();
            }

            db.Roles.Remove(rol);
            db.SaveChanges();

            return Ok(rol);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolExists(string id)
        {
            return db.Roles.Count(e => e.nombreRol == id) > 0;
        }
    }
}