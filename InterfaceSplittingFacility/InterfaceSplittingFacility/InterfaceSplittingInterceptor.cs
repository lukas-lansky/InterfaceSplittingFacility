using Castle.DynamicProxy;
using System;

namespace InterfaceSplittingFacility
{
    public class InterfaceSplittingInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            throw new NotImplementedException();
        }
    }
}
