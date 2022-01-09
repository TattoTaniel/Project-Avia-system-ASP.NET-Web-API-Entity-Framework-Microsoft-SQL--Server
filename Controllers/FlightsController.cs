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
    public class FlightsController : Controller
    {
        private avia_databaseContext db = new avia_databaseContext();

        // GET: Flights
        public ActionResult Index()
        {
            var flight = db.Flight.Include(f => f.AviaPassenger);
            return View(flight.ToList());
        }
        public ActionResult Inform()
        {
            var flight = db.Flight.Include(f => f.AviaPassenger);
            return View(flight.ToList());
        }

        // GET: Flights/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // GET: Flights/Create
        public ActionResult Create()
        {
            ViewBag.IDPassport = new SelectList(db.AviaPassenger, "IDPassport", "Lastname");
            return View();
        }

        // POST: Flights/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDFlight,Departure_date,Departure_time,Readiness,IDPassport")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Flight.Add(flight);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDPassport = new SelectList(db.AviaPassenger, "IDPassport", "Lastname", flight.IDPassport);
            return View(flight);
        }

        // GET: Flights/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDPassport = new SelectList(db.AviaPassenger, "IDPassport", "Lastname", flight.IDPassport);
            return View(flight);
        }

        // POST: Flights/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в разделе https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDFlight,Departure_date,Departure_time,Readiness,IDPassport")] Flight flight)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flight).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDPassport = new SelectList(db.AviaPassenger, "IDPassport", "Lastname", flight.IDPassport);
            return View(flight);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flight flight = db.Flight.Find(id);
            if (flight == null)
            {
                return HttpNotFound();
            }
            return View(flight);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flight flight = db.Flight.Find(id);
            db.Flight.Remove(flight);
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
