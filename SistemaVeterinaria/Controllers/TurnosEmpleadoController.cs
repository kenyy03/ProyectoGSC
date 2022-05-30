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
    public class TurnosEmpleadoController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: TurnosEmpleado
        public ActionResult Index()
        {
            return View(db.tbTurnoes.ToList());
        }

        // GET: TurnosEmpleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTurno tbTurno = db.tbTurnoes.Find(id);
            if (tbTurno == null)
            {
                return HttpNotFound();
            }
            return View(tbTurno);
        }

        // GET: TurnosEmpleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurnosEmpleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_turno,nombre,hora_inicio,hora_fin")] tbTurno tbTurno)
        {
            if (ModelState.IsValid)
            {
                db.tbTurnoes.Add(tbTurno);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbTurno);
        }

        // GET: TurnosEmpleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTurno tbTurno = db.tbTurnoes.Find(id);
            if (tbTurno == null)
            {
                return HttpNotFound();
            }
            return View(tbTurno);
        }

        // POST: TurnosEmpleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_turno,nombre,hora_inicio,hora_fin")] tbTurno tbTurno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTurno).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbTurno);
        }

        // GET: TurnosEmpleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTurno tbTurno = db.tbTurnoes.Find(id);
            if (tbTurno == null)
            {
                return HttpNotFound();
            }
            return View(tbTurno);
        }

        // POST: TurnosEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTurno tbTurno = db.tbTurnoes.Find(id);
            db.tbTurnoes.Remove(tbTurno);
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
