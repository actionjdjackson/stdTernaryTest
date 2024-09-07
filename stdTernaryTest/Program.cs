using System;
using stdTernary;

namespace stdTernaryTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var exampleTryte = new BalTryte(5);
            var exampleTryte2 = new BalTryte(20);
            var exampleAdd = exampleTryte + exampleTryte2;
            Console.WriteLine(exampleTryte);
            Console.WriteLine(exampleTryte2);
            Console.WriteLine(exampleAdd);

            var example = new BalTryte(5);
            var exampleShift = example << 1;
            Console.WriteLine(example);
            Console.WriteLine(exampleShift);

            var exampleBalFloat = new BalFloat(3.14159);
            var exampleBalFloat2 = new BalFloat(2.714956);
            var exampleBalFloat3 = new BalFloat(100.0);
            Console.WriteLine(exampleBalFloat);
            Console.WriteLine(exampleBalFloat2);
            Console.WriteLine(exampleBalFloat3);
            var exampleFloatAdd = exampleBalFloat + exampleBalFloat2 + exampleBalFloat3;
            Console.WriteLine(exampleFloatAdd);

        }
    }
}
