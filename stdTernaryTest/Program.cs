﻿using System;
using stdTernary;

namespace stdTernaryTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(BalFloat.N_TRITS_TOTAL);
            Console.WriteLine(BalFloat.N_TRITS_EXPONENT);
            Console.WriteLine(BalFloat.N_TRITS_SIGNIFICAND);
            var exampleFloat = new BalFloat(128);
            var exampleIncrement = TernaryMath.TritIncrement(exampleFloat); //increments by one trit
            Console.WriteLine(exampleFloat);    //should be 128
            Console.WriteLine(exampleIncrement);    //should be 128 + smallest value possible in significand

            BalFloat startFloat = 0.333333333333;   //can initialize a BalFloat with a double
            double adouble = startFloat;    //can directly assign a BalFloat to a double
            startFloat = 0.0f;   //can directly assign a double or float number to a BalFloat

            BalTryte whateverelse = 9800;
            BalTryte anotherone = (BalTryte)"+++++++++";    //explicit casting of a string to a BalTryte
            string yetanotherone = (string)whateverelse;    //explicit casting of a BalType to a string (which only gives the char string of +/-/0, no decimal)
            Console.WriteLine(yetanotherone);

            Console.WriteLine(whateverelse);
            whateverelse.InvertSelf();      //inversion of self
            Console.WriteLine(whateverelse.ToString()); //ToString() gives the char string of +/-/0 of the BalTryte as well as the decimal equivalent

            Console.WriteLine(anotherone);  //implicit casting causes WriteLine to write the decimal equivalent of a BalTryte
            Console.WriteLine(anotherone.Invert()); //inversion is also outputted as a decimal equivalent

            var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine(startFloat);
            for (int i = 0; i < 10000; i++)
            {
                startFloat = TernaryMath.TritIncrement(startFloat); //trit increment operation 10,000 times
                //Console.WriteLine(startFloat.ToString());
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
            var exampleFloatSub = exampleBalFloat - exampleBalFloat2 - exampleBalFloat3;    //subtract checking
            var exampleFloatMult = exampleBalFloat * exampleBalFloat2 * exampleBalFloat3;   //multiply checking
            var exampleFloatDiv = exampleBalFloat / exampleBalFloat2 / exampleBalFloat3;    //divide checking
            var exampleFloatPow = TernaryMath.Pow(exampleBalFloat2, exampleBalFloat);          //power checking
            Console.WriteLine(exampleFloatAdd.ToString());
            Console.WriteLine(exampleFloatSub.ToString());
            Console.WriteLine(exampleFloatMult.ToString());
            Console.WriteLine(exampleFloatDiv.ToString());
            Console.WriteLine(exampleFloatPow.ToString());
            if (exampleBalFloat2 < exampleBalFloat)    //this comparison is done in Ternary, checking the exponent first, then the significand, to see which is bigger
            {
                Console.WriteLine("2.71828 is less than 3.14159");
            }
            (BalTrit[] trits, var remainder) = BalFloat.ConvertDoubleToBalancedTritsWithRemainder(0.125, BalFloat.N_TRITS_SIGNIFICAND);
            double doub = BalFloat.ConvertBalancedTritsToDouble(trits);
            Console.WriteLine(doub);
            (BalTrit[] trits2, var remainder2) = BalFloat.ConvertDoubleToBalancedTritsWithRemainder(doub, BalFloat.N_TRITS_SIGNIFICAND);
            double doub2 = BalFloat.ConvertBalancedTritsToDouble(trits2);
            Console.WriteLine(doub2);

            var r = new Random();

            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                var d = r.NextDouble();
                var d2 = r.NextDouble();
                var prod = (d * d2);
                if (prod < 0.1)
                {
                    //
                }
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\n doubles multiplication took " + (endTime - startTime) + " ms\n");

            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            for (int i = 0; i < 10000; i++)
            {
                var example = new BalFloat(r.NextDouble());
                var example2 = new BalFloat(r.NextDouble());
                var prod = (example * example2);
                if (prod < 0.1)
                {
                    //
                }
            }
            endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            Console.WriteLine("\n balfloats multiplication took " + (endTime - startTime) + " ms\n");

            BalInt balInt = 18530201888;
            BalInt balInt2 = 762559748498;
            BalInt sum = balInt + balInt2;
            Console.WriteLine(sum.ToString());

        }
    }
}
