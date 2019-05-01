using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4;

namespace WebApplication4.Controllers
{
    public class BubleTsController : Controller
    {
        private bubleteaEntities db = new bubleteaEntities();

        // GET: BubleTs
        public ActionResult Index()
        {
            return View(db.BubleTs.ToList());
        }

        // GET: BubleTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleT bubleT = db.BubleTs.Find(id);
            if (bubleT == null)
            {
                return HttpNotFound();
            }
            return View(bubleT);
        }

        // GET: BubleTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BubleTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Topping,Note")] BubleT bubleT)
        {
            if (ModelState.IsValid)
            {
                db.BubleTs.Add(bubleT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bubleT);
        }

        // GET: BubleTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleT bubleT = db.BubleTs.Find(id);
            if (bubleT == null)
            {
                return HttpNotFound();
            }
            return View(bubleT);
        }

        // POST: BubleTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Topping,Note")] BubleT bubleT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bubleT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bubleT);
        }

        // GET: BubleTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BubleT bubleT = db.BubleTs.Find(id);
            if (bubleT == null)
            {
                return HttpNotFound();
            }
            return View(bubleT);
        }

        // POST: BubleTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BubleT bubleT = db.BubleTs.Find(id);
            db.BubleTs.Remove(bubleT);
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
