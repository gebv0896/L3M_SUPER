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
using Newtonsoft.Json.Linq;

namespace L3M_Super.Controllers
{
    public class TrabajadoresController : ApiController
    {
        private TrabajadoresDbContext db = new TrabajadoresDbContext();

        // GET: api/Trabajadores
        public IQueryable<Trabajador> GetTrabajadores()
        {
            return db.Trabajadores;
        }

        // GET: api/Trabajadores/5
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

        [ResponseType(typeof(Trabajador))]
        [Route("api/Trabajadores/Planilla")]
        public IHttpActionResult GetPlanilla()
        {
        string planilla= "{" +
        "cedulaTrabajador: 30323112" + "," +
        "nombreCompletoTrabajador: Milton Villegas" + "," +
    "fechaNacimientoTrabajador: 23/3/1972" + "," +
        "fechaIngresoTrabajador: 14/10/1996" + "," +
        "sucursalTrabajador: MIT" + "," +
        "salarioHoraTrabajador: 500" + "," +
        "horasLaboradasTrabajador: 40" + "," +
        "horasExtraTrabajador: 10000" +
    "}" + "," +
    "{" +
        "cedulaTrabajador: 303230875" + "," +
        "nombreCompletoTrabajador: Marco Hernandez" + "," +
        "fechaNacimientoTrabajador: 10/8/1985" + "," +
        "fechaIngresoTrabajador: 2/7/2006" + "," +
        "sucursalTrabajador: HP" + "," +
        "salarioHoraTrabajador: 500" + "," +
        "horasLaboradasTrabajador: 50" + "," +
        "horasExtraTrabajador: 20" +
    "}" + "," +
    "{" +
        "cedulaTrabajador: 303730849" + "," +
        "nombreCompletoTrabajador: Marco Rivera" + "," +
        "fechaNacimientoTrabajador: 05/06/1981" + "," +
        "fechaIngresoTrabajador: 24/12/2014" + "," +
        "sucursalTrabajador: Procter & Gamble" + "," +
        "salarioHoraTrabajador: 500" + "," +
        "horasLaboradasTrabajador: 20" + "," +
       " horasExtraTrabajador: 0" +
    "}";

            // JObject json = JObject.Parse(planilla);
            /*
             Trabajador trabajador = db.Trabajadores.Find(id);
             if (trabajador == null)
             {
                 return NotFound();
             }
             */
            return Ok(planilla);
        }


        // PUT: api/Trabajadores/5
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

        // DELETE: api/Trabajadores/5
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