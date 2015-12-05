namespace InterfaceSplittingFacility
{
    using Castle.MicroKernel.Facilities;
    using Castle.MicroKernel.Registration;

    public class InterfaceSplittingFacility : AbstractFacility
    {
        protected override void Init()
        {
            this.Kernel.Register(
                Component
                    .For(typeof(InterfaceSplittingInterceptor<>))
                    .LifestyleTransient(),
                Component
                    .For(typeof(InterfaceSplittingBottomInterceptor))
                    .LifestyleTransient());
        }
    }
}
