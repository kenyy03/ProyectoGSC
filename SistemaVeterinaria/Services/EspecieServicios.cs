using System.Linq;
using SistemaVeterinaria.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace SistemaVeterinaria.Services
{
    public class EspecieServicios : IEspecieServicios
    {
        public readonly VeterinariaEntities veterinariaContext;

        public EspecieServicios()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public IQueryable<tbespecie> ObtenerEspecies()
        {
            return veterinariaContext.TEspecie.Include(especie => especie.tbfamilia);
        }

        public tbespecie ObtenerEspeciePorID(int? id)
        {
            bool esUnIdValido = id != null;
            if(!esUnIdValido) return null;

            var especieEncontrada = veterinariaContext.TEspecie.Find(id);
            return especieEncontrada;
        }

        public SelectList ObtenerFamiliaDeEspecie()
        {
            var nombresFamilias = new SelectList(veterinariaContext.TFamilia, "cod_familia", "nombre");
            return nombresFamilias;
        }

        public SelectList ObtenerFamiliaDeEspecie(tbespecie especie)
        {
            var nombresFamilias = new SelectList(veterinariaContext.TFamilia, "cod_familia", "nombre", especie.cod_familia);
            return nombresFamilias;
        }

        public bool CrearEspecie(tbespecie nuevaEspecie)
        {
            bool esUnaEspecieValida = nuevaEspecie != null;
            if ( !esUnaEspecieValida ) return false;

            veterinariaContext.TEspecie.Add(nuevaEspecie);
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EditarEspecie(tbespecie especieAEditar)
        {
            bool esUnaEspecieValida = especieAEditar != null;
            if( !esUnaEspecieValida ) return false;

            veterinariaContext.Entry(especieAEditar).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EliminarEspecie(int? id)
        {
            var especieEncontrada = ObtenerEspeciePorID(id);
            bool esUnaEspecieValida = especieEncontrada != null;

            if ( !esUnaEspecieValida ) return false;

            veterinariaContext.TEspecie.Remove(especieEncontrada);
            veterinariaContext.SaveChanges();
            return true;
        }

        public void DisposeEspecie()
        {
            veterinariaContext.Dispose();
        }


    }
}