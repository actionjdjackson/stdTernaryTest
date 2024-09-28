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

            
            FloatT a = 50;
            FloatT b = 20;
            var result = a * b;
            FloatT shouldEqual = 1000;
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(result.ToString());
            Console.WriteLine(shouldEqual.ToString());

            var digits = result.ExpectedNDigitsOfPrecision();
            Console.WriteLine(digits.ToString());

            a = (FloatT)"00000++-+000000000000000";
            b = (FloatT)"00000+-+0000000000000000";
            result = a * b;
            shouldEqual = (FloatT)"00000+-+++00000000000000";
            Console.WriteLine(a.ToString());
            Console.WriteLine(b.ToString());
            Console.WriteLine(result.ToString());
            Console.WriteLine(shouldEqual.ToString());


            digits = result.ExpectedNDigitsOfPrecision();
            Console.WriteLine(digits.ToString());

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
