using System.Collections.Generic;

namespace Razzi.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }
}
