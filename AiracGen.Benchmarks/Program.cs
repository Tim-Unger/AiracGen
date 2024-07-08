using BenchmarkDotNet.Running;

namespace AiracGen.Benchmarks
{
    internal class Program
    {
        static void Main(string[] _)
        {
            BenchmarkRunner.Run<Benchmarks>();
        }
    }
}
