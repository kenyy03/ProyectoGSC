using System.Collections.Generic;
using System.Linq;
using SistemaVeterinaria.Models;
using System.Data.Entity;

namespace SistemaVeterinaria.Services
{
    public class DuenoServicios : IDuenoServicios
    {
        public readonly VeterinariaEntities veterinariaContext;

        public DuenoServicios()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public List<tbDUENO> ObtenerDuenos()
        {
            return veterinariaContext.TDueno.ToList();
        }

        public tbDUENO ObtenerDuenoPorID(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return null;

            var duenoEncontrado = veterinariaContext.TDueno.Find(id);
            
            bool esUnDuenoValido = duenoEncontrado != null;
            if( !esUnDuenoValido ) return null;

            return duenoEncontrado;
        }

        public bool CrearDueno(tbDUENO nuevoDueno)
        {
            bool esUnDuenoValido = nuevoDueno != null;
            if( !esUnDuenoValido ) return false;

            veterinariaContext.TDueno.Add(nuevoDueno);
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EditarDueno(tbDUENO duenoAEditar)
        {
            bool esUnDuenoValido = duenoAEditar != null;
            if( !esUnDuenoValido ) return false;

            veterinariaContext.Entry(duenoAEditar).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EliminarDueno(int? id)
        {
            var duenoEncontrado = veterinariaContext.TDueno.Find(id);
            bool esUnDuenoValido = duenoEncontrado != null;

            if ( !esUnDuenoValido ) return false;

            veterinariaContext.TDueno.Remove(duenoEncontrado);
            veterinariaContext.SaveChanges();
            return true;
        }

        public void DisposeDueno()
        {
            veterinariaContext.Dispose();
        }
    }
}
