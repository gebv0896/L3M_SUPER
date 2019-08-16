using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3M_Super.Models
{
    public class Trabajador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int cedulaTrabajador { get; set; }
        public string nombreCompletoTrabajador { get; set; }
        public string fechaNacimientoTrabajador { get; set; }
        public string fechaIngresoTrabajador { get; set; }
        public string sucursalTrabajador { get; set; }
        public int salarioHoraTrabajador { get; set; }
        public int horasLaboradasTrabajador { get; set; }
        public int horasExtraTrabajador { get; set; }

    }

    class TrabajadoresDbContext : DbContext
    {
        public DbSet<Trabajador> Trabajadores { get; set; }
    }


}
