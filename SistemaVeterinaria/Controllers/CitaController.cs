using System.Net;
using System.Web.Mvc;
using SistemaVeterinaria.Models;
using SistemaVeterinaria.Services;

namespace SistemaVeterinaria.Controllers
{
    public class CitaController : Controller
    {
        public ICitaServicios citaServicios { get; set; }
        
        public CitaController(ICitaServicios _citaServicios)
        {
            citaServicios = _citaServicios;
        }

        public ActionResult Index()
        {
            var citas = citaServicios.ObtenerCitas();
            return View(citas);
        }

        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var citaEncontrada = citaServicios.ObtenerCitaPorID(id);
            bool esUnaCitaValida = citaEncontrada != null;
            if (!esUnaCitaValida) return HttpNotFound();
            
            return View(citaEncontrada);
        }

        public ActionResult Create()
        {
            ViewBag.cod_medico = citaServicios.ObtenerMedicosPorCita();
            ViewBag.cod_paciente = citaServicios.ObtenerPacientesPorCita();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_cita,fecha_cita,hora_cita,cod_paciente,descrip_cita,fecha,cod_medico")]
        tbCita cita)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_medico = citaServicios.ObtenerMedicosPorCita(cita);
                ViewBag.cod_paciente = citaServicios.ObtenerPacientesPorCita(cita);
                return View(cita);
            }

            var pudoCrearLaNuevaCita = citaServicios.CrearCita(cita);
            if (!pudoCrearLaNuevaCita) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var citaEncontrada = citaServicios.ObtenerCitaPorID(id);
            bool esUnaCitaValida = citaEncontrada != null;
            
            if ( !esUnaCitaValida ) return HttpNotFound();
            
            ViewBag.cod_medico = citaServicios.ObtenerMedicosPorCita(citaEncontrada);
            ViewBag.cod_paciente = citaServicios.ObtenerPacientesPorCita(citaEncontrada);
            return View(citaEncontrada);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_cita,fecha_cita,hora_cita,cod_paciente,descrip_cita,fecha,cod_medico")]
        tbCita cita)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_medico = citaServicios.ObtenerMedicosPorCita(cita);
                ViewBag.cod_paciente = citaServicios.ObtenerPacientesPorCita(cita);
                return View(cita);
            }

            bool pudoEditarLaCita = citaServicios.EditarCita(cita);
            if( !pudoEditarLaCita ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

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
            bool pudoEliminarLaCita = citaServicios.EliminarCita(id);
            if (!pudoEliminarLaCita) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                citaServicios.DisposeCita();
            }
            base.Dispose(disposing);
        }
    }
}
