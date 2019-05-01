using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication4.Controllers;
using WebApplication4.Models;
using System.Linq;
using System.Web.Mvc;
using System.Collections.Generic;


namespace WebApplication4.Tests.Controllers
{
    [TestClass]
    public class BubleTsControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
            var db = new bubleteaEntities();
            var controller = new BubleTsController();
            var result = controller.Index();

            var view = result as ViewResult;
            Assert.IsNotNull(view);

            var model = view.Model as List<BubleT>;
            Assert.IsNotNull(model);
            Assert.AreEqual(db.BubleTs.Count(), model.Count);

        }
        [TestMethod]
        public void TestEditG()
        {
            var controller = new BubleTsController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new bubleteaEntities();
            var item = db.BubleTs.First();
            var result1 = controller.Edit(item.ID) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleT;
            Assert.AreEqual(item.ID, model.ID);


        }

        [TestMethod]
        public void testCreateP()
        {
            var db = new bubleteaEntities();
            var model = new BubleT
            {
                Name = "tra sua vl",
                Price = 25000,
                Topping = "Trang chau trang"
            };
            var controller = new BubleTsController();

            var result = controller.Create(model);
            var redirect = result as RedirectToRouteResult;
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
            var item = db.BubleTs.Find(model.ID);
            Assert.IsNotNull(item);
            Assert.AreEqual(model.Name, item.Name);
            Assert.AreEqual(model.Price, item.Price);
            Assert.AreEqual(model.Topping, item.Topping);
        }

    }
}

