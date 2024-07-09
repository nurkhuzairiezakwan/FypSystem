//using ADStarter.Models;
using ADStarter.Models;
using ADStrater.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ADStarter.DataAccess.Data
{
    public class ApplicationDBContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Course>().HasData(
                new Course { course_ID = 1, course_desc = "Data Engineering", course_code = "SECPH", course_count="41" },
                new Course { course_ID = 2, course_desc = "Software Engineering", course_code = "SECJ" ,course_count = "41" }

                );

        }
    }
}
