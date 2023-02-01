using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace usersapp
{
    class AppCont : DbContext
    {
        public DbSet<User> Users { get; set; }
        public AppCont() : base("DefaultConnection") { }
    }
}
