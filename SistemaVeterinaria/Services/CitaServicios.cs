using System.Linq;
using SistemaVeterinaria.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace SistemaVeterinaria.Services
{
    public class CitaServicios : ICitaServicios
    {
        public readonly VeterinariaEntities veterinariaContext;
        
        public CitaServicios()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public IQueryable<tbCita> ObtenerCitas()
        {
            return veterinariaContext.TCitas.Include(cita => cita.tbEmpleado)
                                            .Include(cita => cita.Tbpaciente);
        }

        public tbCita ObtenerCitaPorID(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return null;

            var citaEncontrada = veterinariaContext.TCitas.Find(id);
            return citaEncontrada;
        }

        public SelectList ObtenerMedicosPorCita()
        {
            var medicos = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE");
            return medicos;
        }
        public SelectList ObtenerMedicosPorCita(tbCita cita)
        {
            var medicos = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE", cita.cod_medico);
            return medicos;
        }

        public SelectList ObtenerPacientesPorCita()
        {
            var pacientes = new SelectList(veterinariaContext.TPaciente, "cod_paciente", "nombre");
            return pacientes;
        }
        public SelectList ObtenerPacientesPorCita(tbCita cita)
        {
            var pacientes = new SelectList(veterinariaContext.TPaciente, "cod_paciente", "nombre", cita.cod_paciente);
            return pacientes;
        }

        public bool CrearCita(tbCita nuevaCita)
        {
            bool esUnaCitaValida = nuevaCita != null;
            if (!esUnaCitaValida) return false;

            veterinariaContext.TCitas.Add(nuevaCita);
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EditarCita(tbCita citaAEditar)
        {
            bool esUnaCitaValida = citaAEditar != null;
            if ( !esUnaCitaValida ) return false;

            veterinariaContext.Entry(citaAEditar).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EliminarCita(int? id)
        {
            var citaEncontrada = ObtenerCitaPorID(id);
            bool esUnaCitaValida = citaEncontrada != null;

            if ( !esUnaCitaValida ) return false;

            veterinariaContext.TCitas.Remove(citaEncontrada);
            veterinariaContext.SaveChanges();
            return true;
        }

        public void DisposeCita()
        {
            veterinariaContext.Dispose();
        }
    }
}