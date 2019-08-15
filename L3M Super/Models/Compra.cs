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
        
        public string descripcionCompra { get; set; }
        public string fechaRealCompra { get; set; }
        public string fechaRegistroCompra { get; set; }
        public string proveedor { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string fotoCompra { get; set; }
        public string sucursalRegistra { get; set; }

    }

    class ComprasDbContext : DbContext
    {
        public DbSet<Compra> Compras { get; set; }
    }


}