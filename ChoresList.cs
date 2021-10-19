using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ChoresApp
{
    public class ChoresList : DbContext
    {

        public ChoresList(string connectionString)
        {
            Database.SetInitializer<ChoresList>(new DropCreateDatabaseAlways<ChoresList>());
                this.Database.Connection.ConnectionString = connectionString;
        }
       
        public DbSet<Chores> Chores { get; set; }
        public DbSet<User> Users { get; set; }
        
    }
}
