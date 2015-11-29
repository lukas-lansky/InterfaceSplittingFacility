using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;

namespace InterfaceSplittingFacility
{
    public class InterfaceSplittingFacility : AbstractFacility
    {
        protected override void Init()
        {
            Kernel.Register(
                Component
                    .For<InterfaceSplittingInterceptor>()
                    .LifestyleTransient());
        }
    }
}
