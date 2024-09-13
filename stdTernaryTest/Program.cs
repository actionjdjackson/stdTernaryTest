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

            //Below is a variety of tests for the stdTernary library. Uncomment whatever interests you. Many were used in debugging.

            //BalTryte fromstring = (BalTryte)"+-++0+0-0";
            //BalTryte fromtrits = new BalTryte(fromstring.Value);
            //fromstring.TryteChars = "+-++0+0-0".ToCharArray();
            //string tostring = (string)new BalTryte(5370);
            //Console.WriteLine(fromstring.ToString());
            //Console.WriteLine(fromtrits.ToString());
            //Console.WriteLine(tostring);

            //BalFloat bal = 1.3340057668999e-10;     //some rounding error depending on whether we round to the nearest 10th or 11th digit (ceiling or floor in precision calculation)
            //var newbal = -bal;                      //checking the negative
            //var finalbal = new BalFloat(newbal.Value);  //when we convert back from ternary it's off on the 11th digit by one, other times it's right on
            //Console.WriteLine(bal.ToString() + "\n" + newbal.ToString() + "\n" + finalbal.ToString());
            //Console.WriteLine(bal.Value[0] + " " + bal.Value[1] + " " + bal.Value[2] + " " + bal.Value[3] + " " + bal.Value[4]);
            //Console.WriteLine(newbal.Value[0] + " " + newbal.Value[1] + " " + newbal.Value[2] + " " + newbal.Value[3] + " " + newbal.Value[4]);
            //Console.WriteLine(finalbal.Value[0] + " " + finalbal.Value[1] + " " + finalbal.Value[2] + " " + finalbal.Value[3] + " " + finalbal.Value[4]);


            //BalInt balInt1 = 120423422228;
            //var newbalint = balInt1 << 9;
            //var finalbalint = new BalInt(newbalint.Value);
            //Console.WriteLine(balInt1.ToString() + "\n" + newbalint.ToString() + "\n" + finalbalint.ToString());
            //Console.WriteLine(balInt1.Value[0] + " " + balInt1.Value[1] + " " + balInt1.Value[2] + " " + balInt1.Value[3] + " " + balInt1.Value[4]);
            //Console.WriteLine(newbalint.Value[0] + " " + newbalint.Value[1] + " " + newbalint.Value[2] + " " + newbalint.Value[3] + " " + newbalint.Value[4]);
            //Console.WriteLine(finalbalint.Value[0] + " " + finalbalint.Value[1] + " " + finalbalint.Value[2] + " " + finalbalint.Value[3] + " " + finalbalint.Value[4]);

            //balInt1 = 3;
            //newbalint = 5;

            //Console.WriteLine(balInt1.ToString() + "\n" + newbalint.ToString());


            //Console.WriteLine(BalFloat.N_TRITS_TOTAL);
            //Console.WriteLine(BalFloat.N_TRITS_EXPONENT);
            //Console.WriteLine(BalFloat.N_TRITS_SIGNIFICAND);
            //var exampleFloat = new BalFloat(128);
            //var exampleIncrement = TernaryMath.TritIncrement(exampleFloat); //increments by one trit
            //Console.WriteLine(exampleFloat);    //should be 128
            //Console.WriteLine(exampleIncrement);    //should be 128 + smallest value possible in significand

            //BalFloat startFloat = 0.333333333333;   //can initialize a BalFloat with a double
            //double adouble = startFloat;    //can directly assign a BalFloat to a double
            //startFloat = 0.0f;   //can directly assign a double or float number to a BalFloat

            //BalTryte whateverelse = 9800;
            //BalTryte anotherone = (BalTryte)"+++++++++";    //explicit casting of a string to a BalTryte
            //string yetanotherone = (string)whateverelse;    //explicit casting of a BalType to a string (which only gives the char string of +/-/0, no decimal)
            //Console.WriteLine(yetanotherone);

            //Console.WriteLine(whateverelse);
            //whateverelse.InvertSelf();      //inversion of self
            //Console.WriteLine(whateverelse.ToString()); //ToString() gives the char string of +/-/0 of the BalTryte as well as the decimal equivalent

            //Console.WriteLine(anotherone);  //can pass a BalTryte directly to WriteLine and will give both the char string and decimal
            //Console.WriteLine(anotherone.Invert()); //inversion is also outputted the same way to WriteLine

            //var startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //Console.WriteLine(startFloat.ToString());
            //for (int i = 0; i < 100; i++)
            //{
            //    startFloat = TernaryMath.TritIncrement(startFloat); //trit increment operation 10,000 times
            //    Console.WriteLine(startFloat.ToString());
            //}
            //var endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //Console.WriteLine("\nTernary Trit Increment took " + (endTime - startTime) + " ms\n");

            //var startDouble = 0.0;
            //Console.WriteLine(startDouble);
            //startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //for (int i = 0; i < 100; i++)
            //{
            //    startDouble = Math.BitIncrement(startDouble);   //bit increment operation 10,000 times
            //    Console.WriteLine(startDouble.ToString());
            //}
            //endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //Console.WriteLine("\nBinary Bit Increment took " + (endTime - startTime) + " ms\n");

            //var exampleTryte = new BalTryte(5);  //can use var keyword with an explicit new BalTryte 
            //var exampleTryte2 = new BalTryte(20);
            //var exampleAdd = exampleTryte + exampleTryte2;
            //Console.WriteLine(exampleTryte);
            //Console.WriteLine(exampleTryte2);
            //Console.WriteLine(exampleAdd);  //should be 25

            //var examplesh = new BalTryte(5);
            //var exampleShift = examplesh << 2;  //should be 45 (5 * 3 * 3), notice var is picking up on the fact that we're working with a BalTryte
            //Console.WriteLine(examplesh);
            //Console.WriteLine(exampleShift);

            //BalFloat exampleBalFloat = 3.14159;
            //BalFloat exampleBalFloat2 = 2.71828;
            //BalFloat exampleBalFloat3 = 100.0;
            //Console.WriteLine(exampleBalFloat.ToString());
            //Console.WriteLine(exampleBalFloat2.ToString());
            //Console.WriteLine(exampleBalFloat3.ToString());
            //var exampleFloatAdd = exampleBalFloat + exampleBalFloat2 + exampleBalFloat3;    //adding checking
            //var exampleFloatSub = exampleBalFloat - exampleBalFloat2 - exampleBalFloat3;    //subtract checking
            //var exampleFloatMult = exampleBalFloat * exampleBalFloat2 * exampleBalFloat3;   //multiply checking
            //var exampleFloatDiv = exampleBalFloat / exampleBalFloat2 / exampleBalFloat3;    //divide checking
            //var exampleFloatPow = TernaryMath.Pow(exampleBalFloat2, exampleBalFloat);          //power checking
            //Console.WriteLine(exampleFloatAdd.ToString());
            //Console.WriteLine(exampleFloatSub.ToString());
            //Console.WriteLine(exampleFloatMult.ToString());
            //Console.WriteLine(exampleFloatDiv.ToString());
            //Console.WriteLine(exampleFloatPow.ToString());
            //if (exampleBalFloat2 < exampleBalFloat)    //this comparison is done in Ternary, checking the exponent first, then the significand, to see which is bigger
            //{
            //    Console.WriteLine("2.71828 is less than 3.14159");
            //}
            //// this tests for consistency when converting back and forth between doubles and ternary
            //(BalTrit[] trits, var remainder) = BalFloat.ConvertDoubleToBalancedTritsWithRemainder(0.125, BalFloat.N_TRITS_SIGNIFICAND);
            //double doub = BalFloat.ConvertBalancedTritsToDouble(trits);
            //Console.WriteLine(doub + " with a remainder of " + remainder);
            //(BalTrit[] trits2, var remainder2) = BalFloat.ConvertDoubleToBalancedTritsWithRemainder(doub, BalFloat.N_TRITS_SIGNIFICAND);
            //double doub2 = BalFloat.ConvertBalancedTritsToDouble(trits2);
            //Console.WriteLine(doub2 + " with a remainder of " + remainder2);

            //var r = new Random();

            //startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //for (int i = 0; i < 10000; i++)
            //{
            //    var d = r.NextDouble();
            //    var d2 = r.NextDouble();
            //    var prod = d * d2;
            //    if (prod < 0.1)
            //    {
            //        Console.Write(".");
            //    }
            //}
            //endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //Console.WriteLine("\n doubles multiplication with a comparison check took " + (endTime - startTime) + " ms\n");

            //startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //for (int i = 0; i < 10000; i++)
            //{
            //    var example = new BalFloat(r.NextDouble());
            //    var example2 = new BalFloat(r.NextDouble());
            //    var prod = example * example2;
            //    if (prod < 0.1)
            //    {
            //        Console.Write(".");
            //    }
            //}
            //endTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            //Console.WriteLine("\n balfloats multiplication with a comparison check took " + (endTime - startTime) + " ms\n");

            //BalFloat balFloat = 1.2e-300;   //testing a very small value, smaller than Epsilon for the BalFloat - should come out zero
            //Console.WriteLine(balFloat.ToString());

            //BalFloat balFloat1 = 1.2e300;   //testing a very big value, bigger than the MaxValue for the BaFloat - should come out at infinity
            //Console.WriteLine(balFloat1.ToString());

            //BalFloat balFloat2 = -1.2e300;  //testing a very big negative value, less than the MinValue for the BalFloat - should come out at -infinity
            //Console.WriteLine(balFloat2.ToString());

            //Console.WriteLine(TernaryMath.Tan(TernaryMath.PI / 2)); //testing a NaN value (tangent of pi/2)
            //Console.WriteLine(Math.Tan(Math.PI / 2));

            //Console.WriteLine(TernaryMath.ILogT(9.526));

            //BalInt balInt = 18530201888;
            //BalInt balInt2 = 762559748498;
            //BalInt sum = balInt + balInt2;
            //Console.WriteLine(sum.ToString());

        }
    }

    [MemoryDiagnoser]
    public class Benchmarks
    {
        int nIterations = 10000;

        [Benchmark]
        public void RandomAssignmentToBalIntAndTritShift()
        {
            var r = new Random();
            for (int i = 0; i < nIterations; i++)
            {
                BalInt balInt = r.Next();
                BalInt balInt1 = balInt << 16;
            }
        }

        [Benchmark]
        public void RandomAssignmentToIntAndBitShift()
        {
            var r = new Random();
            for (int i = 0; i < nIterations; i++)
            {
                int binInt = r.Next();
                int binInt1 = binInt << 16;
            }
        }

    }

}
