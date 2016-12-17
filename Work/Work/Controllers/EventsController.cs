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
    public class EventsController : Controller
         
       
    {
    

        private DBContext db = new DBContext();
        

        // GET: Events
        [Authorize]
        //[Authorize(Roles = "admin")]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            var events = from s in db.Events
                           select s;
            string searchString = null;
            if (!string.IsNullOrEmpty(searchString))
            {
                events = events.Where(e => e.Name.ToUpper().Contains(searchString.ToUpper())
                                       || e.Location.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name desc":
                    events = events.OrderByDescending(e => e.Name);
                    break;
                case "Date":
                    events = events.OrderBy(e => e.DateStart);
                    break;
                case "Date desc":
                    events = events.OrderByDescending(e => e.DateStart);
                    break;
                default:
                    events = events.OrderBy(e => e.Name);
                    break;
            }
            return View(db.Events.ToList());
        }

        // GET: Events/Details/5
        [Authorize]
        //[Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        [Authorize]
       // [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: Events/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        //[Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "Id,Name,Category,DateStart,DateFinish,Location,CountUsers")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(@event);
        }

        // GET: Events/Edit/5
        //[Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Category,DateStart,DateFinish,Location,CountUsers")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }

        // GET: Events/Delete/5
        // [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // [Authorize]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult AddToEvent(int? id)
        {
            var events = db.Events.FirstOrDefault(x => x.Id == id);
            User users = db.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
            var currentEU = db.EventsUsers.Where(x => x.Event.Id == id).FirstOrDefault(x => x.User.Login == User.Identity.Name);
            if (currentEU == null)
            {
                currentEU = new EventUser
                {
                    Event = events,
                    User = users
                };

                db.EventsUsers.Add(currentEU);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            else
            {
                return RedirectToAction("Index");
            }

        }

        public ActionResult ViewUser(int? id)
        {
            var ListUsers = db.EventsUsers.Include(x => x.EventId == id).Select(x => x.UserId);
            return View(ListUsers);
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
