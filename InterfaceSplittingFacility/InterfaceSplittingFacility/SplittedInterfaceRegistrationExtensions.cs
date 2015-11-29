using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSplittingFacility
{
    public static class SplittedInterfaceRegistrationExtensions
    {
        public static ComponentRegistration<T> ImplementedAsSplittedInterface<T>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration;
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration;
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration;
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration;
        }
    }
}
