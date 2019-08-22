using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3M_Super.Models
{
    public class Compra
    {
        /// <summary>
        /// Atributos de la entidad Compra
        /// Su atributo clave es "fotoCompra"
        /// </summary>
        public string descripcionCompra { get; set; }
        public string fechaRealCompra { get; set; }
        public string fechaRegistroCompra { get; set; }
        public string proveedorCompra { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string fotoCompra { get; set; }
        public string sucursalRegistraCompra { get; set; }

    }

    class ComprasDbContext : DbContext
    {
        /// <summary>
        /// Conxtexto para la base de datos
        /// </summary>
        public DbSet<Compra> Compras { get; set; }
    }


}