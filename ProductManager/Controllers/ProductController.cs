using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductManager.Controllers
{
    public class ProductController : ApiController
    {

        List<Product> products = new List<Product>
        {
            new Product {Id = 1, Name= "Tomato Soup", Category = "Groceries", Price = 1.75M},
            new Product {Id = 2, Name= "Yo-yo", Category = "Toys", Price = 10.60M},
            new Product {Id = 3, Name= "Hammer", Category = "Hardware", Price = 0.75M}
        };

        public IHttpActionResult Get()
        {
            return Ok(products);
        }

        public IHttpActionResult Get(int id)
        {
            return Ok(products.FirstOrDefault<Product>(x => x.Id == id));
        }



    }
}
