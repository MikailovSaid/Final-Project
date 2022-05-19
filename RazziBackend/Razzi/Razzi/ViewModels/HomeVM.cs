using Razzi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Razzi.ViewModels
{
    public class HomeVM
    {
        public IntroHome IntroHome { get; set; }
        public List<BestSellers> BestSellers { get; set; }
        public Video Video { get; set; }
        public List<Gender> Genders { get; set; }
    }
}
