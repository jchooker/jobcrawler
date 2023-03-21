using JobCrawler.Data;
using JobCrawler.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobCrawler.Controllers
{
    public class JobsController : Controller
    {
        private readonly JobsDbContext _db; //<---for working with the database

        public JobsController(JobsDbContext db) //<--- db has all of the connection string data that we
                                                // set up in Program.cs
        {
            _db = db;
        }
        //[HttpGet]
        public IActionResult Index()
        {
            //IEnumerable<Job> objJobList = _db.Jobs.ToList();
            //return View(objJobList);
            return View();
        }
        [HttpGet]
        public IActionResult GetAllJobs()
        {
            var jobs = _db.Jobs.ToList();
            return Json(jobs);
        }

        public IActionResult Create() //<--prob don't need this method since "Create" isn't happening on a
                                      //separate page from /Jobs/Index
        {
            IEnumerable<Job> objJobList = _db.Jobs;
            return View(objJobList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Job job, string JobPlatformText)
        {
            if (ModelState.IsValid)
            {
                job.JobPlatform = JobPlatformText; //recently added; check if this works for sending the
                                                   //options' text rather than values for JobPlatform
                _db.Jobs.Add(job);
                _db.SaveChanges();
                //return RedirectToAction("Index"); //<--**THIS** is how you handle when you want more than one controller
                //method "per page"
                //var jobs = _db.Jobs.ToList();
                return RedirectToAction("Index");
            }

            return BadRequest(ModelState);

        }

        public IActionResult Delete(int? id)
        {
            return null;
        }
    }

    //#region API CALLS
    //[HttpGet]
    //public IActionResult GetAll()
    //{
    //    var productList = ....
    //}
    //#endregion
}
