using BlazingPizza.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Server.Models
{
    public class PizzaStoreContext : DbContext
    {
        public PizzaStoreContext(DbContextOptions<PizzaStoreContext> options)
            : base(options) { }

        public DbSet<PizzaSpecial> Specials { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent API

            modelBuilder.Entity<PizzaTopping>()
                .HasKey(pst => new { pst.PizzaId, pst.ToppingId });
            
            modelBuilder.Entity<PizzaTopping>()
                .HasOne<Pizza>().WithMany(ps => ps.Toppings);

            modelBuilder.Entity<PizzaTopping>()
                .HasOne(pst => pst.Topping).WithMany();

            modelBuilder.Entity<Order>()
                .OwnsOne(o => o.DeliveryLocation);
        }
    }
}
