using FreelancingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
            int id = (int)Session["adminID"];
            ViewBag.adminName = db.Admins.Find(id).FirstName;
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

            try
            {
                db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e.Message);
                return View();
            }

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
                return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        public ActionResult EditProfile(Admin admin)
        {
            db.Entry(admin).State = EntityState.Modified;
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
        public ActionResult DisplayFreelancers()
        {
            var frelancers = new List<Freelancer>();
            frelancers = (from f in db.Freelancers
                          select f).ToList();
            return View(frelancers);
        }
        public ActionResult DetailsFreelancer(int id)
        {
            Freelancer freelancer = db.Freelancers.Find(id);
            //list of budgets of his jobs
            List<decimal> budgets = new List<decimal>();
            budgets = (from j in db.JobPosts
                       where j.FreelancerId == id
                       select j.Budget).ToList();
            decimal amount = 0;
            for (int i = 0; i < budgets.Count; i++)
            {
                amount += budgets[i];
            }
            ViewBag.amount = amount;
            ViewBag.jobs = (from j in db.JobPosts
                            where j.FreelancerId == id
                            select j).Count();
            ViewBag.appliedJobs = (from p in db.Proposals
                                   where p.FreelancerID == id
                                   select p).Count();
            return View(freelancer);
        }
        public ActionResult DeleteFreelancer(int id)
        {
            Freelancer f = db.Freelancers.Find(id);
            ViewBag.name = f.FirstName;
            //we need to check if freelancer did proposals we need to delete to prevent system from crashes.
            List<Proposal> props = new List<Proposal>();
            props = (from p in db.Proposals
                     where p.FreelancerID == id
                     select p).ToList();
            //now delete every item in proposals if its not accepted by client
            for (int i = 0; i < props.Count; i++)
            {
                if (!props[i].Accepted)
                {
                    db.Proposals.Remove(props[i]);
                    db.SaveChanges();
                }
            }
            db.Freelancers.Remove(f);
            db.SaveChanges();
            return View();

        }
        public ActionResult EditFreelancer(int id)
        {
            Freelancer flancer = db.Freelancers.Find(id);
            return View(flancer);
        }
        [HttpPost]
        public ActionResult EditFreelancer(Freelancer freelancer)
        {
            db.Entry(freelancer).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditFreelancer");
        }
        public ActionResult DisplayClients()
        {
            var clients = new List<Client>();
            clients = (from f in db.Clients
                       select f).ToList();
            return View(clients);
        }
        public ActionResult DetailsClient(int id)
        {
            Client client = db.Clients.Find(id);
            var clientPosts = new List<JobPost>();
            clientPosts = (from p in db.JobPosts
                           where p.ClientID == id
                           select p).ToList();
            int numOfPosts = clientPosts.Count;
            int acceptedPosts = 0;
            int workedPosts = 0;
            decimal totalPaid = 0;
            for (int i = 0; i < clientPosts.Count; i++)
            {
                JobPost post = clientPosts[i];
                if (post.Approved)
                {
                    acceptedPosts++;
                    if (post.FreelancerId != 0)
                    {
                        workedPosts++;
                        totalPaid += post.Budget;
                    }

                }

            }
            ViewBag.numOfPosts = numOfPosts;
            ViewBag.acceptedPosts = acceptedPosts;
            ViewBag.workedPosts = workedPosts;
            ViewBag.totalPaid = totalPaid;
            return View(client);

        }
        public ActionResult EditClient(int id)
        {
            Client client = db.Clients.Find(id);
            return View(client);
        }
        [HttpPost]
        public ActionResult EditClient(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditClient");
        }
        public ActionResult DeleteClient(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
            db.SaveChanges();
            return View();
        }
        public ActionResult DisplayPosts()
        {
            var posts = new List<JobPost>();
            posts = (from p in db.JobPosts
                     select p).ToList();
            return View(posts);
        }
        public ActionResult EditPost(int id)
        {
            JobPost post = (from p in db.JobPosts
                            where p.JobPostID == id
                            select p).FirstOrDefault();
            return View(post);
        }
        [HttpPost]
        public ActionResult EditPost(JobPost post)
        {
            db.Entry(post).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("EditPost");
        }
        public ActionResult DeletePost(int id)
        {
            JobPost post = db.JobPosts.Find(id);
            ViewBag.postName = post.Name;
            db.JobPosts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("DisplayPosts");
        }
    }
}

