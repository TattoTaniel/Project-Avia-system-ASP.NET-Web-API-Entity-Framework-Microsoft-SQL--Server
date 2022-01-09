namespace Avia_is.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Route")]
    public partial class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IDRoute { get; set; }

        [Required]
        [StringLength(50)]
        public string Departure_airport { get; set; }

        [Required]
        [StringLength(50)]
        public string Destination_airport { get; set; }

        
        public decimal Ticket_price { get; set; }

        public double Flight_duration { get; set; }

        public int IDFlight { get; set; }

        public virtual Flight Flight { get; set; }
    }
}
