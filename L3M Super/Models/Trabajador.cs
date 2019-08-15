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
        public int cedula { get; set; }
        public string nombreCompleto { get; set; }
        public string fechaNacimiento { get; set; }
        public string fechaIngreso { get; set; }
        public string sucursal { get; set; }
        public int salarioHora { get; set; }

    }

    class TrabajadoresDbContext : DbContext
    {
        public DbSet<Trabajador> Trabajadores { get; set; }
    }


}
}