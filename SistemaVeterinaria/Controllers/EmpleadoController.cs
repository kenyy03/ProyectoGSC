using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaVeterinaria.Models;
using SistemaVeterinaria.Services;

namespace SistemaVeterinaria.Controllers
{
    public class EmpleadoController : Controller
    {
        public IEmpleadoServicios empleadoServicios { get; set; }

        public EmpleadoController(IEmpleadoServicios _empleadoServicios)
        {
            empleadoServicios = _empleadoServicios; 
        }

        public ActionResult Index()
        {
            var empleados = empleadoServicios.ObtenerEmpleados();
            return View(empleados);
        }

        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var empleadoEncontrado = empleadoServicios.ObtenerEmpleadoPorID(id);
            bool esUnEmpleadoValido = empleadoEncontrado != null;
            if ( !esUnEmpleadoValido ) return HttpNotFound();
            
            return View(empleadoEncontrado);
        }

        public ActionResult Create()
        {
            ViewBag.cod_puesto = empleadoServicios.ObtenerPuestosDeEmpleados();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empleado,NOMBRE,APELLIDO,DIRECCION,DNI,fecha_ing,cod_puesto")] 
        tbEmpleado empleado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_puesto = empleadoServicios.ObtenerPuestosDeEmpleados(empleado);
                return View(empleado);
            }

            var pudoCrearElNuevoEmpleado = empleadoServicios.CrearEmpleado(empleado);
            if(!pudoCrearElNuevoEmpleado) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            return RedirectToAction("Index");

        }
        
        public ActionResult Edit(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var empleadoEncontrado = empleadoServicios.ObtenerEmpleadoPorID(id);
            bool esUnEmpleadoValido = empleadoEncontrado != null;
            
            if ( !esUnEmpleadoValido ) return HttpNotFound();
            
            ViewBag.cod_puesto = empleadoServicios.ObtenerPuestosDeEmpleados(empleadoEncontrado);
            return View(empleadoEncontrado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empleado,NOMBRE,APELLIDO,DIRECCION,DNI,fecha_ing,cod_puesto")] 
        tbEmpleado empleado)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_puesto = empleadoServicios.ObtenerPuestosDeEmpleados(empleado);
                return View(empleado);
            }

            var pudoEditarElEmpleado = empleadoServicios.EditarEmpleado(empleado);
            if ( !pudoEditarElEmpleado ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
            var empleadoEncontrado = empleadoServicios.ObtenerEmpleadoPorID(id);
            bool esUnEmpleadoValido = empleadoEncontrado != null;

            if (!esUnEmpleadoValido) return HttpNotFound();

            var pudoEliminarElEmpleado = empleadoServicios.EliminarEmpleado(id);
            if ( !pudoEliminarElEmpleado ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                empleadoServicios.DisposeEmpleado();
            }
            base.Dispose(disposing);
        }
    }
}
