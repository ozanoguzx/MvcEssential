using MVC_JsonResult.Models.Entities;
using System.Data.Entity;

namespace MVC_JsonResult.Models.Context
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
            Database.Connection.ConnectionString = "server=.;database=MVCJsonResultDb;UID=sa;PWD=123";
        }

        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
    }
}