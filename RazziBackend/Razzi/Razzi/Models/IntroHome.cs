using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Razzi.Models
{
    public class IntroHome
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Header { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
