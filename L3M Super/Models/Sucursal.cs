using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace L3M_Super.Models
{
    public class Sucursal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string nombreSucursal { get; set; }
        public string direccionSurcusal { get; set; }
        public int telefonoSucursal { get; set; }
        public string administradorSucursal { get; set; }

    }
    class SucursalesDbContext : DbContext
    {
        public DbSet<Sucursal> Sucursales { get; set; }
    }
}