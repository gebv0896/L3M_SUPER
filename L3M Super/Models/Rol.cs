﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L3M_Super.Models
{
    public class Rol
    {
        /// <summary>
        /// Atributos de la entidad Compra
        /// Su atributo clave es "nombreRol"
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string nombreRol { get; set; }
        public string descripcionRol { get; set; }
    }

    class RolesDbContext : DbContext
    {
        /// <summary>
        /// Conxtexto para la base de datos
        /// </summary>
        public DbSet<Rol> Roles { get; set; }
    }


}