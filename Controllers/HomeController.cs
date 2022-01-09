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
    public class HomeController : Controller
    {
        private avia_databaseContext db;

        public HomeController()
        {
            db = new avia_databaseContext();
        }
        public ActionResult Index()
        {
            var data = db.Flight.Include(p => p.Plane).ToList();

            return View(data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

            public ActionResult GetMessage()
            {
            string[] states = new string[] { "Номер маршрута", "Номер рейса", "Аэропорт вылета", "Аэропорт назначения", "Время полета", "Бортовой номер", "Готовность самолета к вылету", "Готовность рейса", "ID командира", "Доход" };
                return PartialView(states);
            }
           
        
    }
}