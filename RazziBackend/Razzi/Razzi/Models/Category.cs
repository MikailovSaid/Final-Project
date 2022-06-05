using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razzi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BackImage { get; set; }
        public List<Product> Products { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
