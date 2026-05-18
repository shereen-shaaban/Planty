using System;
using System.Collections.Generic;
using System.Text;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class Plantsconfigurations
    {
        //category configuration
        public class CategoryConfiguration:IEntityTypeConfiguration<Category>
        {
            public void Configure(EntityTypeBuilder<Category> builder)
            {
                //properties
                builder.HasKey(c => c.Id);
                builder.Property(c=>c.Name).HasMaxLength(50).IsRequired(true);
                builder.Property(c=>c.Description).HasMaxLength(200).IsRequired(false);
                //relations
                builder.HasMany(c => c.Products)
                    .WithOne(p => p.category)
                    .HasForeignKey(p => p.Id);
            }
        }
		//product configuration
		public class ProductConfiguration:IEntityTypeConfiguration<Product>
        {
            public void Configure(EntityTypeBuilder<Product> builder)
            {
                //properties

                builder.HasKey(p => p.Id);
                builder.Property(p=>p.Name).HasMaxLength(50).IsRequired(true);
                builder.Property(p=>p.quanity).HasDefaultValue(0);
                builder.Property(p=>p.Price).HasColumnType("decimal(18,4)").IsRequired(true);
                builder.Property(p => p.Description).HasMaxLength(200).IsRequired(false);
                builder.Property(p=>p.Image).IsRequired(false);


                //relations

                builder.HasMany(p => p.OrdersProduct)
                    .WithOne(op => op.Product)
                    .HasForeignKey(op => op.Productid);
        }
        }
		//order configuration
		public class OrderCongifuration:IEntityTypeConfiguration<Order>
        {
            public void Configure(EntityTypeBuilder<Order> builder)
            {
                //properties
                builder.HasKey(o => o.Id);
                builder.Property(o=>o.status).HasDefaultValue("pending");
                //builder.Property(o => o.Bookdate).HasDefaultValue("GETDATE()");
				builder.Property(o => o.Bookdate)
	           .HasDefaultValueSql("GETDATE()");
				builder.Property(o => o.wantdate).IsRequired(true);

                //relations

                builder.HasMany(o => o.OrderProducts)
                    .WithOne(op => op.Order)
                    .HasForeignKey(op => op.Orderid);

                builder.HasOne(o => o.Customer)
                    .WithMany(c => c.Orders)
                    .HasForeignKey(o => o.Customerid);
            }

        }
		//orderproducts configuration
		public class OrdersProductConfiguration:IEntityTypeConfiguration<OrderProduct>
        {
            public void Configure(EntityTypeBuilder<OrderProduct>builder)
            {
                //properties
                builder.HasKey(op => op.Id);
                builder.Property(op => op.amount).IsRequired(true);


				//relations
                //no need i make that relation in the product and order configuration
				//builder.HasOne(op => op.Product)
				//	.WithMany(p => p.OrdersProduct)
				//	.HasForeignKey(op => op.Productid);
				//builder.HasOne(op => op.Order)
				//	.WithMany(o=>o.OrderProducts)
				//	.HasForeignKey(op => op.Orderid);


			}
        }
		//customer configuration
		public class CustomerConfiguration :IEntityTypeConfiguration<Customer>
        {
            public void Configure(EntityTypeBuilder<Customer> builder)
            {
                //poperties
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Name).HasColumnName("Fullname").HasMaxLength(100).IsRequired();
                builder.Property(c => c.phone).IsRequired(false);
                builder.Property(c => c.Address).IsRequired(false);

                //relations

                builder.HasMany(c => c.Payments)
                    .WithOne(p => p.customer)
                    .HasForeignKey(p => p.Customerid);
            }
        }
		//payment configuration
		public class PaymentConfiguration:IEntityTypeConfiguration<Payment>
        {
            public void Configure(EntityTypeBuilder<Payment>builder)
            {
                //properties
                builder.HasKey(p => p.Id);
                builder.Property(p => p.paydate).HasDefaultValueSql("GETDATE()");
            }
        }
		//employee configuration
		public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
        {
            public void Configure(EntityTypeBuilder<Employee> builder)
            {
                //properties
                builder.HasKey(e => e.Id);
                builder.Property(e => e.Name).HasMaxLength(100).IsRequired();
                builder.Property(e => e.Birthdate).IsRequired();
                builder.Property(e => e.address1).HasMaxLength(200).IsRequired(false);
                builder.Property(e => e.address2).HasMaxLength(200).IsRequired(false);


                //relations 
                builder.HasOne(e => e.Department)
                    .WithMany(d => d.Employees)
                    .HasForeignKey(e => e.Did);
                builder.HasOne(e => e.office)
                    .WithMany(o => o.Employees)
                    .HasForeignKey(e => e.Officeid);


                builder.HasOne(e => e.Manager)
                    .WithMany(m => m.Employees)
                    .HasForeignKey(e => e.managerid)
                    .OnDelete(DeleteBehavior.NoAction);

			}
        }
		//Department configuration
		public class DepartmentConfiguration:IEntityTypeConfiguration<Department>
        {
            public void Configure(EntityTypeBuilder<Department>builder)
            {

                //properties
                builder.HasKey(d => d.Id);
                builder.Property(d => d.Name).HasMaxLength(100).IsRequired();
                
                //relations
                //DateOnly one relation with employee and i code it before it's in the ' employee configuration
            }
        }
		//Office configuration
        public class OfficeConfiguration :IEntityTypeConfiguration<Office>
        {
            public void Configure(EntityTypeBuilder<Office>builder)
            {
                //properties
                builder.HasKey(o => o.Id);
                builder.Property(o => o.Name).HasMaxLength(100).IsRequired();
                builder.Property(o => o.Description).HasMaxLength(300).IsRequired(false);
                builder.Property(o => o.Phone).IsRequired(false).HasMaxLength(11);
                builder.Property(o => o.City).HasMaxLength(50).IsRequired(false);
                builder.Property(o => o.Country).HasMaxLength(50).IsRequired();
                builder.Property(o => o.Street).HasMaxLength(100).IsRequired(false);



            }
        }


	}
}
