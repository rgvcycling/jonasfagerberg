using Chapter4.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chapter4.Data 
{
    public class VideoDbContext : IdentityDbContext
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
