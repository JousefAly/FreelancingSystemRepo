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
        // Get list of Freelancers
        public ActionResult Index()
        {
            
            return View();
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
            return View("Index");
        }
    }
}