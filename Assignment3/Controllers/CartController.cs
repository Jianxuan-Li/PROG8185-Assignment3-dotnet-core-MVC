﻿using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly AppDbContext context;

        public CartController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Cart> Get()
        {
            return context.Cart;
        }

        [HttpGet("{id}")]
        public Cart Get(int id)
        {
            // return object or throw 404 error
            try
            {
                return context.Cart.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        [HttpPost]
        public Cart Post([FromBody] Cart cart)
        {
            context.Cart.Add(cart);
            context.SaveChanges();
            return cart;
        }

        [HttpPut("{id}")]
        public Cart Put(int id, [FromBody] Cart cart)
        {
            var existingCartItem = context.Cart.Find(id);
            existingCartItem.Quantity = cart.Quantity;
            context.SaveChanges();
            return existingCartItem;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var cartItem = context.Cart.Find(id);
            context.Cart.Remove(cartItem);
            context.SaveChanges();
        }
    }
}
