namespace InterfaceSplittingFacility
{
    using System.Linq;
    using Castle.MicroKernel.Registration;
    using System;
    public static class SplittedInterfaceRegistrationExtensions
    {
        public static ComponentRegistration<T> ImplementedAsSplittedInterface<T>(this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            var interfaces = typeof(T).GetInterfaces();

            return componentRegistration.Interceptors(WrapTypesIntoInterceptor(interfaces));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>),
                typeof(InterfaceSplittingInterceptor<Impl3>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3, Impl4>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>),
                typeof(InterfaceSplittingInterceptor<Impl3>),
                typeof(InterfaceSplittingInterceptor<Impl4>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3, Impl4, Impl5>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>),
                typeof(InterfaceSplittingInterceptor<Impl3>),
                typeof(InterfaceSplittingInterceptor<Impl4>),
                typeof(InterfaceSplittingInterceptor<Impl5>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3, Impl4, Impl5, Impl6>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>),
                typeof(InterfaceSplittingInterceptor<Impl3>),
                typeof(InterfaceSplittingInterceptor<Impl4>),
                typeof(InterfaceSplittingInterceptor<Impl5>),
                typeof(InterfaceSplittingInterceptor<Impl6>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3, Impl4, Impl5, Impl6, Impl7>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>),
                typeof(InterfaceSplittingInterceptor<Impl3>),
                typeof(InterfaceSplittingInterceptor<Impl4>),
                typeof(InterfaceSplittingInterceptor<Impl5>),
                typeof(InterfaceSplittingInterceptor<Impl6>),
                typeof(InterfaceSplittingInterceptor<Impl7>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T, Impl1, Impl2, Impl3, Impl4, Impl5, Impl6, Impl7, Impl8>(
            this ComponentRegistration<T> componentRegistration)
            where T : class
        {
            return componentRegistration.Interceptors(
                typeof(InterfaceSplittingInterceptor<Impl1>),
                typeof(InterfaceSplittingInterceptor<Impl2>),
                typeof(InterfaceSplittingInterceptor<Impl3>),
                typeof(InterfaceSplittingInterceptor<Impl4>),
                typeof(InterfaceSplittingInterceptor<Impl5>),
                typeof(InterfaceSplittingInterceptor<Impl6>),
                typeof(InterfaceSplittingInterceptor<Impl7>),
                typeof(InterfaceSplittingInterceptor<Impl8>));
        }

        public static ComponentRegistration<T> ImplementedAsSplittedInterfaceBy<T>(
            this ComponentRegistration<T> componentRegistration, params Type[] by)
            where T : class
        {
            return componentRegistration.Interceptors(WrapTypesIntoInterceptor(by));
        }

        private static Type[] WrapTypesIntoInterceptor(Type[] types)
        {
            var openInterceptorType = typeof(InterfaceSplittingInterceptor<>);
            var closedInterceptorTypes = types.Select(t => openInterceptorType.MakeGenericType(t)).ToArray();

            return closedInterceptorTypes;
        }
    }
}
