using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.ViewModels
{
    public class WishListDetailVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool StockStatus { get; set; }
        public decimal Price { get; set; }
    }
}
