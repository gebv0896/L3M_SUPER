using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace L3M_Super.Models
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string cedulaProveedor { get; set; }
        public string nombreProveedor { get; set; }
        

    }
    class ProveedoresDbContext : DbContext
    {
        public DbSet<Proveedor> Proveedores { get; set; }
    }
}