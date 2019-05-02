using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Controllers;
using WebApplication5.Models;


namespace WebApplication5.Controllers
{
    public class VLTeaController : Controller
    {
        AhihiEntities db = new AhihiEntities();
        //
        // GET: /VLTea/
        public ActionResult Index()
        {
            var model = db.BubleTeas;
            return View(model.ToList());
        }
        public ActionResult Create() {
            return View();
        }
        [HttpPost]
        public ActionResult Create(BubleTea model) {
            ValidateBubleTea(model);
            if (ModelState.IsValid) 
            {
                db.BubleTeas.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(model);
        }

        public void ValidateBubleTea(BubleTea model) { 
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}