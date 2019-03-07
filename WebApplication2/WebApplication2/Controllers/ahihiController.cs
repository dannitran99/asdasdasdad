using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ahihiController : Controller
    {
        //
        // GET: /ahihi/
        public ActionResult Index()
        {
            return View();
        }
        public string Showauthor() {
            return "Lê Văn Đạt";
        }
        public double factorial(int n) {
            
            double fac = 1;
            for (long i = 1; i <= n; i++) {
                fac = fac * i;
            }
            return fac;
        }
        public int sum(int a, int b) {
            return a + b;
        }
	}
}