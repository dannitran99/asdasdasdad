using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using test1.Models;
using System.Transactions;

namespace test1.Controllers
{
    public class ViewContactController : Controller
    {
        TestEntities db = new TestEntities(); 
        // GET: ViewContact
        public ActionResult Index()
        {
            var model = db.contacts;
            return View(model.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            detail tmp = db.details.Find(id);
            if (tmp == null)
            {
                return HttpNotFound();
            }
            return View(tmp);
        }
      

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            contact tmp = db.contacts.Find(id);
            if (tmp == null)
            {
                return HttpNotFound();
            }
            return View(tmp);
        }
        [HttpPost]
        public ActionResult Edit(contact ct)
        {
            if (ModelState.IsValid)
            {

                db.Entry(ct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(ct);
        }


        
    }
}
//[HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "Watch_ID,Watch_Name,Watch_Description,Watch_Static,WatchType_ID,Original_Price,Selling_Price,InStock")] ProductTable producttable)
//        {
//            ValidateClock(producttable);
//            if (ModelState.IsValid)
//            {
//                using (var scope = new TransactionScope())
//                {
//                    // add model to database
//                    db.Entry(producttable).State = EntityState.Modified;
//                    db.SaveChanges();
//                    // save file to app_data
//                    var path = Server.MapPath("~/App_Data");
//                    path = System.IO.Path.Combine(path, producttable.Watch_ID.ToString());
//                    Request.Files["Image"].SaveAs(path + "_0");
//                    Request.Files["Image1"].SaveAs(path + "_1");
//                    Request.Files["Image2"].SaveAs(path + "_2");
//                    // all done successfully
//                    scope.Complete();
//                    return RedirectToAction("Index");
//                }
//            }
//            //ViewBag.WatchType_ID = new SelectList(db.ProductTypes, "ProductType_ID", "ProductType_Name", producttable.WatchType_ID);
//            return View("Edit", producttable);
//        }