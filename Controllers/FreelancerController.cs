using FreelancingSystem.Models;
using System;
using System.Collections.Generic;
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
            return RedirectToAction("Index","Home");

        }
        // id is the jobpost id sent by url
        public ActionResult SavePost(int id)
        {
            //check first if it is saved

            FrSavedPost post = new FrSavedPost();
            post.FreeLancerID = (int)Session["userID"];
            post.PostID = id;
            db.FrSavedPosts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Home", "Freelancer");
        }
    }
}