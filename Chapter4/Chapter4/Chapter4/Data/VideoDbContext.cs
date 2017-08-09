using Chapter4.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Chapter4.Data
{
    public class VideoDbContext : IdentityDbContext<User>
    {
        public DbSet<Video> Videos { get; set; }
        public VideoDbContext(DbContextOptions<VideoDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
