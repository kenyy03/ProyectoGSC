using System.Collections.Generic;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Services
{
    public interface IFamiliaServicios
    {
        List<tbfamilia> ObtenerFamilias();

        tbfamilia ObtenerFamiliaPorId(int? id);

        bool CrearFamilia(tbfamilia nuevaFamilia);

        bool EditarFamilia(tbfamilia familiaAEditar);

        bool EliminarFamilia(int? id);

        void DisposeFamilia();
    }
}
