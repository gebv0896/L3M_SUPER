using System;
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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string nombreRol { get; set; }
        public string descripcionRol { get; set; }
    }

    class RolesDbContext : DbContext
    {
        public DbSet<Rol> Roles { get; set; }
    }


}