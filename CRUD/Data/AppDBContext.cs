using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CRUD.Models;

namespace CRUD.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() : base ("DefaultConnection")
        {
        }

        public DbSet<MovilData> Movil { get; set; }
        public DbSet<File> Files { get; set; }

        public System.Data.Entity.DbSet<CRUD.Models.imgData> imgDatas { get; set; }
    }
}