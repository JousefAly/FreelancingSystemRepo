using FreelancingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancingSystem.Controllers
{
    public class AdminController : Controller
    {
        private FreelancingDBContext db = new FreelancingDBContext();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterAdmin(Admin admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            string userName = admin.UserName;
            string password = admin.Password;
            Admin ad = null;
            ad = (from a in db.Admins
                  where a.UserName == userName
                  select a).FirstOrDefault();


            if (ad != null && password == ad.Password)
            {

                //store the user id of the logined user to access it later
                Session["adminID"] = ad.AdminID;
                return RedirectToAction("Index");
            }
            else
            {

                return View("ErrorAdminNotFound");
            }
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult EditProfile()
        {


            if (Session["adminID"] != null)
            {
                int id = (int)Session["adminID"];
                Admin admn = db.Admins.Find(id);
                return View(admn);
            }
            else
                return RedirectToAction("Index","Home");

        }
        [HttpPost]
        public ActionResult EditProfile(Admin admin)
        {
            // return to the same page to see the new changes
            return View("EditProfile");
        }
        public ActionResult DisplayPostRequests()
        {
            var postsLst = new List<JobPost>();
            postsLst = (from p in db.JobPosts
                        where p.Approved == false
                        select p).ToList();
            return View(postsLst);
        }
        public ActionResult ApprovePost(int id)
        {
            JobPost jobPost = null;
            jobPost = (from p in db.JobPosts
                       where p.JobPostID == id
                       select p).FirstOrDefault();
            jobPost.Approved = true;
            db.SaveChanges();
            return RedirectToAction("DisplayPostRequests");
        }
    }
}