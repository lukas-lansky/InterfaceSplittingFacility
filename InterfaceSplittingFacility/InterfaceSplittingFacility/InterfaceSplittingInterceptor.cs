namespace InterfaceSplittingFacility
{
    using Castle.DynamicProxy;
    using System.Linq;

    public sealed class InterfaceSplittingInterceptor<T> : IInterceptor
    {
        private readonly T implementation;

        public InterfaceSplittingInterceptor(T implementation)
        {
            this.implementation = implementation;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;
            var methodArgumentTypes = invocation.Arguments.Select(a => a.GetType()).ToArray();

            var method = typeof(T).GetMethod(methodName, methodArgumentTypes);

            if (method == null)
            {
                invocation.Proceed();
            }
            else
            {
                invocation.ReturnValue = method.Invoke(this.implementation, invocation.Arguments);
            }
        }
    }
}
