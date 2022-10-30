using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW06.Models;
using PagedList;
using PagedList.Mvc;
using System.Xml.Linq;

namespace HW06.Controllers
{
    public class ordersController : Controller
    {
        private BikeStoresEntities db = new BikeStoresEntities();

        //GET: orders
        public ActionResult Index(/*string searchD,*/ /*string type, string orders*/ int? i)
        {
            //return View(db.orders.Where(x => x.order_date.Equals(search) || search == null ).ToList()/*.ToPagedList(i ?? 1, 10)*/);
            var orders = db.orders.Include(o => o.customer).Include(o => o.staff).Include(o => o.store);
            return View(orders.ToList().ToPagedList(i ?? 1, 10));

        }
        [HttpPost]
        public ActionResult Index(DateTime searchD, string type, string orders, int? i)
        {
            return View(db.orders.Where(x => x.order_date.Equals(searchD) || searchD == null).ToList().ToPagedList(i ?? 1, 10));
            //var orders = db.orders.Include(o => o.customer).Include(o => o.staff).Include(o => o.store);
            //return View(orders.ToList());

        }


        //public ActionResult Index(/*string searchD,*/ /*string type, string orders*/ int? i)
        //{
        //    //return View(db.orders.Where(x => x.order_date.Equals(search) || search == null ).ToList()/*.ToPagedList(i ?? 1, 10)*/);
        //    var ViewModel = db.orders.Include(o => o.customer).Include(o => o.staff).Include(o => o.store);
        //    return View(ViewModel.ToList().ToPagedList(i ?? 1, 10));

        //}
        //[HttpPost]
        //public ActionResult Index(DateTime searchD, string type, string ViewModel, int? i)
        //{
        //    return View(db.orders.Where(x => x.order_date.Equals(searchD) || searchD == null).ToList().ToPagedList(i ?? 1, 10));
        //    //var orders = db.orders.Include(o => o.customer).Include(o => o.staff).Include(o => o.store);
        //    //return View(orders.ToList());

        //}





        // GET: orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: orders/Create
        public ActionResult Create()
        {
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "first_name");
            ViewBag.staff_id = new SelectList(db.staffs, "staff_id", "first_name");
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name");
            return View();
        }

        // POST: orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "order_id,customer_id,order_status,order_date,required_date,shipped_date,store_id,staff_id")] order order)
        {
            if (ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "first_name", order.customer_id);
            ViewBag.staff_id = new SelectList(db.staffs, "staff_id", "first_name", order.staff_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", order.store_id);
            return View(order);
        }

        // GET: orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "first_name", order.customer_id);
            ViewBag.staff_id = new SelectList(db.staffs, "staff_id", "first_name", order.staff_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", order.store_id);
            return View(order);
        }

        // POST: orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "order_id,customer_id,order_status,order_date,required_date,shipped_date,store_id,staff_id")] order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.customer_id = new SelectList(db.customers, "customer_id", "first_name", order.customer_id);
            ViewBag.staff_id = new SelectList(db.staffs, "staff_id", "first_name", order.staff_id);
            ViewBag.store_id = new SelectList(db.stores, "store_id", "store_name", order.store_id);
            return View(order);
        }

        // GET: orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            order order = db.orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            order order = db.orders.Find(id);
            db.orders.Remove(order);
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
