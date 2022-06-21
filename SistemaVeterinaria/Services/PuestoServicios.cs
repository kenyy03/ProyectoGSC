using System.Collections.Generic;
using System.Linq;
using SistemaVeterinaria.Models;
using System.Data.Entity;

namespace SistemaVeterinaria.Services
{
    public class PuestoServicios : IPuestoServicios
    {
        public readonly VeterinariaEntities veterinariaContext;

        public PuestoServicios()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public List<tbPuesto> ObtenerPuestos()
        {
            return veterinariaContext.TPuestos.ToList();
        }

        public tbPuesto ObtenerPuestoPorID(int? id)
        {
            bool esUnIdValido = id != null;
            if (!esUnIdValido) return null;

            var puestoEncontrado = veterinariaContext.TPuestos.Find(id);

            bool esUnPuestoValido = puestoEncontrado != null;
            if (!esUnPuestoValido) return null;

            return puestoEncontrado;
        }

        public bool CrearPuesto(tbPuesto nuevoPuesto)
        {
            bool esUnPuestoValido = nuevoPuesto != null;
            if (!esUnPuestoValido) return false;

            veterinariaContext.TPuestos.Add(nuevoPuesto);
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EditarPuesto(tbPuesto puestoAEditar)
        {
            bool esUnPuestoValido = puestoAEditar != null;
            if (!esUnPuestoValido) return false;

            veterinariaContext.Entry(puestoAEditar).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EliminarPuesto(int? id)
        {
            var puestoEncontrado = veterinariaContext.TPuestos.Find(id);
            bool esUnPuestoValido = puestoEncontrado != null;

            if (!esUnPuestoValido) return false;

            veterinariaContext.TPuestos.Remove(puestoEncontrado);
            veterinariaContext.SaveChanges();
            return true;
        }

        public void DisposePuesto()
        {
            veterinariaContext.Dispose();
        }
    }
}
