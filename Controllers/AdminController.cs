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
                Session["userID"] = ad.AdminID;
                return RedirectToAction("Index"); 
            }
            else
            {

                return View("ErrorAdminNotFound");
            }
        }
    }
}