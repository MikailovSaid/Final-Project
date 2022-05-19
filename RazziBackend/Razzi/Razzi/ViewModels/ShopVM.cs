using Razzi.Models;
using Razzi.Utilities.Pagination;
using System.Collections.Generic;

namespace Razzi.ViewModels
{
    public class ShopVM
    {
        public List<Product> Products { get; set; }
        public List<Gender> Genders { get; set; }
        public List<Size> Sizes { get; set; }
        public List<Category> Categories { get; set; }
        public Pagination<Product> PaginatedProducts { get; set; }
    }
}
