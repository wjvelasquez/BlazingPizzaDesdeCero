﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Server.Models;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazingPizza.Server.Controllers
{
    [Route("toppings")]
    [ApiController]
    public class ToppingsController : ControllerBase
    {
        private readonly PizzaStoreContext _context;

        public ToppingsController(PizzaStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Topping>>> GetToppings()
        {
            return await _context.Toppings
                .OrderByDescending(t => t.Name).ToListAsync();
        }
    }
}
