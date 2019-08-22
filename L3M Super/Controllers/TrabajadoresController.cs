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
using System.Web.Script.Serialization;
using L3M_Super.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace L3M_Super.Controllers
{
    public class TrabajadoresController : ApiController
    {
        /// <summary>
        /// Base de datos segun el contexto Trabajadores
        /// </summary>
        private TrabajadoresDbContext db = new TrabajadoresDbContext();

        /// <summary>
        /// Obtiene todas los trabajadores guardados en la base
        /// </summary>
        /// <returns>Trabajadores almacenados</returns>
        // GET: api/Trabajadores
        public IQueryable<Trabajador> GetTrabajadores()
        {
            return db.Trabajadores;
        }

        /// <summary>
        /// Obtiene un trabajador segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>El trabajador con el id colocado</returns>
        // GET: api/Trabajadores/id
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult GetTrabajador(int id)
        {
            Trabajador trabajador = db.Trabajadores.Find(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            return Ok(trabajador);
        }

        /// <summary>
        /// Metodo para obtener a los trabajadores que han trabajado, es decir que sus horas no son 0
        /// </summary>
        /// <returns>Lista de trabajadores que con horas</returns>
        //GET: api/Trabajadores/Planilla
        [ResponseType(typeof(Trabajador))]
        [Route("api/Trabajadores/Planilla")]
        public IHttpActionResult GetPlanilla()
        {
            ArrayList array = new ArrayList();

            foreach (Trabajador element in db.Trabajadores)
            {
                if (element.horasLaboradasTrabajador!=0) {
                    array.Add(element);
                }
            }
            return Ok(array);
        }

        /// <summary>
        /// Metodo para modificar la entidad trabajador
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El trabajador con los datos modificados</returns>
        // PUT: api/Trabajadores
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrabajador(Trabajador trabajador)
        {
            int id = trabajador.cedulaTrabajador;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trabajador.cedulaTrabajador)
            {
                return BadRequest();
            }

            db.Entry(trabajador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrabajadorExists(id))
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
        /// Metodo para agregar una nuevo Trabajador a la base de datos
        /// </summary>
        /// <param name="sucursal"></param>
        /// <returns>El nuevo Trabajador</returns>
        // POST: api/Trabajadores
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult PostTrabajador(Trabajador trabajador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trabajadores.Add(trabajador);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TrabajadorExists(trabajador.cedulaTrabajador))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = trabajador.cedulaTrabajador }, trabajador);
        }

        /// <summary>
        /// Elimina un trabajador de la base de datos segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna el trabajador eliminada</returns>
        // DELETE: api/Trabajadores/id
        [ResponseType(typeof(Trabajador))]
        public IHttpActionResult DeleteTrabajador(int id)
        {
            Trabajador trabajador = db.Trabajadores.Find(id);
            if (trabajador == null)
            {
                return NotFound();
            }

            db.Trabajadores.Remove(trabajador);
            db.SaveChanges();

            return Ok(trabajador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrabajadorExists(int id)
        {
            return db.Trabajadores.Count(e => e.cedulaTrabajador == id) > 0;
        }
    }
}