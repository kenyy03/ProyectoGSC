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
    public class EmpleadoController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Empleado
        public ActionResult Index()
        {
            var tbEmpleadoes = db.tbEmpleadoes.Include(t => t.tbPuesto);
            return View(tbEmpleadoes.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleado tbEmpleado = db.tbEmpleadoes.Find(id);
            if (tbEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleado);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            ViewBag.cod_puesto = new SelectList(db.tbPuestoes, "cod_puesto", "nombre_puesto");
            return View();
        }

        // POST: Empleado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empleado,NOMBRE,APELLIDO,DIRECCION,DNI,fecha_ing,cod_puesto")] tbEmpleado tbEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.tbEmpleadoes.Add(tbEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_puesto = new SelectList(db.tbPuestoes, "cod_puesto", "nombre_puesto", tbEmpleado.cod_puesto);
            return View(tbEmpleado);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleado tbEmpleado = db.tbEmpleadoes.Find(id);
            if (tbEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_puesto = new SelectList(db.tbPuestoes, "cod_puesto", "nombre_puesto", tbEmpleado.cod_puesto);
            return View(tbEmpleado);
        }

        // POST: Empleado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empleado,NOMBRE,APELLIDO,DIRECCION,DNI,fecha_ing,cod_puesto")] tbEmpleado tbEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_puesto = new SelectList(db.tbPuestoes, "cod_puesto", "nombre_puesto", tbEmpleado.cod_puesto);
            return View(tbEmpleado);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbEmpleado tbEmpleado = db.tbEmpleadoes.Find(id);
            if (tbEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(tbEmpleado);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbEmpleado tbEmpleado = db.tbEmpleadoes.Find(id);
            db.tbEmpleadoes.Remove(tbEmpleado);
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
