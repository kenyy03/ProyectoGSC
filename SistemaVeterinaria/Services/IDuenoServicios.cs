using System.Collections.Generic;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Services
{
    public interface IDuenoServicios
    {
        List<tbDUENO> ObtenerDuenos();
        
        tbDUENO ObtenerDuenoPorID(int? id);

        bool CrearDueno(tbDUENO nuevoDueno);

        bool EditarDueno(tbDUENO duenoAEditar);

        bool EliminarDueno(int? id);

        void DisposeDueno();
    }
}
