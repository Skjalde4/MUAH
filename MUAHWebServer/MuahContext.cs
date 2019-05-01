namespace MUAHWebServer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MuahContext : DbContext
    {
        public MuahContext()
            : base("name=MuahContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Basket> Basket { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
