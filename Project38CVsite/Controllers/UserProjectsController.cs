using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project38CVsite.Models;

namespace Project38CVsite.Controllers
{
    public class UserProjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserProjects
        public ActionResult Index()
        {
            var userProjects = db.userProjects.Include(u => u.ApplicationUser).Include(u => u.Project);
            return View(userProjects.ToList());
        }

        public ActionResult GetParticipants(int projectId)
        {
            var userProjects = db.userProjects.Include(m => m.ApplicationUser).Where(proj => proj.ProjectId == projectId);
            return View(userProjects.ToList());
        }

        // GET: UserProjects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userProject = db.userProjects.Find(id);
            if (userProject == null)
            {
                return HttpNotFound();
            }
            return View(userProject);
        }

        // GET: UserProjects/Create
        public ActionResult Create()
        {
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.ProjectId = new SelectList(db.projects, "Id", "Title");
            return View();
        }

        // POST: UserProjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectId,ApplicationUserId")] UserProject userProject)
        {
            if (ModelState.IsValid)
            {
                db.userProjects.Add(userProject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", userProject.ApplicationUserId);
            ViewBag.ProjectId = new SelectList(db.projects, "Id", "Title", userProject.ProjectId);
            return View(userProject);
        }

        // GET: UserProjects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userProject = db.userProjects.Find(id);
            if (userProject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", userProject.ApplicationUserId);
            ViewBag.ProjectId = new SelectList(db.projects, "Id", "Title", userProject.ProjectId);
            return View(userProject);
        }

        // POST: UserProjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectId,ApplicationUserId")] UserProject userProject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicationUserId = new SelectList(db.Users, "Id", "FirstName", userProject.ApplicationUserId);
            ViewBag.ProjectId = new SelectList(db.projects, "Id", "Title", userProject.ProjectId);
            return View(userProject);
        }

        // GET: UserProjects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProject userProject = db.userProjects.Find(id);
            if (userProject == null)
            {
                return HttpNotFound();
            }
            return View(userProject);
        }

        // POST: UserProjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProject userProject = db.userProjects.Find(id);
            db.userProjects.Remove(userProject);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
