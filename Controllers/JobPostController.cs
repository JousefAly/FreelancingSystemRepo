using FreelancingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancingSystem.Controllers
{
    public class JobPostController : Controller
    {
        private FreelancingDBContext db = new FreelancingDBContext();
        // get all job posts from db
        public ActionResult GetJobPosts()
        {
            List<JobPost> JobPostLst = new List<JobPost>();
            //Quiring using linq to entity
            JobPostLst = (from post in db.JobPosts
                          select post).ToList();
            return View(JobPostLst);
        }
        // get job post by id from db
        public ActionResult GetJobPost(int id)
        {
            var jPost = new JobPost();
            jPost = (from post in db.JobPosts
                    where post.JobPostID == id  
                     select post).FirstOrDefault();
            return View(jPost);

        }
       

        [HttpGet]
        public ActionResult InsertJobPost()
        {
           

            JobPost pi = new JobPost();

            return View(pi);

        }
            [HttpPost]
        public ActionResult InsertJobPost(JobPost PI)
        {
            /*
            if (!ModelState.IsValid)
            {
                return View("Index", PI);
            }*/

            db.JobPosts.Add(PI);

            db.SaveChanges();
            return View();
          //  return RedirectToAction("Home","Client");


        }
        public ActionResult DeleteJobPost(int id)
        {
            var del = db.ClientPosts.Single(c => c.PostID == id);
            if (del == null)
                return HttpNotFound();
            db.ClientPosts.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Home", "Client");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editPost = db.JobPosts.Single(a => a.JobPostID == id);
            if (editPost == null)
                return HttpNotFound();

            return View(editPost);
           
        }

        [HttpPost]
        public ActionResult Edit(JobPost jobpost)
        {
            var editPost = db.JobPosts.Single(a => a.JobPostID == jobpost.JobPostID);
            editPost.Name = jobpost.Name;
            editPost.Discreption = jobpost.Discreption;
            editPost.Budget = jobpost.Budget;
            editPost.Type = jobpost.Type;
            db.SaveChanges();

            return View(editPost);

        }


    }
}