using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Pizza.API.Data
{
    public class PizzaDbContext : DbContext
    {

        public PizzaDbContext(DbContextOptions<PizzaDbContext> options) : base(options)
        {

        }

        

        

        //  Tables
        public DbSet<Element> Elements { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerInteractions> Interactions { get; set; }
        public DbSet<Session> Sessions { get; set; }
    }
}
