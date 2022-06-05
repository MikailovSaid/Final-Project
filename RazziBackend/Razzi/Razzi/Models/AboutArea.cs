using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.Models
{
    public class AboutArea
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string LongDesc { get; set; }
        public string ShortDesc { get; set; }
        public string BackImg { get; set; }
        public string FrontImg { get; set; }
        [Required]
        [NotMapped]
        public IFormFile BackPhoto { get; set; }
        [Required]
        [NotMapped]
        public IFormFile FrontPhoto { get; set; }
    }
}
