using Chapter4.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4.Data 
{
    public class VideoDbContext : DbContext
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
