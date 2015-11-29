using Castle.DynamicProxy;

namespace InterfaceSplittingFacility
{
    public class InterfaceSplittingInterceptor<T> : IInterceptor
    {
        protected readonly T Implementation;

        public InterfaceSplittingInterceptor(T implementation)
        {
            Implementation = implementation;
        }

        public void Intercept(IInvocation invocation)
        {
            var methodName = invocation.Method.Name;

            var method = typeof(T).GetMethod(methodName);

            if (method == null)
            {
                invocation.Proceed();
            }
            else
            {
                invocation.ReturnValue = method.Invoke(Implementation, invocation.Arguments);
            }
        }
    }
}
