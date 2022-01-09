namespace Avia_is.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class avia_databaseContext : DbContext
    {
        public avia_databaseContext()
            : base("name=avia_databaseContext1")
        {
        }

        public virtual DbSet<AviaPassenger> AviaPassenger { get; set; }
        public virtual DbSet<Commander> Commander { get; set; }
        public virtual DbSet<Flight> Flight { get; set; }
        public virtual DbSet<Plane> Plane { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AviaPassenger>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<AviaPassenger>()
                .Property(e => e.Telephone)
                .IsUnicode(false);

            modelBuilder.Entity<Commander>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Plane>()
                .Property(e => e.Model)
                .IsFixedLength();

            modelBuilder.Entity<Route>()
                .Property(e => e.Ticket_price)
                .HasPrecision(10, 4);
        }
    }
}
