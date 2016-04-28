using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using quiendamas.Models;
using Microsoft.AspNet.Identity;



namespace quiendamas.Controllers
{
    public class PujaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Puja
        [Authorize]
        public ActionResult Index(String id)
        {
            
            if (Request.IsAuthenticated)
            {
                if (User.IsInRole("Administrador"))
                {
                    var puja1 = db.Puja.Include(p => p.subasta);
                    return View(puja1.ToList());
                }
                //var puja = db.Puja.Include(p => p.subasta);

            }
            var puja2 = db.Puja.Where(pu => pu.Id == id);

            return View(puja2.ToList());
        }

        // GET: Puja/Details/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize]
        public ActionResult Create(int id)
        {
            int cantidadAnterior = 0,cantRegistros = 0;
            //ViewBag.subastaID = new SelectList(db.Subasta, "subastaID", "ganador");
            //ViewBag.IDSubasta = id;
            String userId = User.Identity.GetUserId();
            try {

                var pu = db.Puja.Where(p=>p.subastaID==id&&p.Id== userId);
                cantRegistros = pu.Count();
            }
            catch { }
            if (cantRegistros > 0)
            {
                Puja puja = db.Puja.Where(p => p.Id == userId && p.subastaID==id).First();
                cantidadAnterior = db.Puja.Where(mov => mov.subastaID == id && mov.Id == userId).First().cantidadParticipaciones;
                puja.cantidadParticipaciones = cantidadAnterior + 1;
                db.Entry(puja).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Tiempo = (int)db.Subasta.Find(id).tiempo;
                ViewBag.Participaciones = puja.cantidadParticipaciones;
                return RedirectToAction("Details", "Subasta", new { id = id });
            }
            else {
                Puja puja = new Puja();
                puja.cantidadParticipaciones = 1;
                puja.subastaID = id;
                puja.Id = userId;
                puja.fechaPuja = DateTime.Today;
                db.Puja.Add(puja);
                db.SaveChanges();
                ViewBag.Tiempo = (int)db.Subasta.Find(id).tiempo;
                ViewBag.Participaciones = puja.cantidadParticipaciones;
                return RedirectToAction("Details", "Subasta", new { id = id });
            }


        }

        // POST: Puja/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "pujaID,cantidadParticipaciones,fechaPuja,subastaID,UserID")] Puja puja)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Puja.Add(puja);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.subastaID = new SelectList(db.Subasta, "subastaID", "ganador", puja.subastaID);
        //    return View(puja);
        //}

        // GET: Puja/Edit/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public ActionResult Edit(Puja puja)
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
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
