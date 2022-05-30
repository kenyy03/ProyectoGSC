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
    public class UsuarioController : Controller
    {
        private VeterinariaEntities db = new VeterinariaEntities();

        // GET: Usuario
        public ActionResult Index()
        {
            var tbusuarios = db.tbusuarios.Include(t => t.tbEmpleado);
            return View(tbusuarios.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbusuario tbusuario = db.tbusuarios.Find(id);
            if (tbusuario == null)
            {
                return HttpNotFound();
            }
            return View(tbusuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.cod_emp = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_emp,cod_user,nombre,contrasena")] tbusuario tbusuario)
        {
            if (ModelState.IsValid)
            {
                db.tbusuarios.Add(tbusuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_emp = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbusuario.cod_emp);
            return View(tbusuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbusuario tbusuario = db.tbusuarios.Find(id);
            if (tbusuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_emp = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbusuario.cod_emp);
            return View(tbusuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_emp,cod_user,nombre,contrasena")] tbusuario tbusuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbusuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_emp = new SelectList(db.tbEmpleadoes, "cod_empleado", "NOMBRE", tbusuario.cod_emp);
            return View(tbusuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbusuario tbusuario = db.tbusuarios.Find(id);
            if (tbusuario == null)
            {
                return HttpNotFound();
            }
            return View(tbusuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbusuario tbusuario = db.tbusuarios.Find(id);
            db.tbusuarios.Remove(tbusuario);
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
