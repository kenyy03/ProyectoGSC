using System.Collections.Generic;
using System.Linq;
using SistemaVeterinaria.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace SistemaVeterinaria.Services
{
    public class EmpleadoServicios : IEmpleadoServicios
    {
        public readonly VeterinariaEntities veterinariaContext;

        public EmpleadoServicios()
        {
            veterinariaContext = new VeterinariaEntities();
        }

        public IQueryable<tbEmpleado> ObtenerEmpleados()
        {
            return veterinariaContext.TEmpleado.Include(empleado => empleado.tbPuesto);
        }

        public tbEmpleado ObtenerEmpleadoPorID(int? id)
        {
            bool esUnIdValido = id != null;
            if ( !esUnIdValido ) return null;

            var empleadoEncontrado = veterinariaContext.TEmpleado.Find(id);
            return empleadoEncontrado;
        }

        public SelectList ObtenerPuestosDeEmpleados()
        {
            var nombresPuestos = new SelectList(veterinariaContext.TPuestos, "cod_puesto", "nombre_puesto");
            return nombresPuestos;
        }

        public SelectList ObtenerPuestosDeEmpleados(tbEmpleado empleado)
        {
            var nombresPuestos = new SelectList(veterinariaContext.TPuestos, "cod_puesto", "nombre_puesto", empleado.cod_puesto);
            return nombresPuestos;
        }

        public bool CrearEmpleado(tbEmpleado nuevoEmpleado)
        {
            bool esUnEmpleadoValido = nuevoEmpleado != null;
            if( !esUnEmpleadoValido ) return false;

            veterinariaContext.TEmpleado.Add(nuevoEmpleado);
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EditarEmpleado(tbEmpleado empleadoAEditar)
        {
            bool esUnEmpleadoValido = empleadoAEditar != null;
            if ( !esUnEmpleadoValido ) return false;

            veterinariaContext.Entry(empleadoAEditar).State = EntityState.Modified;
            veterinariaContext.SaveChanges();
            return true;
        }

        public bool EliminarEmpleado(int? id)
        {
            var empleadoEncontrado = ObtenerEmpleadoPorID(id);
            bool esUnEmpleadoValido = empleadoEncontrado != null;

            if ( !esUnEmpleadoValido ) return false;

            veterinariaContext.TEmpleado.Remove(empleadoEncontrado);
            veterinariaContext.SaveChanges();
            return true;
        }

        public void DisposeEmpleado()
        {
            veterinariaContext.Dispose();
        }


    }
}