using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Razzi.Models;

namespace Razzi.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<IntroHome> IntroHomes { get; set; }
        public DbSet<BestSellers> BestSellers { get; set; }
        public DbSet<AboutArea> AboutAreas { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<BlogArea> BlogAreas { get; set; }
        public DbSet<IntroAbout> IntroAbouts { get; set; }
        public DbSet<LeftSideAboutShop> LeftSideAboutShops { get; set; }
        public DbSet<RightSideAboutShop> RightSideAboutShops { get; set; }
        public DbSet<AboutOurStory> AboutOurStories { get; set; }
        public DbSet<WarningBannerAbout> WarningBannerAbouts { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Price> Prices { get; set; }
    }
}
