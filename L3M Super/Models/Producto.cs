﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace L3M_Super.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int codigoBarraProducto { get; set; }
        public string nombreProducto { get; set; }
        public string descripcionProducto { get; set; }
        public string proveedorProducto { get; set;}
        public int precioProducto { get; set; }
        public string impuestoProducto { get; set; }
        public string descuentoProducto { get; set; }
        public string sucursalProducto { get; set; }
    }
    class Productos2DbContext : DbContext
    {
        public DbSet<Producto> Productos2 { get; set; }
    }
}