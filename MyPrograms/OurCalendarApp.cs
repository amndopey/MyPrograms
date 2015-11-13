namespace MyPrograms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OurCalendarApp")]
    public partial class OurCalendarApp
    {
        public int Id { get; set; }

        public DateTime thisDate { get; set; }

        public decimal numHours { get; set; }

        [StringLength(50)]
        public string user { get; set; }
    }
}
