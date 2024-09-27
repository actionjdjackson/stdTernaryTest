using System;
using stdTernary;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Running;

namespace stdTernaryTest
{
    class Program
    {
        static void Main(string[] args)
        {

            //var summary = BenchmarkRunner.Run<Benchmarks>();

            FloatT a = -1.5;
            FloatT b = 3.5;
            var result = a + b;
            Console.WriteLine(result.ToString());

            //Tryte tryte = Tryte.MaxValue;
            //Console.WriteLine(tryte.ToString());

            //IntT intt = IntT.MaxValue;
            //Console.WriteLine(intt.ToString());

        }
    }


    /// <summary>
    /// Benchmarks Class for running tests on stdTernary.cs
    /// </summary>
    [MemoryDiagnoser]
    public class Benchmarks
    {
        int nIterations = 10;

        [Benchmark]
        public void RandomAssignmentToIntTAndTritShift()
        {
            var r = new Random();
            for (int i = 0; i < nIterations; i++)
            {
                IntT a = r.Next();
                IntT b = a << 18;
            }
        }

        [Benchmark]
        public void RandomAssignmentToIntAndBitShift()
        {
            var r = new Random();
            for (int i = 0; i < nIterations; i++)
            {
                int a = r.Next();
                int b = a << 18;
            }
        }

        [Benchmark]
        public void BinaryIntegerAdditionWithTernaryConversion()
        {
            var r = new Random();
            for (int i = 0; i < nIterations; i++)
            {
                IntT a = r.Next();
                IntT b = r.Next();
                var addition = a + b;
            }
        }

        [Benchmark]
        public void TernaryIntegerAdditionWithBinaryConversion()
        {
            var r = new Random();
            for (int i = 0; i < nIterations; i++)
            {
                IntT a = r.Next();
                IntT b = r.Next();
                var addition = a.ADD(b);
            }
        }
    }

}
