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
        public readonly VeterinariaEntities veterinariaContext;

        public EmpleadoController()
        {
            veterinariaContext = new VeterinariaEntities(); 
        }

        public ActionResult Index()
        {
            var empleados = veterinariaContext.TEmpleado.Include(empleado => empleado.tbPuesto);
            return View(empleados.ToList());
        }

        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var empleadoEncontrado = veterinariaContext.TEmpleado.Find(id);
            
            bool esUnEmpleadoValido = empleadoEncontrado != null;
            if ( !esUnEmpleadoValido ) return HttpNotFound();
            
            return View(empleadoEncontrado);
        }

        public ActionResult Create()
        {
            ViewBag.cod_puesto = new SelectList(veterinariaContext.TPuestos, "cod_puesto", "nombre_puesto");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empleado,NOMBRE,APELLIDO,DIRECCION,DNI,fecha_ing,cod_puesto")] 
        tbEmpleado empleado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_puesto = new SelectList(veterinariaContext.TPuestos, "cod_puesto", "nombre_puesto", empleado.cod_puesto);
                return View(empleado);
            }

            veterinariaContext.TEmpleado.Add(empleado);
            veterinariaContext.SaveChanges();
            return RedirectToAction("Index");

        }
        
        public ActionResult Edit(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var empleadoEncontrado = veterinariaContext.TEmpleado.Find(id);
            bool esUnEmpleadoValido = empleadoEncontrado != null;
            
            if ( !esUnEmpleadoValido ) return HttpNotFound();
            
            ViewBag.cod_puesto = new SelectList(veterinariaContext.TPuestos, "cod_puesto", "nombre_puesto", empleadoEncontrado.cod_puesto);
            return View(empleadoEncontrado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empleado,NOMBRE,APELLIDO,DIRECCION,DNI,fecha_ing,cod_puesto")] 
        tbEmpleado empleado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_puesto = new SelectList(veterinariaContext.TPuestos, "cod_puesto", "nombre_puesto", empleado.cod_puesto);
                return View(empleado);
            }

            veterinariaContext.Entry(empleado).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            return Details(id);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var empleadoEncontrado = veterinariaContext.TEmpleado.Find(id);
            bool esUnEmpleadoValido = empleadoEncontrado != null;

            if (!esUnEmpleadoValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            veterinariaContext.TEmpleado.Remove(empleadoEncontrado);
            veterinariaContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                veterinariaContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
