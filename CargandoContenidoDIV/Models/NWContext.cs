namespace CargandoContenidoDIV.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NWContext : DbContext
    {
        public NWContext()
            : base( "name=NWContext" )
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }

        protected override void OnModelCreating( DbModelBuilder modelBuilder )
        {
            modelBuilder.Entity<Customer>()
                .Property( e => e.CustomerID )
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasMany( e => e.Employees1 )
                .WithOptional( e => e.Employee1 )
                .HasForeignKey( e => e.ReportsTo );

            modelBuilder.Entity<Employee>()
                .HasMany( e => e.Territories )
                .WithMany( e => e.Employees )
                .Map( m => m.ToTable( "EmployeeTerritories" ).MapLeftKey( "EmployeeID" ).MapRightKey( "TerritoryID" ) );

            modelBuilder.Entity<Product>()
                .Property( e => e.UnitPrice )
                .HasPrecision( 19 , 4 );

            modelBuilder.Entity<Territory>()
                .Property( e => e.TerritoryDescription )
                .IsFixedLength();
        }
    }
}
