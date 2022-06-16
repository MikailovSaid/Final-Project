using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Razzi.Data;
using System.Threading.Tasks;

namespace Razzi.ViewComponents
{
    public class RegisterViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        public RegisterViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return (await Task.FromResult(View()));
        }
    }
}
