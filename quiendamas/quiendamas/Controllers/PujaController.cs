using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quiendamas.Models;

namespace quiendamas.Controllers
{
    public class PujaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Puja
        public ActionResult Index()
        {
            var puja = db.Puja.Include(p => p.subasta);
            return View(puja.ToList());
        }

        // GET: Puja/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puja puja = db.Puja.Find(id);
            if (puja == null)
            {
                return HttpNotFound();
            }
            return View(puja);
        }

        // GET: Puja/Create
        public ActionResult Create()
        {
            ViewBag.subastaID = new SelectList(db.Subasta, "subastaID", "ganador");
            return View();
        }

        // POST: Puja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pujaID,cantidadParticipaciones,fechaPuja,subastaID,UserID")] Puja puja)
        {
            if (ModelState.IsValid)
            {
                db.Puja.Add(puja);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.subastaID = new SelectList(db.Subasta, "subastaID", "ganador", puja.subastaID);
            return View(puja);
        }

        // GET: Puja/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puja puja = db.Puja.Find(id);
            if (puja == null)
            {
                return HttpNotFound();
            }
            ViewBag.subastaID = new SelectList(db.Subasta, "subastaID", "ganador", puja.subastaID);
            return View(puja);
        }

        // POST: Puja/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pujaID,cantidadParticipaciones,fechaPuja,subastaID,UserID")] Puja puja)
        {
            if (ModelState.IsValid)
            {
                db.Entry(puja).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.subastaID = new SelectList(db.Subasta, "subastaID", "ganador", puja.subastaID);
            return View(puja);
        }

        // GET: Puja/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Puja puja = db.Puja.Find(id);
            if (puja == null)
            {
                return HttpNotFound();
            }
            return View(puja);
        }

        // POST: Puja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Puja puja = db.Puja.Find(id);
            db.Puja.Remove(puja);
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
