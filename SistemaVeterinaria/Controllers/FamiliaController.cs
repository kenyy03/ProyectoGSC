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
    public class FamiliaController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Familia
        public ActionResult Index()
        {
            return View(db.tbfamilias.ToList());
        }

        // GET: Familia/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbfamilia tbfamilia = db.tbfamilias.Find(id);
            if (tbfamilia == null)
            {
                return HttpNotFound();
            }
            return View(tbfamilia);
        }

        // GET: Familia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Familia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_familia,nombre,descripcion")] tbfamilia tbfamilia)
        {
            if (ModelState.IsValid)
            {
                db.tbfamilias.Add(tbfamilia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbfamilia);
        }

        // GET: Familia/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbfamilia tbfamilia = db.tbfamilias.Find(id);
            if (tbfamilia == null)
            {
                return HttpNotFound();
            }
            return View(tbfamilia);
        }

        // POST: Familia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_familia,nombre,descripcion")] tbfamilia tbfamilia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbfamilia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbfamilia);
        }

        // GET: Familia/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbfamilia tbfamilia = db.tbfamilias.Find(id);
            if (tbfamilia == null)
            {
                return HttpNotFound();
            }
            return View(tbfamilia);
        }

        // POST: Familia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbfamilia tbfamilia = db.tbfamilias.Find(id);
            db.tbfamilias.Remove(tbfamilia);
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
