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

    }
}