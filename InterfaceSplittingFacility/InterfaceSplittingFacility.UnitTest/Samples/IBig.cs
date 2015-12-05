namespace InterfaceSplittingFacility.UnitTest.Samples
{
    public interface IBig
    {
        bool Property1 { get; set; }

        int Method1();

        void Method2();

        int Method2(int argument);

        void Method3();
    }
}
