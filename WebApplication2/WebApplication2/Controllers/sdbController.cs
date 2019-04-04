using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2;

namespace WebApplication2.Controllers
{
    [Authorize(Roles="mem")]
    public class sdbController : Controller
    {
        private SDBEntities db = new SDBEntities();

        // GET: /sdb/
        public ActionResult Index()
        {
            return View(db.SoDauBais.ToList());
        }

        // GET: /sdb/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            if (sodaubai == null)
            {
                return HttpNotFound();
            }
            return View(sodaubai);
        }
        // GET: /sdb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /sdb/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( SoDauBai model)
        {
            model.Ngay = DateTime.Now;
            model.GiangVien = User.Identity.Name;
            if (ModelState.IsValid) {
                db.SoDauBais.Add(model);
                db.SaveChanges();
            }

            return View(model);
        }

        // GET: /sdb/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            if (sodaubai == null)
            {
                return HttpNotFound();
            }
            return View(sodaubai);
        }

        // POST: /sdb/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Ngay,GiangVien,Noidung,NhanXet,DeXuat")] SoDauBai sodaubai)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sodaubai).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sodaubai);
        }

        // GET: /sdb/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            if (sodaubai == null)
            {
                return HttpNotFound();
            }
            return View(sodaubai);
        }

        // POST: /sdb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoDauBai sodaubai = db.SoDauBais.Find(id);
            db.SoDauBais.Remove(sodaubai);
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
