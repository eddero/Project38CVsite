using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Project38CVsite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project38CVsite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public HomeController()
        {

        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Index1(string search)
        {

            return View(db.Users.Where(x => x.FirstName.StartsWith(search) || search == null).ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // GET: Projects/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var project = db.Users.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            return View(project);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}