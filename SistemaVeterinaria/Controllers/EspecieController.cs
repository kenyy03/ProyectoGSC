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
    public class EspecieController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Especie
        public ActionResult Index()
        {
            var tbespecies = db.tbespecies.Include(t => t.tbfamilia);
            return View(tbespecies.ToList());
        }

        // GET: Especie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbespecie tbespecie = db.tbespecies.Find(id);
            if (tbespecie == null)
            {
                return HttpNotFound();
            }
            return View(tbespecie);
        }

        // GET: Especie/Create
        public ActionResult Create()
        {
            ViewBag.cod_familia = new SelectList(db.tbfamilias, "cod_familia", "nombre");
            return View();
        }

        // POST: Especie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_especie,nombre,descripcion,cod_familia")] tbespecie tbespecie)
        {
            if (ModelState.IsValid)
            {
                db.tbespecies.Add(tbespecie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_familia = new SelectList(db.tbfamilias, "cod_familia", "nombre", tbespecie.cod_familia);
            return View(tbespecie);
        }

        // GET: Especie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbespecie tbespecie = db.tbespecies.Find(id);
            if (tbespecie == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_familia = new SelectList(db.tbfamilias, "cod_familia", "nombre", tbespecie.cod_familia);
            return View(tbespecie);
        }

        // POST: Especie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_especie,nombre,descripcion,cod_familia")] tbespecie tbespecie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbespecie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_familia = new SelectList(db.tbfamilias, "cod_familia", "nombre", tbespecie.cod_familia);
            return View(tbespecie);
        }

        // GET: Especie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbespecie tbespecie = db.tbespecies.Find(id);
            if (tbespecie == null)
            {
                return HttpNotFound();
            }
            return View(tbespecie);
        }

        // POST: Especie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbespecie tbespecie = db.tbespecies.Find(id);
            db.tbespecies.Remove(tbespecie);
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
