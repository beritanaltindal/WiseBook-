using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseBook.DAL.ORM.Entity;

namespace WiseBook.DAL.ORM.Context
{
    public class WiseBookContext : DbContext
    //DbContext için entity framework indirildi

    {
        public WiseBookContext() : base("WiseBookContext")
        //app.config de connection string yazıldı WiseBookContext ismi verildi database
        {

            //Database.Connection.ConnectionString = "server=.; database:WiseBookDb; integrated security=sspi";
        }
        public DbSet<Story> Stories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
