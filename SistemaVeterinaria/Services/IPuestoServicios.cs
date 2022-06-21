using System;
using System.Collections.Generic;
using SistemaVeterinaria.Models;
using System.Linq;

namespace SistemaVeterinaria.Services
{
    public interface IPuestoServicios
    {
        List<tbPuesto> ObtenerPuestos();

        tbPuesto ObtenerPuestoPorID(int? id);

        bool CrearPuesto(tbPuesto nuevoPuesto);

        bool EditarPuesto(tbPuesto puestoAEditar);

        bool EliminarPuesto(int? id);

        void DisposePuesto();
    }
}
