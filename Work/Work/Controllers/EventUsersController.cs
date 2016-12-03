using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Work.DataAccess;
using Work.Models;

namespace Work.Controllers
{
    public class EventUsersController : Controller
    {
        private DBContext db = new DBContext();

        // GET: EventUsers
        public ActionResult Index()
        {
            var eventsUsers = db.EventsUsers.Include(e => e.Event).Include(e => e.User);
            return View(eventsUsers.ToList());
        }

        // GET: EventUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventUser eventUser = db.EventsUsers.Find(id);
            if (eventUser == null)
            {
                return HttpNotFound();
            }
            return View(eventUser);
        }

        // GET: EventUsers/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name");
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name");
            return View();
        }

        // POST: EventUsers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,UserId,Id")] EventUser eventUser)
        {
            if (ModelState.IsValid)
            {
                db.EventsUsers.Add(eventUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventUser.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", eventUser.UserId);
            return View(eventUser);
        }

        // GET: EventUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventUser eventUser = db.EventsUsers.Find(id);
            if (eventUser == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventUser.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", eventUser.UserId);
            return View(eventUser);
        }

        // POST: EventUsers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,UserId,Id")] EventUser eventUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Name", eventUser.EventId);
            ViewBag.UserId = new SelectList(db.Users, "Id", "Name", eventUser.UserId);
            return View(eventUser);
        }

        // GET: EventUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventUser eventUser = db.EventsUsers.Find(id);
            if (eventUser == null)
            {
                return HttpNotFound();
            }
            return View(eventUser);
        }

        // POST: EventUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventUser eventUser = db.EventsUsers.Find(id);
            db.EventsUsers.Remove(eventUser);
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
