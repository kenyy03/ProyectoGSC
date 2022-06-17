using System.Web.Mvc;
using System.Linq;
using SistemaVeterinaria.Models;

namespace SistemaVeterinaria.Services
{
    public interface IEmpleadoServicios
    {
        IQueryable<tbEmpleado> ObtenerEmpleados();

        tbEmpleado ObtenerEmpleadoPorID(int? id);

        SelectList ObtenerPuestosDeEmpleados();

        SelectList ObtenerPuestosDeEmpleados(tbEmpleado empleado);

        bool CrearEmpleado(tbEmpleado nuevoEmpleado);

        bool EditarEmpleado(tbEmpleado empleadoAEditar);

        bool EliminarEmpleado(int? id);

        void DisposeEmpleado();
    }
}
