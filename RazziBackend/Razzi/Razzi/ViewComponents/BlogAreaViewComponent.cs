using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using System.Threading.Tasks;

namespace Razzi.ViewComponents
{
    public class BlogAreaViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public BlogAreaViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogArea = await _context.BlogAreas.ToListAsync();

            return (await Task.FromResult(View(blogArea)));
        }
    }
}
