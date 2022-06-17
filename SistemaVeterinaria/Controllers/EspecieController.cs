using System.Net;
using System.Web.Mvc;
using SistemaVeterinaria.Models;
using SistemaVeterinaria.Services;

namespace SistemaVeterinaria.Controllers
{
    public class EspecieController : Controller
    {
        public IEspecieServicios especieServicios { get; set; }

        public EspecieController(IEspecieServicios _especieServicios)
        {
            especieServicios = _especieServicios;
        }

        public ActionResult Index()
        {
            var especies = especieServicios.ObtenerEspecies();
            return View(especies);
        }

        public ActionResult Details(int? id)
        {
            var esUnIdValido = id != null;
            if ( !esUnIdValido ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var especieEncontrada = especieServicios.ObtenerEspeciePorID(id);
            bool esUnaEspecieValida = especieEncontrada != null;
            if ( !esUnaEspecieValida ) return HttpNotFound();
            
            return View(especieEncontrada);
        }

        public ActionResult Create()
        {
            ViewBag.cod_familia = especieServicios.ObtenerFamiliaDeEspecie();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_especie,nombre,descripcion,cod_familia")] 
        tbespecie especie)
        {
            if ( !ModelState.IsValid )
            {
                ViewBag.cod_familia = especieServicios.ObtenerFamiliaDeEspecie(especie);
                return View(especie);
            }

            var pudoCrearLaNuevaEspecie = especieServicios.CrearEspecie(especie);
            if(!pudoCrearLaNuevaEspecie) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var especieEncontrada = especieServicios.ObtenerEspeciePorID(id);
            bool esUnaEspecieValida = especieEncontrada != null;
            if (!esUnaEspecieValida) return HttpNotFound();
            
            ViewBag.cod_familia = especieServicios.ObtenerFamiliaDeEspecie(especieEncontrada);
            return View(especieEncontrada);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_especie,nombre,descripcion,cod_familia")] 
        tbespecie especie)
        {
            if ( !ModelState.IsValid )
            {
                ViewBag.cod_familia = especieServicios.ObtenerFamiliaDeEspecie(especie);
                return View(especie);
            }

            var pudoCrearLaNuevaEspecie = especieServicios.EditarEspecie(especie);
            if ( !pudoCrearLaNuevaEspecie ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
            var pudoEliminarLaEspecie = especieServicios.EliminarEspecie(id);
            if (!pudoEliminarLaEspecie) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                especieServicios.DisposeEspecie();
            }
            base.Dispose(disposing);
        }
    }
}
