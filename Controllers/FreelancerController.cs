using FreelancingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancingSystem.Controllers
{
    public class FreelancerController : Controller
    {

        private FreelancingDBContext db = new FreelancingDBContext();
        // display list of jobs
        public ActionResult Home()
        {
            List<JobPost> JobPostLst = new List<JobPost>();
            //Quiring using linq to entity
            JobPostLst = (from post in db.JobPosts
                          select post).ToList();
            return View(JobPostLst);

        }

        [HttpGet]
        public ActionResult InsertFreelancer()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InsertFreelancer(Freelancer freelancer)
        {
            db.Freelancers.Add(freelancer);
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(Freelancer freelancer)
        {
            //to strore the user id we use Session
            string userName = freelancer.UserName;
            string password = freelancer.Password;
            Freelancer fl = null;
            fl = (from flancer in db.Freelancers
                  where flancer.UserName == userName
                  select flancer).FirstOrDefault();


            if (fl != null && password == fl.Password)
            {
                //store the user id of the logined user to access it later
                Session["userID"] = fl.FreelancerID;
                return RedirectToAction("Home"); ;
            }
            else
            {

                return View("ErrorFreelancerNotFound");
            }

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }
        // id is the jobpost id sent by url
        public ActionResult SavePost(int id)
        {
            //check first if it is saved
            FrSavedPost post = null;
            int userID = (int)Session["userID"];
            post = (from p in db.FrSavedPosts
                    where p.PostID == id && p.FreeLancerID == userID
                    select p).FirstOrDefault();
            if (post == null)
            {
                post = new FrSavedPost();
                post.FreeLancerID = (int)Session["userID"];
                post.PostID = id;
                db.FrSavedPosts.Add(post);
                db.SaveChanges();
                return RedirectToAction("PostIsSaved");
            }
            else
            {
                return View("PostIsSaved");
            }
        }
        /*
         * To Create Edit view we need to 
         * 1.Return the object we want to edit it the [httpGet] method
         * 2.Edit the student using template t
         * 3.Make http post method  to update the row in the database
         */
        [HttpGet]
        public ActionResult EditProfile()
        {
            if (Session["userID"] != null)
            {
                int id = (int)Session["userID"];
                Freelancer flncr = db.Freelancers.Find(id);
                return View(flncr);
            }
            else
                return RedirectToAction("Home");
        }
        [HttpPost]
        public ActionResult EditProfile(Freelancer f)

        {

            db.Entry(f).State = EntityState.Modified;
            db.SaveChanges();



            return View("EditProfile");
        }
        public ActionResult ApplyPost(int id)
        {
            //check first if it is already applied
            FrAppliedPost post = null;
            int userID = (int)Session["userID"];
            post = (from p in db.FrAppliedPosts
                    where p.PostID == id && p.FreelancerID == userID
                    select p).FirstOrDefault();
            if (post == null)
            {
                post = new FrAppliedPost();
                post.FreelancerID = userID;
                post.PostID = id;
                db.FrAppliedPosts.Add(post);
                db.SaveChanges();
                return RedirectToAction("JobIsApplied");
            }
            else
            {
                return View("ErrorPostIsApplied");
            }
        }
        public ActionResult DisplaySavedPosts()
        {
            List<FrSavedPost> savedPostsLst = new List<FrSavedPost>();
            if (Session["userID"] == null)
                return View("~/Views/Home/ErrorLoginFirst.cshtml");
            int userID = (int)Session["userID"];
            savedPostsLst = (from post in db.FrSavedPosts
                             where post.FreeLancerID == userID
                             select post).ToList();
            // now extract the exact list of posts
            List<JobPost> jobPostsLst = new List<JobPost>();
            for (int i = 0; i < savedPostsLst.Count; i++)
            {
                //extract then add
                JobPost post = null;
                int postID = savedPostsLst[i].PostID;

                post = (from p in db.JobPosts
                        where p.JobPostID == postID
                        select p).FirstOrDefault();
                if (post != null)
                {
                    jobPostsLst.Add(post);
                }
            }
            return View(jobPostsLst);
        }
        public ActionResult DisplayMyJobs()
        {
            if (Session["userID"] == null)
                return View("~/Views/Home/ErrorLoginFirst.cshtml");
            int userID = (int)Session["userID"];
            var myJobsLst = new List<JobPost>();
            myJobsLst = (from post in db.JobPosts
                         where post.FreelancerId == userID
                         select post).ToList();
            return View(myJobsLst);

        }
       
       


    }
}