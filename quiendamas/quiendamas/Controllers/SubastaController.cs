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
    public class SubastaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subasta
        [Authorize]
        public ActionResult Index()
        {

                    var subasta = db.Subasta.Include(s => s.articulo);
            //Puja ultimoToken = (Puja)db.Puja.Where(p=>p.fechaPuja<=DateTime.Now).Last();
            //var ultimaPuja = from p in db.Puja
            //          where p.fechaPuja <= DateTime.Now
            //          select p.Id.Take();
            //String ID = (String)ultimaPuja;
            //return RedirectToAction("nombre","Account",new { ID=ID, subastas=subasta.ToList() });
            return View(subasta.ToList());

        }
        [Authorize]
        public ActionResult misSubastas(String id)
        {

                if (User.IsInRole("Administrador"))
                {
                    var subasta = db.Subasta.Include(s => s.articulo);

                    return View(subasta.ToList());
                }
            else {
                var Subastas = from puja in db.Puja
                               where puja.Id == id
                               select puja.subasta;
                //var participaciones = from puja in db.Puja
                //               where puja.Id == id 
                //               select puja.cantidadParticipaciones;
                //ViewBag.Participaciones = (int)participaciones.First();
                return View(Subastas.ToList());
            }
        }

        //[Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public ActionResult Create(int id)
        {
            ViewBag.articuloID = new SelectList(db.Articulo, "articuloID", "nombre");
            ViewBag.articuloID = id;
            return View();
        }

        // POST: Subasta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subasta subasta)
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subasta subasta)
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
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public ActionResult DeleteConfirmed(int id)
        {
            Subasta subasta = db.Subasta.Find(id);
            db.Subasta.Remove(subasta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Administrador")]
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
