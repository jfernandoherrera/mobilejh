using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace listarproy.Models
{
    public class listarproyContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public listarproyContext() : base("name=listarproyContext")
        {
        }

        public System.Data.Entity.DbSet<listarproy.Models.lista> listas { get; set; }

        public System.Data.Entity.DbSet<listarproy.Models.ListUser> ListUsers { get; set; }

        public System.Data.Entity.DbSet<listarproy.Models.Scheduled> Scheduleds { get; set; }
    
    }
}
