using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        public IHttpActionResult Post(Product produto)
        {
            if (produto != null)
            {
                products.Add(produto);
                return Ok(produto);
            }
            return InternalServerError();
        }

        public HttpResponseMessage Post(Product produto)
        {
            if (produto != null)
            {
                products.Add(produto);
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
                response.Content = new StringContent("Produto inserido.", Encoding.Unicode);
                return response;
            }
            HttpResponseMessage responseError = Request.CreateResponse(HttpStatusCode.BadRequest);
            responseError.Content = new StringContent("Produto NAO inserido.", Encoding.Unicode);
            return responseError;
        }


    }
}
