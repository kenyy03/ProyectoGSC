using System.Linq;
using SistemaVeterinaria.Models;
using System.Web.Mvc;

namespace SistemaVeterinaria.Services
{
    public interface IPacienteServicios
    {
        IQueryable<Tbpaciente> ObtenerPacientes();

        Tbpaciente ObtenerPacientePorID(int? id);

        SelectList ObtenerDuenoPorPaciente(Tbpaciente paciente);

        SelectList ObtenerDuenoPorPaciente();

        SelectList ObtenerMedicoPorPaciente(Tbpaciente paciente);

        SelectList ObtenerMedicoPorPaciente();

        SelectList ObtenerEspeciePorPaciente(Tbpaciente paciente);

        SelectList ObtenerEspeciePorPaciente();

        bool CrearPaciente(Tbpaciente nuevoPaciente);

        bool EditarPaciente(Tbpaciente pacienteAEditar);

        bool EliminarPaciente(int? id);

        void DisposePaciente();
    }
}
