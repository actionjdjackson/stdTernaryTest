﻿using System;
using stdTernary;

namespace stdTernaryTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var exampleFloat = new BalFloat(128);
            var exampleIncrement = TernaryMath.TritIncrement(exampleFloat); //increments by one trit
            Console.WriteLine(exampleFloat);    //should be 128
            Console.WriteLine(exampleIncrement);    //should be 128 + epsilon

            BalFloat startFloat = 0.333333333333;
            double adouble = startFloat;    //can directly assign a BalFloat to a double
            startFloat = 1.0;   //can directly assign a decimal number to a BalFloat
            int whatever = new BalTryte(5);
            BalTryte whateverelse = 9800;
            BalTryte anotherone = (BalTryte)"+++++++++";    //explicit casting of a string to a BalTryte
            string yetanotherone = (string)whateverelse;    //explicit casting of a BalType to a string (which only gives the char string of +/-/0, no decimal)
            Console.WriteLine(yetanotherone);
            Console.WriteLine(whateverelse);
            Console.WriteLine(anotherone);  //implicit casting causes WriteLine to write the decimal equivalent of a BalTryte
            Console.WriteLine(anotherone.Invert());
            whateverelse.InvertSelf();
            Console.WriteLine(whateverelse.ToString()); //ToString() gives the char string of +/-/0 of the BalTryte as well as the decimal equivalent

            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine(startFloat);
            for (int i = 0; i < 10000; i++)
            {
                startFloat = TernaryMath.TritIncrement(startFloat); //trit increment operation 10,000 times
            }
            var endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\nTernary Trit Increment took " + (endTime - startTime) + " ms\n");

            var startDouble = 0.0;
            Console.WriteLine(startDouble);
            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                startDouble = Math.BitIncrement(startDouble);   //bit increment operation 10,000 times
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\nBinary Bit Increment took " + (endTime - startTime) + " ms\n");

            var exampleTryte = new BalTryte(5);  //can use var keyword with an explicit new BalTryte 
            var exampleTryte2 = new BalTryte(20);
            var exampleAdd = exampleTryte + exampleTryte2;
            Console.WriteLine(exampleTryte);
            Console.WriteLine(exampleTryte2);
            Console.WriteLine(exampleAdd);  //should be 25

            var examplesh = new BalTryte(5);
            var exampleShift = examplesh << 2;  //should be 45 (5 * 3 * 3), notice var is picking up on the fact that we're working with a BalTryte
            Console.WriteLine(examplesh);
            Console.WriteLine(exampleShift);

            BalFloat exampleBalFloat = 3.14159;
            BalFloat exampleBalFloat2 = 2.71828;
            BalFloat exampleBalFloat3 = 100.0;
            Console.WriteLine(exampleBalFloat.ToString());
            Console.WriteLine(exampleBalFloat2.ToString());
            Console.WriteLine(exampleBalFloat3.ToString());
            var exampleFloatAdd = exampleBalFloat + exampleBalFloat2 + exampleBalFloat3;    //adding checking
            Console.WriteLine(exampleFloatAdd.ToString());
            if (exampleBalFloat2 < exampleBalFloat3)    //this comparison is done in Ternary, checking the exponent first, then the significand, to see which is bigger
            {
                Console.WriteLine("2.7 is less than 100");
            }

            var r = new Random();

            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                var d = r.NextDouble() * r.Next();
                var d2 = r.NextDouble() * r.Next();
                var prod = (d * d2);
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\n doubles multiplication took " + (endTime - startTime) + " ms\n");

            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                var example = new BalFloat(r.NextDouble() * r.Next());
                var example2 = new BalFloat(r.NextDouble() * r.Next());
                var prod = (example * example2);
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\n balfloats multiplication took " + (endTime - startTime) + " ms\n");

        }
    }
}
