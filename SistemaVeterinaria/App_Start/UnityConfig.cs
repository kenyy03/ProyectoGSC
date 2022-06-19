using System;
using SistemaVeterinaria.Services;
using Unity;
using System.Web.Mvc;
using Unity.AspNet.Mvc;

namespace SistemaVeterinaria
{
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container) {}

        public static void RegisterDependencies()
        {
            UnityContainer container = new UnityContainer();

            container.RegisterType<IDuenoServicios, DuenoServicios>();
            container.RegisterType<IEmpleadoServicios, EmpleadoServicios>();
            container.RegisterType<IEspecieServicios, EspecieServicios>();
            container.RegisterType<IFamiliaServicios, FamiliaServicios>();
            container.RegisterType<ICitaServicios, CitaServicios>();
            container.RegisterType<IPacienteServicios, PacienteServicios>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}