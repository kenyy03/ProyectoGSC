using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Controllers
{
    public class PuestoController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Puesto
        public ActionResult Index()
        {
            return View(db.TPuestos.ToList());
        }

        // GET: Puesto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPuesto tbPuesto = db.TPuestos.Find(id);
            if (tbPuesto == null)
            {
                return HttpNotFound();
            }
            return View(tbPuesto);
        }

        // GET: Puesto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Puesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_puesto,nombre_puesto,salario")] tbPuesto tbPuesto)
        {
            if (ModelState.IsValid)
            {
                db.TPuestos.Add(tbPuesto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbPuesto);
        }

        // GET: Puesto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPuesto tbPuesto = db.TPuestos.Find(id);
            if (tbPuesto == null)
            {
                return HttpNotFound();
            }
            return View(tbPuesto);
        }

        // POST: Puesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_puesto,nombre_puesto,salario")] tbPuesto tbPuesto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbPuesto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbPuesto);
        }

        // GET: Puesto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbPuesto tbPuesto = db.TPuestos.Find(id);
            if (tbPuesto == null)
            {
                return HttpNotFound();
            }
            return View(tbPuesto);
        }

        // POST: Puesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbPuesto tbPuesto = db.TPuestos.Find(id);
            db.TPuestos.Remove(tbPuesto);
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
