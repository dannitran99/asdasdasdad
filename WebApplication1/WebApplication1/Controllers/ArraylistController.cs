using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class ArraylistController : Controller
    {
        static object[] Buffer = new object[10];
        static int Length = 0;
        //
        // GET: /Arraylist/
        public ActionResult Index()
        {
            var model = new Tuple<object[], int>(Buffer, Length);            
            return View(model);
        }
        public ActionResult Append(String value) {
            Buffer[Length] = value;
            Length++;
            return RedirectToAction("Index");
        }
        public ActionResult Clear() {
            Length = 0;
            return RedirectToAction("Index");
        }
        public ActionResult InsertAt(int a, string b)
        {
            for (int i = Length - 1; i >= a; i--)
            {
                Buffer[i + 1] = Buffer[i];               
            }
            Buffer[a] = b;
            Length++;
            return RedirectToAction("Index");
        }
            

	}
}