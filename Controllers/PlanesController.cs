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
    public class PlanesController : Controller
    {
        private avia_databaseContext db = new avia_databaseContext();

        // GET: Planes
        public ActionResult Index()
        {
            var plane = db.Plane.Include(p => p.Flight);
            return View(plane.ToList());
        }
        public ActionResult Inform()
        {
            var plane = db.Plane.Include(p => p.Flight);
            return View(plane.ToList());
        }

        // GET: Planes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Plane.Find(id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }

        // GET: Planes/Create
        public ActionResult Create()
        {
            ViewBag.IDFlight = new SelectList(db.Flight, "IDFlight", "IDFlight");
            return View();
        }

        // POST: Planes/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDBort,Model,Lifetime,Readiness,IDFlight")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                db.Plane.Add(plane);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDFlight = new SelectList(db.Flight, "IDFlight", "IDFlight", plane.IDFlight);
            return View(plane);
        }

        // GET: Planes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Plane.Find(id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDFlight = new SelectList(db.Flight, "IDFlight", "IDFlight", plane.IDFlight);
            return View(plane);
        }

        // POST: Planes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDBort,Model,Lifetime,Readiness,IDFlight")] Plane plane)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plane).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDFlight = new SelectList(db.Flight, "IDFlight", "IDFlight", plane.IDFlight);
            return View(plane);
        }

        // GET: Planes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plane plane = db.Plane.Find(id);
            if (plane == null)
            {
                return HttpNotFound();
            }
            return View(plane);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plane plane = db.Plane.Find(id);
            db.Plane.Remove(plane);
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
