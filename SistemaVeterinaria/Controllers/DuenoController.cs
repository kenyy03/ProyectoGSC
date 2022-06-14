using System.Net;
using System.Web.Mvc;
using SistemaVeterinaria.Services;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Controllers
{
    public class DuenoController : Controller
    {
        public IDuenoServicios duenoServicios { get; set; }

        public DuenoController(IDuenoServicios _duenoServicios)
        {
            duenoServicios = _duenoServicios;
        }

        public ActionResult Index()
        {
            return View(duenoServicios.ObtenerDuenos());
        }

        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var duenoEncontrado = duenoServicios.ObtenerDuenoPorID(id);
            bool esUnDuenoValido = duenoEncontrado != null;
            if(!esUnDuenoValido) return HttpNotFound();

            return View(duenoEncontrado);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_dueno,nombre,apellido,direccion,DNI")] 
        tbDUENO Dueno)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var pudoCrearElNuevoDueno = duenoServicios.CrearDueno(Dueno);
            if( !pudoCrearElNuevoDueno ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            return Details(id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_dueno,nombre,apellido,direccion,DNI")] 
        tbDUENO Dueno)
        {
            if (!ModelState.IsValid) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var pudoEditarAlDueno = duenoServicios.EditarDueno(Dueno);
            if( !pudoEditarAlDueno ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
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
            var pudoEliminarElDueno = duenoServicios.EliminarDueno(id);
            
            if( !pudoEliminarElDueno ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                duenoServicios.DisposeDueno();
            }
            base.Dispose(disposing);
        }
    }
}
