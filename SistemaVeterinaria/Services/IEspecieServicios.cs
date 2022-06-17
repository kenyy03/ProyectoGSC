using System.Linq;
using SistemaVeterinaria.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace SistemaVeterinaria.Services
{
    public interface IEspecieServicios
    {
        IQueryable<tbespecie> ObtenerEspecies();

        tbespecie ObtenerEspeciePorID(int? id);

        SelectList ObtenerFamiliaDeEspecie();

        SelectList ObtenerFamiliaDeEspecie(tbespecie especie);

        bool CrearEspecie(tbespecie nuevaEspecie);

        bool EditarEspecie(tbespecie especieAEditar);

        bool EliminarEspecie(int? id);

        void DisposeEspecie();
    }
}
