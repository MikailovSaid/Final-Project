using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public bool StockStatus { get; set; }
        public string Desc { get; set; }
        public int Count { get; set; }
        public bool IsMan { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
