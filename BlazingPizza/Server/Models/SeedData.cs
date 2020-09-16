using BlazingPizza.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazingPizza.Server.Models
{
    public static class SeedData
    {
        public static void Initialize(PizzaStoreContext context)
        {
            var specials = new PizzaSpecial[]
            {
                new PizzaSpecial()
                {
                    Name = "Pizza clasica de queso",
                    Description = "Es de queso y delicioso. ¿Por que no querrias una?",
                    BasePrice = 189.99m,
                    ImageUrl = "images/pizzas/cheese.jpg"
                },
                new PizzaSpecial()
                {
                    Name = "Tocinator",
                    Description = "Tiene todo tipo de tocino",
                    BasePrice = 227.99m,
                    ImageUrl = "images/pizzas/bacon.jpg"
                },
                new PizzaSpecial()
                {
                    Name = "Clasica de Pepperoni",
                    Description = "Es la pizza con la que creciste, ¡pero ardientemente!",
                    BasePrice = 199.50m,
                    ImageUrl = "images/pizzas/pepperoni.jpg"
                },
                new PizzaSpecial()
                {
                    Name = "Pollo búfalo",
                    Description = "Pollo picante, salsa picante y queso azul, garantizada",
                    BasePrice = 228.75m,
                    ImageUrl = "images/pizzas/meaty.jpg"
                },
                new PizzaSpecial()
                {
                    Name = "Amantes del champiñon",
                    Description = "Tiene champiñon ¿no es obvio?",
                    BasePrice = 209.00m,
                    ImageUrl = "images/pizzas/mushroom.jpg"
                },
                new PizzaSpecial()
                {
                    Name = "Hawaiana",
                    Description = "De piña, jamón y queso...",
                    BasePrice = 190.25m,
                    ImageUrl = "images/pizzas/hawaiian.jpg"
                },
                new PizzaSpecial()
                {
                    Name = "Delicia Vegetariana",
                    Description = "Es como una ensalada, pero en una pizza",
                    BasePrice = 218.50m,
                    ImageUrl = "images/pizzas/salad.jpg"
                },
                new PizzaSpecial()
                {
                    Name = "margarita",
                    Description = "Pizza italiana tradicional con tomates y albahaca",
                    BasePrice = 189.99m,
                    ImageUrl = "images/pizzas/margherita.jpg"
                }
            };
            
            var toppings = new Topping[]
            {
                new Topping
                {
                    Name = "Queso Extra",
                    Price = 47.50m
                },
                new Topping
                {
                    Name = "Tocino de Pavo",
                    Price = 56.80m
                },
                new Topping
                {
                    Name = "Tocino de jabali",
                    Price = 56.80m
                },
                new Topping
                {
                    Name = "Tocino de ternera",
                    Price = 56.80m
                },
                new Topping
                {
                    Name = "Té y Bollos",
                    Price = 95.00m
                },
                new Topping
                {
                    Name = "Bollos recien horneados",
                    Price = 85.00m
                },
                new Topping
                {
                    Name = "Cebolla",
                    Price = 19.00m
                },
                new Topping
                {
                    Name = "Pimientos",
                    Price = 19.00m
                },
                new Topping
                {
                    Name = "Champiñones",
                    Price = 19.00m
                },
                new Topping
                {
                    Name = "Pepperoni",
                    Price = 19.00m
                },
                new Topping
                {
                    Name = "Salchicha de pato",
                    Price = 60.80m
                },
                new Topping
                {
                    Name = "Albondigas de venado",
                    Price = 47.50m
                },
                new Topping
                {
                    Name = "Cubierta de langosta",
                    Price = 1225.50m
                },
                new Topping
                {
                    Name = "Caviar de esturion",
                    Price = 1933.25m
                },
                new Topping
                {
                    Name = "Corazones de Alchachofa",
                    Price = 64.60m
                },
                new Topping
                {
                    Name = "Tomates Frescos",
                    Price = 39.00m
                },
                new Topping
                {
                    Name = "Albahacas",
                    Price = 39.00m
                },
                new Topping
                {
                    Name = "Filete",
                    Price = 161.50m
                },
                new Topping
                {
                    Name = "Pimientos Picantes",
                    Price = 79.80m
                },
                new Topping
                {
                    Name = "Pollo Bufalo",
                    Price = 95.00m
                },
                new Topping
                {
                    Name = "Queso azul",
                    Price = 47.50m
                },
            };
            
            context.Toppings.AddRange(toppings);
            context.Specials.AddRange(specials);
            context.SaveChanges();
        }
    }
}
