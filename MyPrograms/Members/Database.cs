using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyPrograms.Members
{
    public class MyConnection : DbContext
    {
        public MyConnection()
            : base("MyConnection")
        {
            //Update database
            Database.SetInitializer<MyConnection>(null);
        }

        public DbSet<Entry> OurCalendarApp { get; set; }
        public DbSet<myUser> Authentication { get; set; }
    }

    [Table("OurCalendarApp")]
    public class Entry
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime thisDate { get; set; }
        public decimal numHours { get; set; }
        public string user { get; set; }
    }

    [Table("Authentication")]
    public class myUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Group { get; set; }
    }
}