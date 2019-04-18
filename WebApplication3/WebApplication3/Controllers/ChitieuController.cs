using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication3;

namespace WebApplication3.Models
{
    public class ChitieuController : Controller
    {
        private ExpenditureEntities db = new ExpenditureEntities();

        // GET: /Chitieu/
        public ActionResult Index()
        {
            return View(db.quanlichitieux.ToList());
        }

        // GET: /Chitieu/Details/5
      

        // GET: /Chitieu/Create
        public ActionResult Create()
        {
          

            return View();
        }

        // POST: /Chitieu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(quanlichitieu model)
        {

            validateBound(model);
            if (ModelState.IsValid)
            {
                model.date = DateTime.Now;
                db.quanlichitieux.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        private void validateBound(quanlichitieu model)
        {
            if (model.amount <= 0)
            {
                ModelState.AddModelError("amount", "Không hop le");
            }
        }

        // GET: /Chitieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quanlichitieu quanlichitieu = db.quanlichitieux.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /Chitieu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(quanlichitieu model)
        {
            validateBound(model);
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: /Chitieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            quanlichitieu quanlichitieu = db.quanlichitieux.Find(id);
            if (quanlichitieu == null)
            {
                return HttpNotFound();
            }
            return View(quanlichitieu);
        }

        // POST: /Chitieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            quanlichitieu quanlichitieu = db.quanlichitieux.Find(id);
            db.quanlichitieux.Remove(quanlichitieu);
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
