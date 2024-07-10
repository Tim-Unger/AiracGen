using BenchmarkDotNet.Running;

namespace AiracGen.Benchmarks
{
    internal class Program
    {
        static void Main()
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
