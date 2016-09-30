using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KGTest.Models;
namespace KGTest.Controllers
{
    public class HomeController : Controller
    {
        OrderContext db = new OrderContext();

        [Authorize]
        public ActionResult Index()
        {
            IEnumerable<Order> orders = db.Orders;

            ViewBag.Orders = orders;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult AddOrder()
        {
            return View(new Order());
        }

        [HttpPost]
        public ActionResult AddOrder(Order order)
        {
            order.CreationDate = DateTime.Now;
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Index", "Home"); ;
        }

        public ActionResult EditOrder(int id)
        {
            var currentOrder = db.Orders.First(x => x.ID == id);
            return View(currentOrder);
        }

        [HttpPost]
        public ActionResult EditOrder(Order order)
        {
            var currentOrder = db.Orders.First(x => x.ID == order.ID);
            currentOrder.Number = order.Number;
            currentOrder.UnloadDate = order.UnloadDate;
            currentOrder.Manager = order.Manager;
            currentOrder.Comment = order.Comment;
            db.SaveChanges();
            return RedirectToAction("Index", "Home"); ;
        }
        public ActionResult DeleteOrder(int id)
        {
            var currentOrder = db.Orders.First(x => x.ID == id);
            return View(currentOrder);
        }

        [HttpPost]
        public ActionResult DeleteOrder(Order order)
        {
            var currentOrder = db.Orders.First(x => x.ID == order.ID);
            db.Orders.Remove(currentOrder);
            db.SaveChanges();
            return RedirectToAction("Index", "Home"); ;
        }
    }
}