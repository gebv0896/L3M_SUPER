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
        /// <summary>
        /// Atributos de la entidad Compra
        /// Su atributo clave es "cedulaProveedor"
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string cedulaProveedor { get; set; }
        public string nombreProveedor { get; set; }
        

    }
    class ProveedoresDbContext : DbContext
    {
        /// <summary>
        /// Conxtexto para la base de datos
        /// </summary>
        public DbSet<Proveedor> Proveedores { get; set; }
    }
}