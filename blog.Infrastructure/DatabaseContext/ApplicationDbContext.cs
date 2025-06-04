//using blog.Core.Entities;
//using Microsoft.EntityFrameworkCore;

//namespace blog.Infrastructure.DatabaseContext
//{
//    public class ApplicationDbContext : DbContext
//    {
//        public ApplicationDbContext(DbContextOptions options) : base(options) { }
//        public DbSet<Categories> TblCategories { get; set; }

//        public DbSet<Comment> TblComment { get; set; }

//        public DbSet<Tutorial> TblTutorial { get; set; }

//        public DbSet<Tutorial_Details> TblTutorial_Details { get; set; }

//        public DbSet<Gallery> TblGallery { get; set; }

//        public DbSet<Tags> TblTags { get; set; }

//        public DbSet<WebStory> TblWebStory { get; set; }

//        public DbSet<WebStoryPage> TblWebStoryPage { get; set; }
//    }
//}

// blog.Infrastructure/DatabaseContext/ApplicationDbContext.cs

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using blog.Core.Entities;


namespace blog.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Categories> TblCategories { get; set; }
        public DbSet<Comment> TblComment { get; set; }
        public DbSet<Tutorial> TblTutorial { get; set; }
        public DbSet<Tutorial_Details> TblTutorial_Details { get; set; }
        public DbSet<Gallery> TblGallery { get; set; }
        public DbSet<Tags> TblTags { get; set; }
        public DbSet<WebStory> TblWebStory { get; set; }
        public DbSet<WebStoryPage> TblWebStoryPage { get; set; }
    }
}
