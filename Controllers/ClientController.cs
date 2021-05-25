using FreelancingSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreelancingSystem.Controllers
{
    public class ClientController : Controller
    {


        private FreelancingDBContext db = new FreelancingDBContext();
        public ActionResult Home()
        {
            return View();
        }
        [HttpGet]
        public ActionResult InsertClient()
        {
            return View();

        }
        [HttpPost]
        public ActionResult InsertClient(Client client)
        {
            db.Clients.Add(client);
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Login(Client client)
        {
            //to strore the user id we use Session
            string userName = client.UserName;
            string password = client.Password;
            Client cl = null;
            cl = (from clnt in db.Clients
                  where clnt.UserName == userName
                  select clnt).FirstOrDefault();


            if (cl != null && password == cl.Password)
            {
                //store the user id of the logined user to access it later
                Session["clientID"] = cl.ClientID;
                return RedirectToAction("Home"); ;
            }
            else
            {

                return View("ErrorClientNotFound");
            }
           

        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        public ActionResult CreatePost()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreatePost(JobPost post)
        {

            post.ClientID = (int)Session["ClientID"];
            db.JobPosts.Add(post);
            db.SaveChanges();
            return View("PostIsSentToAdmin");
        }
        public ActionResult EditProfile()
        {
            int id = (int)Session["clientID"];
            Client client = null;
            client = (from c in db.Clients
                      where c.ClientID == id
                      select c).FirstOrDefault();
            return View(client);
        }
        [HttpPost]
        public ActionResult EditProfile(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
            db.SaveChanges();
            return View();
        }
        public ActionResult DisplayMyPosts()
        {
            int id = (int)Session["clientID"];
            List<JobPost> postsLst = new List<JobPost>();
            postsLst = (from p in db.JobPosts
                        where p.ClientID == id
                        select p).ToList();
            return View(postsLst);
        }
    }
}