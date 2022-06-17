using System.Collections.Generic;
using System.Linq;
using SistemaVeterinaria.Models;
using System.Data.Entity;

namespace SistemaVeterinaria.Services
{
    public class FamiliaServicios : IFamiliaServicios
    {
        public readonly VeterinariaEntities veterinariaContext;

        public FamiliaServicios()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public List<tbfamilia> ObtenerFamilias()
        {
            return veterinariaContext.TFamilia.ToList();
        }

        public tbfamilia ObtenerFamiliaPorId(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return null;

            var familiaEncontrada = veterinariaContext.TFamilia.Find(id);

            bool esUnaFamiliaValida = familiaEncontrada != null;
            if ( !esUnaFamiliaValida ) return null;

            return familiaEncontrada;
        }

        public bool CrearFamilia(tbfamilia nuevaFamilia)
        {
            bool esUnaFamiliaValida = nuevaFamilia != null;

            if ( !esUnaFamiliaValida ) return false;

            veterinariaContext.TFamilia.Add(nuevaFamilia);
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EditarFamilia(tbfamilia familiaAEditar)
        {
            bool esUnaFamiliaValida = familiaAEditar != null;
            if ( !esUnaFamiliaValida ) return false;

            veterinariaContext.Entry(familiaAEditar).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EliminarFamilia(int? id)
        {
            var familiaEncontrada = veterinariaContext.TFamilia.Find(id);
            bool esUnaFamiliaValida = familiaEncontrada != null;

            if ( !esUnaFamiliaValida ) return false;

            veterinariaContext.TFamilia.Remove(familiaEncontrada);
            veterinariaContext.SaveChanges();
            return true;
        }

        public void DisposeFamilia()
        {
            veterinariaContext.Dispose();
        }
    }
}