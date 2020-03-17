using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CraftsWebApplication.Models;
using CraftsWebApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CraftsWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public ProductsController(JsonFileProductService productService)
        {
            ProductService = productService;
        }

        public JsonFileProductService ProductService { get; }

        [HttpGet]
        public List<Product> GetProducts()
        {
            return ProductService.GetProducts().ToList();
        }
    }
}