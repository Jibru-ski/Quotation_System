using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuotationSys.Models;
using QuotationSysAuth.Models;

namespace QuotationSysAuth.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Quotation> Quotations { get; set; }
        public DbSet<QuotationItem> QuotationItems { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // builder.Entity<Quotation>()
            //     .HasOne(q => q.Customer)
            //     .WithMany(c => c.Quotations)
            //     .HasForeignKey(q => q.CustomerId)
            //     .OnDelete(DeleteBehavior.Restrict);
            //     
            // builder.Entity<Quotation>()
            //     .HasOne(q => q.User)
            //     .WithMany()
            //     .HasForeignKey(q => q.UserId)
            //     .OnDelete(DeleteBehavior.Restrict);
            //     
            // builder.Entity<QuotationItem>()
            //     .HasOne(qi => qi.Quotation)
            //     .WithMany(q => q.Items)
            //     .HasForeignKey(qi => qi.QuotationId)
            //     .OnDelete(DeleteBehavior.Cascade);
            //
            builder.Entity<QuotationItem>()
                .HasOne(q => q.Product)
                .WithMany()
                .HasForeignKey(q => q.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
            //
            // builder.Entity<Customer>()
            //     .HasIndex(c => c.Email)
            //     .IsUnique();
            //
            // builder.Entity<Quotation>()
            //     .HasIndex(q => q.QuotationNumber)
            //     .IsUnique();
            //
            // builder.Entity<Product>()
            //     .HasIndex(p => p.Code)
            //     .IsUnique();
            //     
            // builder.Entity<Quotation>()
            //     .Property(q => q.UserId)
            //     .HasColumnType("nvarchar(450)"); 
        }
        
    }
    
}