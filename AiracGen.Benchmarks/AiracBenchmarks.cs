using BenchmarkDotNet.Attributes;

namespace AiracGen.Benchmarks
{
    [MemoryDiagnoser]
    public class Benchmarks
    {
        //[Benchmark]
        public void CreateAiracCloseToCurrentDate() => AiracGenerator.GenerateByIdent("2201");

        //[Benchmark]
        public void CreateAiracFarInTheFuture() => AiracGenerator.GenerateByIdent("8605");

        //[Benchmark]
        public void CreateAiracFarInThePast() => AiracGenerator.GenerateByIdent("0204");

        //[Benchmark]
        public void CreateCurrentAirac() => AiracGenerator.GenerateCurrent();

        [Benchmark]
        public void CreateManyAiracs() => AiracGenerator.GenerateBetweenYears(2010, 2090);
    }
}
