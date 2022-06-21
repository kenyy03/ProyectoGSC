using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SistemaVeterinaria.Models;
using SistemaVeterinaria.Services;

namespace SistemaVeterinaria.Controllers
{
    public class PuestoController : Controller
    {
        public IPuestoServicios puestoServicios { get; set; }

        public PuestoController(IPuestoServicios _puestoServicios)
        {
            puestoServicios = _puestoServicios;
        }

        public ActionResult Index()
        {
            return View(puestoServicios.ObtenerPuestos());
        }

        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var puestoEncontrado = puestoServicios.ObtenerPuestoPorID(id);
            bool esUnPuestoValido = puestoEncontrado != null;
            if ( !esUnPuestoValido ) return HttpNotFound();
            
            return View(puestoEncontrado);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_puesto,nombre_puesto,salario")] 
        tbPuesto puesto)
        {
            if (!ModelState.IsValid) return View(puesto);

            bool pudoCrearElNuevoPuesto = puestoServicios.CrearPuesto(puesto);
            if(!pudoCrearElNuevoPuesto) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_puesto,nombre_puesto,salario")] 
        tbPuesto puesto)
        {
            if (!ModelState.IsValid) return View(puesto);

            bool pudoEditarElPuesto = puestoServicios.EditarPuesto(puesto);
            if (!pudoEditarElPuesto) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
            bool pudoEliminarElPuesto = puestoServicios.EliminarPuesto(id);
            
            if (!pudoEliminarElPuesto) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                puestoServicios.DisposePuesto();
            }
            base.Dispose(disposing);
        }
    }
}
