namespace InterfaceSplittingFacility
{
    using System;
    using Castle.DynamicProxy;

    public sealed class InterfaceSplittingBottomInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
