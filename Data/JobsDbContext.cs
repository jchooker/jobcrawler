using JobCrawler.Models;
using Microsoft.EntityFrameworkCore;

namespace JobCrawler.Data
{
    public class JobsDbContext : DbContext
    {
        public JobsDbContext(DbContextOptions<JobsDbContext> options) : base(options)
        {
            
        }

        public DbSet<Job> Jobs { get; set; }
    }
}
