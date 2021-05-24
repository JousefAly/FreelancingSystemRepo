using FreelancingSystem.Models;
using System;
using System.Collections.Generic;
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
            return View("Index");
        }

        public ActionResult profile_info(int id)  // show detailes of user
        {
            var myprofile = db.Clients.Single(a => a.ClientID == id);
            if (myprofile == null)
                return HttpNotFound();

            return View(myprofile);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var editProfile = db.Clients.Single(a => a.ClientID == id);
            if (editProfile == null)
                return HttpNotFound();

            return View(editProfile);
        }

        [HttpPost]
        public ActionResult Edit(Client client)
        {
            var editProfile = db.Clients.Single(a => a.ClientID == client.ClientID);

            editProfile.FirstName = client.FirstName;
            editProfile.LastName = client.LastName;
            editProfile.Password = client.Password;
            editProfile.PhoneNumber = client.PhoneNumber;
            editProfile.UserName = client.UserName;

            db.SaveChanges();



            return RedirectToAction("InsertJobPost");
        }

    }
}