using System.Linq;
using SistemaVeterinaria.Models;
using System.Web.Mvc;

namespace SistemaVeterinaria.Services
{
    public interface ICitaServicios
    {
        IQueryable<tbCita> ObtenerCitas();

        tbCita ObtenerCitaPorID(int? id);

        SelectList ObtenerMedicosPorCita();

        SelectList ObtenerMedicosPorCita(tbCita cita);

        SelectList ObtenerPacientesPorCita();

        SelectList ObtenerPacientesPorCita(tbCita cita);

        bool CrearCita(tbCita nuevaCita);

        bool EditarCita(tbCita citaAEditar);

        bool EliminarCita(int? id);

        void DisposeCita();

    }
}
