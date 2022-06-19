using System.Net;
using System.Web.Mvc;
using SistemaVeterinaria.Models;
using SistemaVeterinaria.Services;

namespace SistemaVeterinaria.Controllers
{
    public class PacienteController : Controller
    {
        public IPacienteServicios pacienteServicios { get; set; }

        public PacienteController(IPacienteServicios _pacienteServicios)
        {
            pacienteServicios = _pacienteServicios;
        }
        
        public ActionResult Index()
        {
            var pacientes = pacienteServicios.ObtenerPacientes();
            return View(pacientes);
        }

        public ActionResult Details(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var pacienteEncontrado = pacienteServicios.ObtenerPacientePorID(id);

            bool esUnPacienteValido = pacienteEncontrado != null;
            if ( !esUnPacienteValido ) return HttpNotFound();
            
            return View(pacienteEncontrado);
        }
        
        public ActionResult Create()
        {
            ViewBag.cod_dueno = pacienteServicios.ObtenerDuenoPorPaciente();
            ViewBag.cod_medico = pacienteServicios.ObtenerMedicoPorPaciente();
            ViewBag.cod_especie = pacienteServicios.ObtenerEspeciePorPaciente();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_paciente,nombre,fecha_nac,cod_especie,cod_dueno,cod_medico")] 
        Tbpaciente paciente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_dueno = pacienteServicios.ObtenerDuenoPorPaciente(paciente);
                ViewBag.cod_medico = pacienteServicios.ObtenerMedicoPorPaciente(paciente);
                ViewBag.cod_especie = pacienteServicios.ObtenerEspeciePorPaciente(paciente);
                return View(paciente);
            }

            bool pudoCrearElNuevoPaciente = pacienteServicios.CrearPaciente(paciente);
            if(!pudoCrearElNuevoPaciente) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            return RedirectToAction("Index");

        }

        public ActionResult Edit(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            
            var pacienteEncontrado = pacienteServicios.ObtenerPacientePorID(id);
            bool esUnPacienteValido = pacienteEncontrado != null;

            if ( !esUnPacienteValido ) return HttpNotFound();
            
            ViewBag.cod_dueno = pacienteServicios.ObtenerDuenoPorPaciente(pacienteEncontrado);
            ViewBag.cod_medico = pacienteServicios.ObtenerMedicoPorPaciente(pacienteEncontrado);
            ViewBag.cod_especie = pacienteServicios.ObtenerEspeciePorPaciente(pacienteEncontrado);
            return View(pacienteEncontrado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_paciente,nombre,fecha_nac,cod_especie,cod_dueno,cod_medico")] 
        Tbpaciente paciente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.cod_dueno = pacienteServicios.ObtenerDuenoPorPaciente(paciente);
                ViewBag.cod_medico = pacienteServicios.ObtenerMedicoPorPaciente(paciente);
                ViewBag.cod_especie = pacienteServicios.ObtenerEspeciePorPaciente(paciente);
                return View(paciente);
            }
            bool pudoEditarElPaciente = pacienteServicios.EditarPaciente(paciente);
            if (!pudoEditarElPaciente) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
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
            bool pudoEliminarElPaciente = pacienteServicios.EliminarPaciente(id);
            if (!pudoEliminarElPaciente) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pacienteServicios.DisposePaciente();
            }
            base.Dispose(disposing);
        }
    }
}
