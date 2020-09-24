using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlazingPizza.Server.Models;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Server.Controllers
{
    [Route("orders")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaStoreContext _context;

        public OrdersController(PizzaStoreContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            order.DeliveryLocation =
                new LatLong(9.72348, -63.25693); // 19.723510, -63.256936);
            order.UserId = Helpers.User.GetUserId(HttpContext);

            var alg = Helpers.User.GetUserEmail(HttpContext);
            
            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;
                foreach (var topping in pizza.Toppings)
                {
                    topping.ToppingId = topping.Topping.Id;
                    topping.Topping = null;
                }
            }

            _context.Orders.Attach(order);
            await _context.SaveChangesAsync();
            return order.OrderId;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderWithStatus>>> GetOrders()
        {
            var orders = await _context.Orders
                .Where(o => o.UserId == Helpers.User.GetUserId(HttpContext))
                .Include(o => o.DeliveryLocation)
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
                .OrderByDescending(o => o.CreatedTime)
                .ToListAsync();

            return orders.Select(
                o => OrderWithStatus.FromOrder(o)).ToList();
        }

        [HttpGet("{orderId}")]
        public async Task<ActionResult<OrderWithStatus>> GetOrderWithStatus(int orderId)
        {
            var order = await _context.Orders
                .Where(o => o.UserId == Helpers.User.GetUserId(HttpContext))
                .Where(o => o.OrderId == orderId)
                .Include(o => o.DeliveryLocation)
                .Include(o => o.Pizzas).ThenInclude(p => p.Special)
                .Include(o => o.Pizzas).ThenInclude(p => p.Toppings)
                .ThenInclude(t => t.Topping)
                .SingleOrDefaultAsync();

            if (order==null)
            {
                return NotFound();
            }
            else
            {
                return OrderWithStatus.FromOrder(order);
            }
        }         
    }
}
