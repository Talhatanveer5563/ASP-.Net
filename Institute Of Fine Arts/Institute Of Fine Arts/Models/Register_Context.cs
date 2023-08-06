using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Institute_Of_Fine_Arts.Models
{
    public class Register_Context : DbContext
    {
        public Register_Context() : base("CS") { }

     

        public DbSet<Registration> registrations { get; set; }
        public DbSet<Contactus> contactus { get; set; }
        public DbSet<Profilelist> profilelists { get; set; }
    }
}