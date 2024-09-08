using System;
using stdTernary;

namespace stdTernaryTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var exampleFloat = new BalFloat(128);
            var exampleIncrement = TernaryMath.TritIncrement(exampleFloat);
            Console.WriteLine(exampleFloat);
            Console.WriteLine(exampleIncrement);

            BalFloat startFloat = new BalFloat(0.333333333333);
            double next = startFloat;
            startFloat = 1;
            int whatever = new BalTryte(5);
            BalTryte whateverelse = 8;
            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine(startFloat);
            for (int i = 0; i < 10000; i++)
            {
                startFloat = TernaryMath.TritIncrement(startFloat);
            }
            var endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\nTernary Trit Increment took " + (endTime - startTime) + " ms\n");

            var startDouble = 0.0;
            Console.WriteLine(startDouble);
            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                startDouble = Math.BitIncrement(startDouble);
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\nBinary Bit Increment took " + (endTime - startTime) + " ms\n");

            var exampleTryte = new BalTryte(5);
            var exampleTryte2 = new BalTryte(20);
            var exampleAdd = exampleTryte + exampleTryte2;
            Console.WriteLine(exampleTryte);
            Console.WriteLine(exampleTryte2);
            Console.WriteLine(exampleAdd);

            var examplesh = new BalTryte(5);
            var exampleShift = examplesh << 1;
            Console.WriteLine(examplesh);
            Console.WriteLine(exampleShift);

            var exampleBalFloat = new BalFloat(3.14159);
            var exampleBalFloat2 = new BalFloat(2.714956);
            var exampleBalFloat3 = new BalFloat(100.0);
            Console.WriteLine(exampleBalFloat);
            Console.WriteLine(exampleBalFloat2);
            Console.WriteLine(exampleBalFloat3);
            var exampleFloatAdd = exampleBalFloat + exampleBalFloat2 + exampleBalFloat3;
            Console.WriteLine(exampleFloatAdd);
            if (exampleBalFloat2 < exampleBalFloat3)
            {
                Console.WriteLine("2.7 is less than 100");
            }

            var r = new Random();

            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                var d = r.NextDouble() * r.Next();
                var d2 = r.NextDouble() * r.Next();
                var sum = (d * d2);
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\n doubles multiplication took " + (endTime - startTime) + " ms\n");

            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                var example = new BalFloat(r.NextDouble() * r.Next());
                var example2 = new BalFloat(r.NextDouble() * r.Next());
                var sum = (example * example2);
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\n balfloats multiplication took " + (endTime - startTime) + " ms\n");

        }
    }
}
