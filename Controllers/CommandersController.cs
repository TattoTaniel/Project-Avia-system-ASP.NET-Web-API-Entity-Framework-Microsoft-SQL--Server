using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Avia_is.Models;

namespace Avia_is.Controllers
{
    public class CommandersController : Controller
    {
        private avia_databaseContext db = new avia_databaseContext();

        // GET: Commanders
        public ActionResult Index()
        {
            var commander = db.Commander.Include(c => c.Plane);
            return View(commander.ToList());
        }
        public ActionResult Inform()
        {
            var commander = db.Commander.Include(c => c.Plane);
            return View(commander.ToList());
        }

        // GET: Commanders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commander commander = db.Commander.Find(id);
            if (commander == null)
            {
                return HttpNotFound();
            }
            return View(commander);
        }

        // GET: Commanders/Create
        public ActionResult Create()
        {
            ViewBag.IDBort = new SelectList(db.Plane, "IDBort", "Model");
            return View();
        }

        // POST: Commanders/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_number,Lastname,Name,Patronymic,Address,Flying_hours,IDBort")] Commander commander)
        {
            if (ModelState.IsValid)
            {
                db.Commander.Add(commander);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDBort = new SelectList(db.Plane, "IDBort", "Model", commander.IDBort);
            return View(commander);
        }

        // GET: Commanders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commander commander = db.Commander.Find(id);
            if (commander == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDBort = new SelectList(db.Plane, "IDBort", "Model", commander.IDBort);
            return View(commander);
        }

        // POST: Commanders/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_number,Lastname,Name,Patronymic,Address,Flying_hours,IDBort")] Commander commander)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commander).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDBort = new SelectList(db.Plane, "IDBort", "Model", commander.IDBort);
            return View(commander);
        }

        // GET: Commanders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Commander commander = db.Commander.Find(id);
            if (commander == null)
            {
                return HttpNotFound();
            }
            return View(commander);
        }

        // POST: Commanders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Commander commander = db.Commander.Find(id);
            db.Commander.Remove(commander);
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
