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
        public ActionResult InsertJobPost()
        {
            var post = new JobPost();
            post.Discreption = "post discreption....";
            post.Name = "Back End Developer needed";

            post.Budget = 1500M;
            post.Approved = true;
            db.JobPosts.Add(post);
            db.SaveChanges();
            return View("Details");
        }
        public ActionResult DeleteJobPost(int id)
        {
            JobPost jp = new JobPost();
            jp = (from post in db.JobPosts
                  where post.JobPostID == id
                  select post).FirstOrDefault();
            //removing entity from database
            db.JobPosts.Remove(jp);
            db.SaveChanges();
            return View("Details");
        }
        public ActionResult UpdateJobPost(int jobPostID)
        {
            JobPost jp = new JobPost();
            jp = (from post in db.JobPosts
                  where post.JobPostID == jobPostID
                  select post).FirstOrDefault();
            jp.Discreption = "Disreption updated text....";
            jp.Budget = 10000000M;
            db.SaveChanges();
            return View("Details");
        }
    }
}