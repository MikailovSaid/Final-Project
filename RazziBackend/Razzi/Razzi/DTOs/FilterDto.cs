using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.DTOs
{
    public class FilterDto
    {
        public int[] genders { get; set; }

        public int[] categories { get; set; }

        public int[] sizes { get; set; }
        public int[] prices { get; set; }
    }
}
