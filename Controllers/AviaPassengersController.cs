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
    public class AviaPassengersController : Controller
    {
        private avia_databaseContext db = new avia_databaseContext();

        // GET: AviaPassengers
        public ActionResult Index()
        {
            return View(db.AviaPassenger.ToList());
        }
        public ActionResult Inform()
        {
            return View(db.AviaPassenger.ToList());
        }
        // GET: AviaPassengers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AviaPassenger aviaPassenger = db.AviaPassenger.Find(id);
            if (aviaPassenger == null)
            {
                return HttpNotFound();
            }
            return View(aviaPassenger);
        }

        // GET: AviaPassengers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AviaPassengers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDPassport,Lastname,Name,Patronymic,Address,Telephone")] AviaPassenger aviaPassenger)
        {
            if (ModelState.IsValid)
            {
                db.AviaPassenger.Add(aviaPassenger);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aviaPassenger);
        }

        // GET: AviaPassengers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AviaPassenger aviaPassenger = db.AviaPassenger.Find(id);
            if (aviaPassenger == null)
            {
                return HttpNotFound();
            }
            return View(aviaPassenger);
        }

        // POST: AviaPassengers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDPassport,Lastname,Name,Patronymic,Address,Telephone")] AviaPassenger aviaPassenger)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aviaPassenger).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aviaPassenger);
        }

        // GET: AviaPassengers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AviaPassenger aviaPassenger = db.AviaPassenger.Find(id);
            if (aviaPassenger == null)
            {
                return HttpNotFound();
            }
            return View(aviaPassenger);
        }

        // POST: AviaPassengers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AviaPassenger aviaPassenger = db.AviaPassenger.Find(id);
            db.AviaPassenger.Remove(aviaPassenger);
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
