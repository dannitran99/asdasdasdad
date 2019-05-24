
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test1.Models;
using System.Transactions;

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
    
        public ActionResult Create(detail contact, string message, string Feedback_Detail)
        {
            if (ModelState.IsValid)
                using (var scope = new TransactionScope())
                {
                    contact.Status = "0";
                    db.details.Add(contact);
                    db.SaveChanges();

                    var detail = new contact();
                    detail.ContactID = contact.ID;
                    detail.CreateTime = DateTime.Now;
                    detail.Message = message;
                  
                                      
                    db.contacts.Add(detail);
                    db.SaveChanges();

                    scope.Complete();
                    return View(contact);
                }

            return View(contact);
        }

  
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }   
}   