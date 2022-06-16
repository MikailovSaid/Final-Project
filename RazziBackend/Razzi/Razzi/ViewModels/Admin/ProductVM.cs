using Microsoft.AspNetCore.Http;
using Razzi.Models;
using System.Collections.Generic;

namespace Razzi.ViewModels.Admin
{
    public class ProductVM
    {
        public string Name { get; set; }
        public decimal RealPrice { get; set; }
        public bool StockStatus { get; set; }
        public string Desc { get; set; }
        public int Count { get; set; }
        public bool TopItem { get; set; }
        public ICollection<int> ProductSizes { get; set; }
        public int GenderId { get; set; }
        public int CategoryId { get; set; }
        public int PriceId { get; set; }
        public IFormFile Photo { get; set; }
    }
}
