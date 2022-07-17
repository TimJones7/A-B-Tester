using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Pizza.API.Data
{
    public class PizzaDbContext : DbContext
    {

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //  Fluent API definition for the Pizza entities:

            //  Component
            builder.Entity<Component>()
                .HasKey(component => component.Id);

            builder.Entity<Component>()
                .HasOne(component => component.Root);

            //  Customer
            builder.Entity<Customer>()
                .HasKey(customer => customer.Id);

            builder.Entity<Customer>()
                .HasMany(customer => customer.Sessions)
                .WithOne(session => session.Customer)
                .OnDelete(DeleteBehavior.Restrict); ;
            
            builder.Entity<Customer>()
                .HasMany(customer => customer.Interactions)
                .WithOne(interaction => interaction.Customer)
                .OnDelete(DeleteBehavior.Restrict); ;

            //  CustomerInteractions
            builder.Entity<CustomerInteractions>()
                .HasKey(interaction => new { interaction.CustomerId, interaction.SessionId, interaction.ElementId });
            
            builder.Entity<CustomerInteractions>()
                .HasOne(interaction => interaction.Customer)
                .WithMany(customer => customer.Interactions)
                .HasForeignKey(interaction => interaction.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CustomerInteractions>()
                .HasOne(interaction => interaction.Session)
                .WithMany(session => session.Interactions)
                .HasForeignKey(interaction => interaction.SessionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<CustomerInteractions>()
                .HasOne(interaction => interaction.Element)
                .WithMany(element => element.Interactions)
                .HasForeignKey(interaction => interaction.ElementId)
                .OnDelete(DeleteBehavior.Restrict);

            //  Element
            builder.Entity<Element>()
                .HasKey(element => element.Id);
            
            builder.Entity<Element>()
                .HasOne(element => element.ParentElement);

            builder.Entity<Element>()
                .HasOne(element => element.FirstChild);

            builder.Entity<Element>()
                .HasOne(element => element.NextChild);

            builder.Entity<Element>()
                .HasMany(element => element.Sessions)
                .WithMany(session => session.Elements);

            builder.Entity<Element>()
                .HasMany(element => element.Interactions)
                .WithOne(interaction => interaction.Element)
                .HasForeignKey(interaction => interaction.ElementId)
                .OnDelete(DeleteBehavior.Restrict);

            //  Session
            builder.Entity<Session>()
                .HasKey(session => session.Id);

            builder.Entity<Session>()
                .HasOne(session => session.Customer)
                .WithMany(customer => customer.Sessions)
                .HasForeignKey(session => session.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Session>()
                .HasMany(session => session.Interactions)
                .WithOne(interaction => interaction.Session)
                .HasForeignKey(interaction => interaction.SessionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Session>()
                .HasMany(session => session.Elements)
                .WithMany(element => element.Sessions);

        }

        //  Tables
        public DbSet<Element> Elements { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInteractions> Interactions { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
