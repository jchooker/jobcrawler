using JobCrawler.Data;
using JobCrawler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace JobCrawler.Views.Jobs
{
    public class IndexModel : PageModel
    {
        private readonly JobsDbContext _db;
        public IEnumerable<Job> Jobs { get; set; }
        public IndexModel(JobsDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Jobs = _db.Jobs; //pluralized in "_db.Jobs" bc that's the name of
                             //the DbSet<Job> in JobsDbContext
        }
    }
}
