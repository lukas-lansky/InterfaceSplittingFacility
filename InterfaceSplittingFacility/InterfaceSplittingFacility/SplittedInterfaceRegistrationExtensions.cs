using System.Linq;
using Castle.MicroKernel.Registration;

namespace InterfaceSplittingFacility
{
    public static class SplittedInterfaceRegistrationExtensions
    {
        public static ComponentRegistration<T> ImplementedAsSplittedInterface<T>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            var interfaces = typeof(T).GetInterfaces();

            var openInterceptorType = typeof(InterfaceSplittingInterceptor<>);
            var closedInterceptorTypes = interfaces.Select(t => openInterceptorType.MakeGenericType(t)).ToArray();

            return componentRegistration.Interceptors(closedInterceptorTypes);
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>),
                typeof(InterfaceSplittingInterceptor<Impl3>));
        }
    }
}
