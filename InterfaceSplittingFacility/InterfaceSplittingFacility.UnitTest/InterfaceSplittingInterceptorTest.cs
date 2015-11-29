﻿namespace InterfaceSplittingFacility.UnitTest
{
    using Castle.DynamicProxy;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Rhino.Mocks;
    using Samples;

    [TestClass]
    public class InterfaceSplittingInterceptorTest
    {
        [TestMethod]
        public void InterceptorCallsSimpleMethodMatch()
        {
            var implementation = MockRepository.GenerateMock<ISmall1>();
            implementation.Stub(impl => impl.Method1()).Return(42);

            var invocation = MockRepository.GenerateMock<IInvocation>();
            invocation.Stub(inv => inv.Method).Return(typeof(IBig).GetMethod(nameof(IBig.Method1)));
            invocation.Stub(inv => inv.Arguments).Return(new object[] { });
            invocation.Stub(inv => inv.ReturnValue).PropertyBehavior();
            invocation.Expect(inv => inv.Proceed()).Repeat.Never();

            var interceptor = new InterfaceSplittingInterceptor<ISmall1>(implementation);
            interceptor.Intercept(invocation);

            Assert.AreEqual(invocation.ReturnValue, 42);
            invocation.VerifyAllExpectations();
        }

        [TestMethod]
        public void InterceptorPassSimpleMethodMismatch()
        {
            var implementation = MockRepository.GenerateMock<ISmall3>();

            var invocation = MockRepository.GenerateMock<IInvocation>();
            invocation.Stub(inv => inv.Method).Return(typeof(IBig).GetMethod(nameof(IBig.Method1)));
            invocation.Stub(inv => inv.ReturnValue).PropertyBehavior();
            invocation.Expect(inv => inv.Proceed());

            var interceptor = new InterfaceSplittingInterceptor<ISmall3>(implementation);
            interceptor.Intercept(invocation);

            Assert.AreEqual(invocation.ReturnValue, null);
            invocation.VerifyAllExpectations();
        }
    }
}
