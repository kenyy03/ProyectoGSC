using System.Web.Mvc;
using System.Data.Entity;
using SistemaVeterinaria.Models;
using System.Linq;

namespace SistemaVeterinaria.Services
{
    public class PacienteServicios : IPacienteServicios
    {
        public readonly VeterinariaEntities veterinariaContext;

        public PacienteServicios()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public IQueryable<Tbpaciente> ObtenerPacientes()
        {
            return veterinariaContext.TPaciente.Include(paciente => paciente.tbDUENO)
                                                    .Include(paciente => paciente.tbEmpleado)
                                                    .Include(paciente => paciente.tbespecie);
        }

        public Tbpaciente ObtenerPacientePorID(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return null;

            var pacienteEncontrado = veterinariaContext.TPaciente.Find(id);
            return pacienteEncontrado;
        }

        public SelectList ObtenerDuenoPorPaciente(Tbpaciente paciente)
        {
            var duenos = new SelectList(veterinariaContext.TDueno, "cod_dueno", "nombre", paciente.cod_dueno);
            return duenos;
        }
        public SelectList ObtenerDuenoPorPaciente()
        {
            var duenos = new SelectList(veterinariaContext.TDueno, "cod_dueno", "nombre");
            return duenos;
        }

        public SelectList ObtenerMedicoPorPaciente(Tbpaciente paciente)
        {
            var medicos = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE", paciente.cod_medico);
            return medicos;
        }
        public SelectList ObtenerMedicoPorPaciente()
        {
            var medicos = new SelectList(veterinariaContext.TEmpleado, "cod_empleado", "NOMBRE");
            return medicos;
        }

        public SelectList ObtenerEspeciePorPaciente(Tbpaciente paciente)
        {
            var especies = new SelectList(veterinariaContext.TEspecie, "cod_especie", "nombre", paciente.cod_especie);
            return especies;
        }
        public SelectList ObtenerEspeciePorPaciente()
        {
            var especies = new SelectList(veterinariaContext.TEspecie, "cod_especie", "nombre");
            return especies;
        }

        public bool CrearPaciente(Tbpaciente nuevoPaciente)
        {
            bool esUnPacienteValido = nuevoPaciente != null;
            if (!esUnPacienteValido) return false;

            veterinariaContext.TPaciente.Add(nuevoPaciente);
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EditarPaciente(Tbpaciente pacienteAEditar)
        {
            bool esUnPacienteValido = pacienteAEditar != null;
            if ( !esUnPacienteValido ) return false;

            veterinariaContext.Entry(pacienteAEditar).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EliminarPaciente(int? id)
        {
            var pacienteEncontrado = ObtenerPacientePorID(id);
            bool esUnPacienteValido = pacienteEncontrado != null;
            if ( !esUnPacienteValido ) return false;
            
            veterinariaContext.TPaciente.Remove(pacienteEncontrado);
            veterinariaContext.SaveChanges();
            return true;
        }

        public void DisposePaciente()
        {
            veterinariaContext.Dispose();
        }
    }
}