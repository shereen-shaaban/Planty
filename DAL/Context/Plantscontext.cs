using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class Plantscontext:DbContext
    {

        public Plantscontext(DbContextOptions<Plantscontext>options):base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
		
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Plantscontext).Assembly);
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(ne)
		}
        public virtual DbSet<Category>Category { get; set; }
        public virtual DbSet<Product>Product { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Customer>Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Office>Office { get; set; }
        public virtual DbSet<OrderProduct> OrderProduct { get; set; }
        public virtual DbSet<Department> Department { get; set; }

    }
}
