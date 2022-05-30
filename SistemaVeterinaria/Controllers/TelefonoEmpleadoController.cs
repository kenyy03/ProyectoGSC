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
    public class TelefonoEmpleadoController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: TelefonoEmpleado
        public ActionResult Index()
        {
            var tbTelEmpleadoes = db.tbTelEmpleadoes.Include(t => t.tbEmpleado);
            return View(tbTelEmpleadoes.ToList());
        }

        // GET: TelefonoEmpleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTelEmpleado tbTelEmpleado = db.tbTelEmpleadoes.Find(id);
            if (tbTelEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tbTelEmpleado);
        }

        // GET: TelefonoEmpleado/Create
        public ActionResult Create()
        {
            ViewBag.cod_empleado = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE");
            return View();
        }

        // POST: TelefonoEmpleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empleado,telefono")] tbTelEmpleado tbTelEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.tbTelEmpleadoes.Add(tbTelEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_empleado = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbTelEmpleado.cod_empleado);
            return View(tbTelEmpleado);
        }

        // GET: TelefonoEmpleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTelEmpleado tbTelEmpleado = db.tbTelEmpleadoes.Find(id);
            if (tbTelEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_empleado = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbTelEmpleado.cod_empleado);
            return View(tbTelEmpleado);
        }

        // POST: TelefonoEmpleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empleado,telefono")] tbTelEmpleado tbTelEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbTelEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_empleado = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbTelEmpleado.cod_empleado);
            return View(tbTelEmpleado);
        }

        // GET: TelefonoEmpleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbTelEmpleado tbTelEmpleado = db.tbTelEmpleadoes.Find(id);
            if (tbTelEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tbTelEmpleado);
        }

        // POST: TelefonoEmpleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbTelEmpleado tbTelEmpleado = db.tbTelEmpleadoes.Find(id);
            db.tbTelEmpleadoes.Remove(tbTelEmpleado);
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
