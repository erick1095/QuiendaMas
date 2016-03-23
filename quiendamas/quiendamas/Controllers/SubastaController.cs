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
    public class SubastaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subasta
        public ActionResult Index()
        {
            var subasta = db.Subasta.Include(s => s.articulo);
            return View(subasta.ToList());
        }

        // GET: Subasta/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subasta subasta = db.Subasta.Find(id);
            if (subasta == null)
            {
                return HttpNotFound();
            }
            return View(subasta);
        }

        // GET: Subasta/Create
        public ActionResult Create()
        {
            ViewBag.articuloID = new SelectList(db.Articulo, "articuloID", "nombre");
            return View();
        }

        // POST: Subasta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subastaID,estado,fechaInicio,fechaFin,ganador,articuloID")] Subasta subasta)
        {
            if (ModelState.IsValid)
            {
                db.Subasta.Add(subasta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.articuloID = new SelectList(db.Articulo, "articuloID", "nombre", subasta.articuloID);
            return View(subasta);
        }

        // GET: Subasta/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subasta subasta = db.Subasta.Find(id);
            if (subasta == null)
            {
                return HttpNotFound();
            }
            ViewBag.articuloID = new SelectList(db.Articulo, "articuloID", "nombre", subasta.articuloID);
            return View(subasta);
        }

        // POST: Subasta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subastaID,estado,fechaInicio,fechaFin,ganador,articuloID")] Subasta subasta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subasta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.articuloID = new SelectList(db.Articulo, "articuloID", "nombre", subasta.articuloID);
            return View(subasta);
        }

        // GET: Subasta/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subasta subasta = db.Subasta.Find(id);
            if (subasta == null)
            {
                return HttpNotFound();
            }
            return View(subasta);
        }

        // POST: Subasta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subasta subasta = db.Subasta.Find(id);
            db.Subasta.Remove(subasta);
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
