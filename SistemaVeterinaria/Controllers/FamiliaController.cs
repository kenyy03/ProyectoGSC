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
    public class FamiliaController : Controller
    {
        public IFamiliaServicios familiaServicios { get; set; }

        public FamiliaController(IFamiliaServicios _familiaServicios)
        {
            familiaServicios = _familiaServicios;
        }


        public ActionResult Index()
        {
            return View(familiaServicios.ObtenerFamilias());
        }


        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var familiaEncontrada = familiaServicios.ObtenerFamiliaPorId(id);
            bool esUnaFamiliaValida = familiaEncontrada != null;
            if (!esUnaFamiliaValida) return HttpNotFound();
            
            return View(familiaEncontrada);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_familia,nombre,descripcion")] tbfamilia familia)
        {
            if (!ModelState.IsValid) return View(familia);

            var pudoCrearLaNuevaFamilia = familiaServicios.CrearFamilia(familia);
            if ( !pudoCrearLaNuevaFamilia ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_familia,nombre,descripcion")] tbfamilia familia)
        {
            if ( !ModelState.IsValid ) return View(familia);

            var pudoEditarLaFamilia = familiaServicios.EditarFamilia(familia);
            if(!pudoEditarLaFamilia) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
            var pudoEliminarLaFamilia = familiaServicios.EliminarFamilia(id);
            if ( !pudoEliminarLaFamilia ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                familiaServicios.DisposeFamilia();
            }
            base.Dispose(disposing);
        }
    }
}
