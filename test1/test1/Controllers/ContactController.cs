
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;

namespace test1.Controllers
{   
    public class ContactController : Controller
    {
        // GET: Contact
        TestEntities db = new TestEntities();
        public ActionResult Index()
        {           
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(detail model)
        {
            ValidateBubleTea(model);
            if (ModelState.IsValid)
            {
                db.details.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public void ValidateBubleTea(detail model)
        {
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }   
}   