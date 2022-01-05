using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Project38CVsite.Models;

namespace Project38CVsite.Controllers
{
    public class Messages1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages1
        public ActionResult Index()
        {
            var messages = db.messages.Include(m => m.FromUser).Include(m => m.User);
            return View(messages.ToList());
        }


        public ActionResult GetMessage()
        {
            var userId = User.Identity.GetUserId();
            var message = db.messages.Include(m => m.FromUser).Where(e => e.ToUserId == userId).ToList();

            if (message == null)
            {
                return HttpNotFound();
            }

            return View(message);
        }


        // GET: Messages1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages1/Create
        public ActionResult Create()
        {
            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FirstName");
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FirstName");
            return View();
        }

        // POST: Messages1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Content,IsRead,FromName,FromUserId,ToUserId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.messages.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FirstName", message.FromUserId);
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FirstName", message.ToUserId);
            return View(message);
        }

        // GET: Messages1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FirstName", message.FromUserId);
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FirstName", message.ToUserId);
            return View(message);
        }

        // POST: Messages1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Content,IsRead,FromName,FromUserId,ToUserId")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FromUserId = new SelectList(db.Users, "Id", "FirstName", message.FromUserId);
            ViewBag.ToUserId = new SelectList(db.Users, "Id", "FirstName", message.ToUserId);
            return View(message);
        }

        // GET: Messages1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.messages.Find(id);
            db.messages.Remove(message);
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
