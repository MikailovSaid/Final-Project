using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Models
{
    public class Product
    {
        public Product()
        {
            ProductSizes = new List<ProductSize>();
        }

        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public decimal RealPrice { get; set; }
        public bool StockStatus { get; set; }
        public string Desc { get; set; }
        public int Count { get; set; }
        public bool TopItem { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int PriceId { get; set; }
        public Price Price { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
