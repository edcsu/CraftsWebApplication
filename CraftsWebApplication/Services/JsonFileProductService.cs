using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CraftsWebApplication.Core.Helpers;
using CraftsWebApplication.Models;
using Microsoft.AspNetCore.Hosting;

namespace CraftsWebApplication.Services
{
    public class JsonFileProductService
    {
         public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
         {
            WebHostEnvironment = webHostEnvironment;
         }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName
        {
            get { return Path.Combine(WebHostEnvironment.ContentRootPath, "Data", "products.json"); }
        }

        public IEnumerable<Product> GetProducts()
        {
            return JsonFileConverter.GetContent(JsonFileName);
        }

        public void AddRating(string id, int rating)
        {
            var products = GetProducts().ToList();

            var query = products.First(x => x.ProductId == id);
            if (query.Ratings == null)
            {
                query.Ratings = new int[] { rating };
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            JsonFileConverter.WriteContent(JsonFileName, products);
        }
    }
}
