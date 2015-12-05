#pragma warning disable SA1402
#pragma warning disable SA1649

namespace InterfaceSplittingFacility.IntegrationTest.FailingExplicitDeclaration
{
    using System;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public interface IBig
    {
        bool SmallProperty1 { get; set; }

        int SmallMethod1();

        int SmallMethod2();

        int SmallMethod3();

        int SmallMethod4();
    }

    public interface ISmall1
    {
        bool SmallProperty1 { get; set; }
    }

    public interface ISmall2
    {
        int SmallMethod2();

        int SmallMethod3();
    }

    public interface ISmall3
    {
        int SmallMethod4();
    }

    [TestClass]
    public class BasicExplicitDeclaration
    {
        [TestMethod]
        public void AssertIt()
        {
            var container = new WindsorContainer().AddFacility<InterfaceSplittingFacility>();

            container.Register(
                Component.For<ISmall1>().ImplementedBy<DefaultSmall1>().LifestyleTransient(),
                Component.For<ISmall2>().ImplementedBy<DefaultSmall2>().LifestyleTransient(),
                Component.For<ISmall3>().ImplementedBy<DefaultSmall3>().LifestyleTransient(),
                Component.For<IBig>().ImplementedAsSplittedInterfaceBy<IBig, ISmall1, ISmall2, ISmall3>()
                );

            var instance = container.Resolve<IBig>();
            instance.SmallProperty1 = true;

            Assert.AreEqual(instance.SmallProperty1, true);
            Assert.AreEqual(instance.SmallMethod2(), 2);
            Assert.AreEqual(instance.SmallMethod3(), 3);
            Assert.AreEqual(instance.SmallMethod4(), 4);

            try
            {
                instance.SmallMethod1();
            }
            catch (NotImplementedException)
            {
                return;
            }

            Assert.Fail();
        }
    }

    public class DefaultSmall1 : ISmall1
    {
        public bool SmallProperty1 { get; set; }

        public int SmallMethod1()
        {
            return 1;
        }
    }

    public class DefaultSmall2 : ISmall2
    {
        public int SmallMethod2()
        {
            return 2;
        }

        public int SmallMethod3()
        {
            return 3;
        }
    }

    public class DefaultSmall3 : ISmall3
    {
        public int SmallMethod4()
        {
            return 4;
        }
    }
}
