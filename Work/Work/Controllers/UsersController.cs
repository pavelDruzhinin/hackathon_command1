using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Work.DataAccess;
using Work.Models;

namespace Work.Controllers
{
    public class UsersController : Controller
    {
        private DBContext db = new DBContext();
       

        // GET: Users
        [Authorize(Roles = "admin")]
        [Authorize]
        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "Name desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "Date desc" : "Date";
            var users = from s in db.Users
                           select s;

            string searchString = null;
            if (!string.IsNullOrEmpty(searchString))
            {
                users = users.Where(u => u.Name.ToUpper().Contains(searchString.ToUpper())
                                       || u.Surname.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "Name desc":
                    users = users.OrderByDescending(u => u.Name);
                    break;
                case "Date":
                    users = users.OrderBy(u => u.Birthday);
                    break;
                case "Date desc":
                    users = users.OrderByDescending(u => u.Birthday);
                    break;
                default:
                    users = users.OrderBy(u => u.Name);
                    break;
            }
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        [Authorize]
        //[Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
       // [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Exclude ="RoleId")] User user)
        {
            
            
            if (ModelState.IsValid)
            {
                Role user_role = db.Roles.FirstOrDefault(x => x.Name == "user");
                user.RoleId = user_role.Id;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home"); ;
            }

            return View(user);
        }

        // GET: Users/Edit/5
        //[Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        public ActionResult EditProfile(int? id )
        {
            if (!User.Identity.IsAuthenticated)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.FirstOrDefault(x => x.Login == User.Identity.Name);
           
            if (user == null)
            {
                return HttpNotFound();
            }

           return RedirectToAction($"Edit/{user.Id}");
           // return View(user);

        }


        //public ActionResult Confirm_Profile(User @user)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(@user).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index", "Home");
        //    }
        //    return View(@user);
        //}


        // POST: Users/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "admin")]
        public ActionResult Edit( User @user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
