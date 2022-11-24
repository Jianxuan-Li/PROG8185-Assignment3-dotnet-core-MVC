using Assignment3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Assignment3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext context;

        public ProductController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return context.Products;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            // return object or throw 404 error
            try
            {
                return context.Products.Find(id);
            }
            catch (Exception e)
            {
                return null;
            }
            
        }

        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            var existingProduct = context.Products.Find(id);
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Image = product.Image;
            existingProduct.Price = product.Price;
            existingProduct.ShippingCost = product.ShippingCost;
            context.SaveChanges();
            return existingProduct;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
