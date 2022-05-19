using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using Razzi.Models;
using Razzi.ViewModels;
using System.Threading.Tasks;

namespace Razzi.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            IntroAbout introAbout = await _context.IntroAbouts.FirstOrDefaultAsync();
            LeftSideAboutShop leftSide = await _context.LeftSideAboutShops.FirstOrDefaultAsync();
            RightSideAboutShop rightSide = await _context.RightSideAboutShops.FirstOrDefaultAsync();
            AboutOurStory aboutOurStory = await _context.AboutOurStories.FirstOrDefaultAsync();
            WarningBannerAbout warningBanner = await _context.WarningBannerAbouts.FirstOrDefaultAsync();

            AboutVM aboutVM = new AboutVM()
            {
                IntroAbout = introAbout,
                LeftSideAboutShop = leftSide,
                RightSideAboutShop = rightSide,
                AboutOurStory = aboutOurStory,
                WarningBanner = warningBanner,

            };
            return View(aboutVM);
        }
    }
}
