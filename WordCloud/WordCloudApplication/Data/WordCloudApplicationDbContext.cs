using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WordCloudApplication.Data.Entities;

namespace WordCloudApplication.Data
{
    public class WordCloudDbContext : IdentityDbContext<ApplicationUser>
    {
        public override DbSet<ApplicationUser>? Users { get; set; }
        public DbSet<WordCloud>? SavedWordClouds { get; set; }

        public WordCloudDbContext(DbContextOptions<WordCloudDbContext> options)
            : base(options)
        {

        }


        //add-migration IdentityInit
        //update-database
        //Remove-Migration
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>(roles =>
            {
                roles.HasData(
                    new IdentityRole() { Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                    new IdentityRole() { Name = "Developer", ConcurrencyStamp = "2", NormalizedName = "Developer" },
                    new IdentityRole() { Name = "PremiumUser", ConcurrencyStamp = "3", NormalizedName = "PremiumUser" },
                    new IdentityRole() { Name = "VerifiedUser", ConcurrencyStamp = "4", NormalizedName = "VerifiedUser" },
                    new IdentityRole() { Name = "User", ConcurrencyStamp = "5", NormalizedName = "User" });
            });
        }
    }
}
