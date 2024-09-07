using System;
using System.Collections.Generic;

namespace stdTernary
{
    public static class TernaryMath
    {
        public static BalFloat Pow(BalFloat balFloat1, BalFloat balFloat2)
        {
            return new BalFloat(Math.Pow(balFloat1.DoubleValue, balFloat2.DoubleValue));
        }

        public static BalFloat Sqrt(BalFloat balFloat)
        {
            return new BalFloat(Math.Sqrt(balFloat.DoubleValue));
        }

        public static BalFloat Sin(BalFloat balFloat)
        {
            return new BalFloat(Math.Sin(balFloat.DoubleValue));
        }

        public static BalFloat Cos(BalFloat balFloat)
        {
            return new BalFloat(Math.Cos(balFloat.DoubleValue));
        }

        public static BalFloat Tan(BalFloat balFloat)
        {
            return new BalFloat(Math.Tan(balFloat.DoubleValue));
        }

        public static BalFloat Sinh(BalFloat balFloat)
        {
            return new BalFloat(Math.Sinh(balFloat.DoubleValue));
        }

        public static BalFloat Cosh(BalFloat balFloat)
        {
            return new BalFloat(Math.Cosh(balFloat.DoubleValue));
        }

        public static BalFloat Tanh(BalFloat balFloat)
        {
            return new BalFloat(Math.Tanh(balFloat.DoubleValue));
        }

        public static BalFloat Asin(BalFloat balFloat)
        {
            return new BalFloat(Math.Sin(balFloat.DoubleValue));
        }

        public static BalFloat Acos(BalFloat balFloat)
        {
            return new BalFloat(Math.Cos(balFloat.DoubleValue));
        }

        public static BalFloat Atan(BalFloat balFloat)
        {
            return new BalFloat(Math.Tan(balFloat.DoubleValue));
        }

        public static BalFloat Asinh(BalFloat balFloat)
        {
            return new BalFloat(Math.Sinh(balFloat.DoubleValue));
        }

        public static BalFloat Acosh(BalFloat balFloat)
        {
            return new BalFloat(Math.Cosh(balFloat.DoubleValue));
        }

        public static BalFloat Atanh(BalFloat balFloat)
        {
            return new BalFloat(Math.Atanh(balFloat.DoubleValue));
        }

        public static BalFloat Log(BalFloat balFloat)
        {
            return new BalFloat(Math.Log(balFloat.DoubleValue));
        }

        public static BalFloat Log10(BalFloat balFloat)
        {
            return new BalFloat(Math.Log10(balFloat.DoubleValue));
        }

        public static BalFloat Log2(BalFloat balFloat)
        {
            return new BalFloat(Math.Log2(balFloat.DoubleValue));
        }

        public static BalFloat Log3(BalFloat balFloat)
        {
            return new BalFloat(Math.Log(balFloat.DoubleValue) / Math.Log(3));
        }

        public static BalFloat Atan2(BalFloat balFloat1, BalFloat balFloat2)
        {
            return new BalFloat(Math.Atan2(balFloat1.DoubleValue, balFloat2.DoubleValue));
        }

        public static BalFloat Abs(BalFloat balFloat)
        {
            return new BalFloat(Math.Abs(balFloat.DoubleValue));
        }

        public static BalFloat Cbrt(BalFloat balFloat)
        {
            return new BalFloat(Math.Cbrt(balFloat.DoubleValue));
        }

        //public static BalFloat TritIncrement(BalFloat balFloat)
        //{
        //    //balFloat.Value
        //}


    }

    // BALANCED TERNARY TRIT WITH SBYTE AS DATA TYPE FOR -1 , 1, AND 0 VALUES, ALSO WITH TRIT CHARACTER -, +, 0

    public class BalTrit
    {
        private sbyte trit;
        private char tritChar;

        public BalTrit()
        {
            Value = 0;
        }

        public BalTrit(sbyte value)
        {
            Value = value;
        }

        public BalTrit(char tritChar)
        {
            TritChar = tritChar;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return tritChar.ToString() + " or " + trit;
        }

        public sbyte Value { get => trit; set => SetValue(value); }
        public char TritChar { get => tritChar; set => SetValue(value); }

        public void SetValue(sbyte value)
        {
            if (value < 0)
            {
                trit = -1;
                TritChar = '-';
            }
            else if (value > 0)
            {
                trit = 1;
                TritChar = '+';
            }
            else
            {
                trit = 0;
                TritChar = '0';
            }
        }

        public void SetValue(char charValue)
        {
            if (charValue == '0')
            {
                tritChar = charValue;
                trit = 0;
            }
            else if (charValue == '+')
            {
                tritChar = charValue;
                trit = 1;
            }
            else if (charValue == '-')
            {
                tritChar = charValue;
                trit = -1;
            }
            else
            {
                throw new ArgumentException("SetValue not given a valid ternary character. Should be 0, +, or -.", "charValue");
            }
        }

        public static BalTrit operator &(BalTrit trit1, BalTrit trit2) => trit1.AND(trit2);
        public static BalTrit operator |(BalTrit trit1, BalTrit trit2) => trit1.OR(trit2);
        public static BalTrit operator ~(BalTrit trit) => trit.NEG();
        public static BalTrit operator *(BalTrit trit1, BalTrit trit2) => trit1.MULT(trit2);
        public static BalTrit operator +(BalTrit trit1, BalTrit trit2) => trit1.SUM(trit2);
        public static bool operator ==(BalTrit trit1, BalTrit trit2) => trit1.Value == trit2.Value;
        public static bool operator !=(BalTrit trit1, BalTrit trit2) => trit1.Value != trit2.Value;
        public static bool operator >(BalTrit trit1, BalTrit trit2) => trit1.Value > trit2.Value;
        public static bool operator <(BalTrit trit1, BalTrit trit2) => trit1.Value < trit2.Value;
        public static bool operator >=(BalTrit trit1, BalTrit trit2) => trit1.Value >= trit2.Value;
        public static bool operator <=(BalTrit trit1, BalTrit trit2) => trit1.Value <= trit2.Value;

        public BalTrit NEG()
        {
            return new BalTrit((sbyte)(trit * -1));
        }

        public BalTrit SUM(BalTrit btrit)
        {
            if (this.trit == btrit.Value)
            {
                return this.NEG();
            }
            else if (this.trit == -btrit.Value)
            {
                return new BalTrit(0);
            }
            else if (this.trit == 0)
            {
                return new BalTrit(btrit.Value);
            }
            else if (btrit.Value == 0)
            {
                return new BalTrit(this.trit);
            }
            else
            {
                throw new Exception("Unknown state of trits in SUM operation.");
            }
        }

        public BalTrit CONS(BalTrit btrit)
        {
            if (this.trit == btrit.Value)
            {
                return new BalTrit(this.trit);
            }
            else
            {
                return new BalTrit(0);
            }
        }

        public BalTrit XNOR(BalTrit btrit)
        {
            return new BalTrit((sbyte)(this.trit * btrit.Value));
        }

        public BalTrit MULT(BalTrit btrit)
        {
            return this.XNOR(btrit);
        }

        public BalTrit MIN(BalTrit btrit)
        {
            if (this.trit == -1 || btrit.Value == -1)
            {
                return new BalTrit(-1);
            }
            else if (this.trit == 0 || btrit.Value == 0)
            {
                return new BalTrit(0);
            }
            else
            {
                return new BalTrit(1);
            }
        }

        public BalTrit AND(BalTrit btrit)
        {
            return this.MIN(btrit);
        }

        public BalTrit MAX(BalTrit btrit)
        {
            if (this.trit == 1 || btrit.Value == 1)
            {
                return new BalTrit(1);
            }
            if (this.trit == 0 || btrit.Value == 0)
            {
                return new BalTrit(0);
            }
            else
            {
                return new BalTrit(-1);
            }
        }

        public BalTrit OR(BalTrit btrit)
        {
            return this.MAX(btrit);
        }

        public BalTrit EQUAL(BalTrit btrit)
        {
            if (trit == btrit.Value)
            {
                return new BalTrit(1);
            }
            else
            {
                return new BalTrit(-1);
            }
        }

        public BalTrit NOTEQUAL(BalTrit btrit)
        {
            if (trit != btrit.Value)
            {
                return new BalTrit(1);
            }
            else
            {
                return new BalTrit(-1);
            }
        }

        public override bool Equals(object obj)
        {
            return obj is BalTrit trit &&
                   this.trit == trit.trit &&
                   tritChar == trit.tritChar;
        }
    }


    // NINE TRIT TRYTE

    public class BalTryte9 : BalTryte
    {
        public static new byte N_TRITS_PER_TRYTE = 9;

        public BalTryte9(BalTrit[] value) : base(value)
        {
        }

        public BalTryte9(short shortValue) : base(shortValue)
        {
        }

        public BalTryte9(char[] tryteChars) : base(tryteChars)
        {
        }
    }

    // SIX TRIT TRYTE

    public class BalTryte6 : BalTryte
    {
        public static new byte N_TRITS_PER_TRYTE = 6;

        public BalTryte6(BalTrit[] value) : base(value)
        {
        }

        public BalTryte6(short shortValue) : base(shortValue)
        {
        }

        public BalTryte6(char[] tryteChars) : base(tryteChars)
        {
        }
    }



    // BALANCED TERNARY GENERIC TRYTE


    public class BalTryte
    {
        public static byte N_TRITS_PER_TRYTE = 9;
        public static short MAX_POSITIVE_INTEGER = (short)((Math.Pow(3, N_TRITS_PER_TRYTE) - 1) / 2);
        public static short MAX_NEGATIVE_INTEGER = (short)-MAX_POSITIVE_INTEGER;
        private BalTrit[] tryte = new BalTrit[N_TRITS_PER_TRYTE];
        private char[] tryteChars = new char[N_TRITS_PER_TRYTE];
        private short shortValue;

        public BalTryte(BalTrit[] value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value), "Null BalTrit[] value passed to BalTryte Constructor");
        }

        public BalTryte(short shortValue)
        {
            ShortValue = shortValue;
        }

        public BalTryte(char[] tryteChars)
        {
            TryteChars = tryteChars;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return new string(tryteChars) + " or " + shortValue;
        }

        public BalTrit[] Value { get => tryte; set => SetValue(value); }
        public char[] TryteChars { get => tryteChars; set => SetValue(value); }
        public short ShortValue { get => shortValue; set => SetValue(value); }

        public static BalTryte operator &(BalTryte tryte1, BalTryte tryte2) => tryte1.AND(tryte2);
        public static BalTryte operator |(BalTryte tryte1, BalTryte tryte2) => tryte1.OR(tryte2);
        public static BalTryte operator ~(BalTryte tryte) => tryte.Invert();
        public static bool operator ==(BalTryte tryte1, BalTryte tryte2) => tryte1.shortValue == tryte2.shortValue;
        public static bool operator !=(BalTryte tryte1, BalTryte tryte2) => tryte1.shortValue != tryte2.shortValue;
        public static bool operator >(BalTryte tryte1, BalTryte tryte2) => tryte1.shortValue > tryte2.shortValue;
        public static bool operator <(BalTryte tryte1, BalTryte tryte2) => tryte1.shortValue < tryte2.shortValue;
        public static bool operator >=(BalTryte tryte1, BalTryte tryte2) => tryte1.shortValue >= tryte2.shortValue;
        public static bool operator <=(BalTryte tryte1, BalTryte tryte2) => tryte1.shortValue <= tryte2.shortValue;
        public static BalTryte operator +(BalTryte tryte1, BalTryte tryte2) => tryte1.SUM(tryte2);
        public static BalTryte operator *(BalTryte tryte1, BalTryte tryte2) => tryte1.MULT(tryte2);
        public static BalTryte operator -(BalTryte tryte1, BalTryte tryte2) => tryte1.SUB(tryte2);
        public static BalTryte operator /(BalTryte tryte1, BalTryte tryte2) => tryte1.DIV(tryte2);
        public static BalTryte operator %(BalTryte tryte1, BalTryte tryte2) => tryte1.MOD(tryte2);
        public static BalTryte operator <<(BalTryte tryte1, int nTrits) => tryte1.SHIFTLEFT(nTrits);
        public static BalTryte operator >>(BalTryte tryte1, int nTrits) => tryte1.SHIFTRIGHT(nTrits);
        public static BalTryte operator ++(BalTryte tryte) => new BalTryte((short)(tryte.shortValue + 1));
        public static BalTryte operator --(BalTryte tryte) => new BalTryte((short)(tryte.shortValue - 1));
        public static BalTryte operator +(BalTryte tryte) => new BalTryte(Math.Abs(tryte.shortValue));
        public static BalTryte operator -(BalTryte tryte) => new BalTryte((short)-Math.Abs(tryte.shortValue));



        public BalTryte SHIFTLEFT(int nTrits)
        {
            if (nTrits < N_TRITS_PER_TRYTE)
            {
                var temp = new BalTrit[N_TRITS_PER_TRYTE];
                Array.Copy(this.tryte, nTrits, temp, 0, N_TRITS_PER_TRYTE - nTrits);
                for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
                {
                    if (((object)temp[i]) == null)
                    {
                        temp[i] = new BalTrit(0);
                    }
                }
                return new BalTryte(temp);
            }
            else
            {
                throw new ArgumentException("Number of trits to shift left is too large for a tryte of " + N_TRITS_PER_TRYTE + " trits", "nTrits");
            }
        }

        public BalTryte SHIFTRIGHT(int nTrits)
        {
            if (nTrits < N_TRITS_PER_TRYTE)
            {
                var temp = new BalTrit[N_TRITS_PER_TRYTE];
                Array.Copy(this.tryte, 0, temp, nTrits, N_TRITS_PER_TRYTE - nTrits);
                for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
                {
                    if (((object)temp[i]) == null)
                    {
                        temp[i] = new BalTrit(0);
                    }
                }
                return new BalTryte(temp);
            }
            else
            {
                throw new ArgumentException("Number of trits to shift right is too large for a tryte of " + N_TRITS_PER_TRYTE + " trits", "nTrits");
            }
        }

        public BalTryte MOD(BalTryte btryte)
        {
            if (btryte.shortValue == 0)
            {
                throw new DivideByZeroException("Attempt to divide by zero in BalTryte modulus operation");
            }
            else
            {
                return new BalTryte((short)(this.shortValue % btryte.shortValue));
            }
        }

        public BalTryte DIV(BalTryte btryte)
        {
            if (btryte.shortValue == 0)
            {
                throw new DivideByZeroException("Attempt to divide by zero in BalTryte division operation");
            }
            else
            {
                return new BalTryte((short)(this.shortValue / btryte.shortValue));
            }
        }

        public BalTryte SUB(BalTryte btryte)
        {
            int temp = this.shortValue - btryte.shortValue;
            if (temp > MAX_POSITIVE_INTEGER || temp < MAX_NEGATIVE_INTEGER)
            {
                throw new OverflowException("Integer subtraction resulted in an overflow - result too big for a tryte with " + N_TRITS_PER_TRYTE + " trits");
            }
            else
            {
                return new BalTryte((short)temp);
            }
        }

        public BalTryte MULT(BalTryte btryte)
        {
            int temp = this.shortValue * btryte.shortValue;
            if (temp > MAX_POSITIVE_INTEGER || temp < MAX_NEGATIVE_INTEGER)
            {
                throw new OverflowException("Integer multiplication resulted in an overflow - result too big for a tryte with " + N_TRITS_PER_TRYTE + " trits");
            }
            else
            {
                return new BalTryte((short)temp);
            }
        }

        public BalTryte SUM(BalTryte btryte)
        {
            int temp = this.shortValue + btryte.shortValue;
            if (temp > MAX_POSITIVE_INTEGER || temp < MAX_NEGATIVE_INTEGER)
            {
                throw new OverflowException("Integer addition resulted in an overflow - result too big for a tryte with " + N_TRITS_PER_TRYTE + " trits");
            }
            else
            {
                return new BalTryte((short)temp);
            }
        }

        public BalTryte AND(BalTryte btryte)
        {
            var newTryte = new BalTryte(0);
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                newTryte.tryte[i] = this.tryte[i] & btryte.tryte[i];
            }
            return newTryte;
        }

        public BalTryte OR(BalTryte btryte)
        {
            var newTryte = new BalTryte(0);
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                newTryte.tryte[i] = this.tryte[i] | btryte.tryte[i];
            }
            return newTryte;
        }

        public static BalTrit TCOMPARISON(BalTryte tryte1, BalTryte tryte2)
        {
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                if (tryte1.Value[i] > tryte2.Value[i])
                {
                    return new BalTrit(1);
                }
                else if (tryte1.Value[i] < tryte2.Value[i])
                {
                    return new BalTrit(-1);
                }
            }
            return new BalTrit(0);
        }

        public void SetValue(BalTrit[] value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                tryte = value;
                var workTrits = value;
                Array.Reverse(workTrits);
                short sum = 0;
                byte exponent = 0;
                foreach (var trit in workTrits)
                {
                    sum += (short)(trit.Value * Math.Pow(3, exponent));
                    tryteChars[exponent] = trit.TritChar;
                    exponent++;
                }
                Array.Reverse(tryteChars);
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The trit array passed to BalTryte was not the expected size", "value");
            }
        }

        public void SetValue(char[] value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                tryteChars = value;
                var workChars = value;
                Array.Reverse(workChars);
                short sum = 0;
                short exponent = 0;
                foreach (var trit in workChars)
                {
                    if (trit == '+')
                    {
                        sum += (short)Math.Pow(3, exponent);
                        tryte[exponent] = new BalTrit(1);
                    }
                    else if (trit == '-')
                    {
                        sum -= (short)Math.Pow(3, exponent);
                        tryte[exponent] = new BalTrit(-1);
                    }
                    else if (trit == '0')
                    {
                        tryte[exponent] = new BalTrit(0);
                    }
                    exponent++;
                }
                Array.Reverse(tryte);
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The character array passed to BalTryte was not the expected size", "value");
            }
        }

        public void SetValue(short value)
        {
            shortValue = value;
            short workValue = Math.Abs(value);
            if (workValue <= MAX_POSITIVE_INTEGER)
            {
                byte i = 0;
                while (workValue != 0)
                {
                    switch (workValue % 3)
                    {
                        case 0:
                            tryte[i] = new BalTrit(0);
                            tryteChars[i] = '0';
                            break;
                        case 1:
                            tryte[i] = new BalTrit(1);
                            tryteChars[i] = '+';
                            break;
                        case 2:
                            tryte[i] = new BalTrit(-1);
                            tryteChars[i] = '-';
                            break;
                    }
                    workValue = (short)((workValue + 1) / 3);
                    i++;
                }
                for (int j = i; j < N_TRITS_PER_TRYTE; j++)
                {
                    tryte[j] = new BalTrit(0);
                    tryteChars[j] = '0';
                }
                if (value < 0)
                {
                    InvertSelf();
                }
                Array.Reverse(tryte);
                Array.Reverse(tryteChars);
            }
            else
            {
                throw new ArgumentException("The short value passed to SetValue in BalTryte was too large to fit in a " + N_TRITS_PER_TRYTE + " trit tryte", "value");
            }
        }

        public BalTryte Invert()
        {
            var newTryte = new BalTryte(0);
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                newTryte.Value[i].Value = (sbyte)(tryte[i].Value * -1);
            }
            newTryte.SetValue(newTryte.tryte);
            return newTryte;
        }

        public void InvertSelf()
        {
            foreach (var trit in tryte)
            {
                trit.Value = (sbyte)(trit.Value * -1);
            }
            SetValue(tryte);
        }

        public override bool Equals(object obj)
        {
            return obj is BalTryte tryte &&
                   EqualityComparer<BalTrit[]>.Default.Equals(this.tryte, tryte.tryte) &&
                   EqualityComparer<char[]>.Default.Equals(tryteChars, tryte.tryteChars) &&
                   shortValue == tryte.shortValue;
        }
    }


    public class BalFloat
    {
        public static byte N_TRITS_TOTAL = 27;
        public static byte N_TRITS_SIGNIFICAND = (byte)Math.Ceiling((double)(N_TRITS_TOTAL * 2 / 3));
        public static byte N_TRITS_EXPONENT = (byte)Math.Floor((double)(N_TRITS_TOTAL / 3));
        public static byte N_DIGITS_PRECISION = (byte)Math.Abs(Math.Ceiling(Math.Log10(1 / Math.Pow(3, N_TRITS_SIGNIFICAND))));

        private BalTrit[] exponent = new BalTrit[N_TRITS_EXPONENT];
        private BalTrit[] significand = new BalTrit[N_TRITS_SIGNIFICAND];
        private BalTrit[] wholeBalFloat = new BalTrit[N_TRITS_TOTAL];
        private double doubleValue;
        private char[] floatChars = new char[N_TRITS_TOTAL];

        public double DoubleValue { get => doubleValue; set => SetValue(value); }
        public BalTrit[] Value { get => wholeBalFloat; set => SetValue(value); }

        public static bool operator ==(BalFloat float1, BalFloat float2) => EqualityComparer<BalTrit[]>.Default.Equals(float1.Value, float2.Value);
        public static bool operator !=(BalFloat float1, BalFloat float2) => !EqualityComparer<BalTrit[]>.Default.Equals(float1.Value, float2.Value);
        public static bool operator >(BalFloat float1, BalFloat float2) => float1.GREATERTHAN(float2);
        public static bool operator <(BalFloat float1, BalFloat float2) => float1.LESSTHAN(float2);
        public static bool operator >=(BalFloat float1, BalFloat float2) => float1.GREATEROREQUAL(float2);
        public static bool operator <=(BalFloat float1, BalFloat float2) => float1.LESSOREQUAL(float2);

        public static BalFloat operator +(BalFloat float1, BalFloat float2) => new BalFloat(float1.doubleValue + float2.doubleValue);
        public static BalFloat operator -(BalFloat float1, BalFloat float2) => new BalFloat(float1.doubleValue - float2.doubleValue);
        public static BalFloat operator *(BalFloat float1, BalFloat float2) => new BalFloat(float1.doubleValue * float2.doubleValue);
        public static BalFloat operator /(BalFloat float1, BalFloat float2) => new BalFloat(float1.doubleValue / float2.doubleValue);
        public static BalFloat operator %(BalFloat float1, BalFloat float2) => new BalFloat(float1.doubleValue % float2.doubleValue);
        public static BalFloat operator ++(BalFloat float1) => new BalFloat(float1.doubleValue += 1);
        public static BalFloat operator --(BalFloat float1) => new BalFloat(float1.doubleValue -= 1);
        public static BalFloat operator +(BalFloat float1) => new BalFloat(Math.Abs(float1.doubleValue));
        public static BalFloat operator -(BalFloat float1) => new BalFloat(-Math.Abs(float1.doubleValue));


        public bool LESSOREQUAL(BalFloat balFloat)
        {
            for (int i = 0; i < N_TRITS_EXPONENT; i++)
            {
                if (exponent[i] < balFloat.exponent[i])
                {
                    return true;
                }
                else if (exponent[i] > balFloat.exponent[i])
                {
                    return false;
                }
            }
            for (int i = 0; i < N_TRITS_SIGNIFICAND; i++)
            {
                if (significand[i] < balFloat.significand[i])
                {
                    return true;
                }
                else if (significand[i] > balFloat.significand[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool GREATEROREQUAL(BalFloat balFloat)
        {
            for (int i = 0; i < N_TRITS_EXPONENT; i++)
            {
                if (exponent[i] > balFloat.exponent[i])
                {
                    return true;
                }
                else if (exponent[i] < balFloat.exponent[i])
                {
                    return false;
                }
            }
            for (int i = 0; i < N_TRITS_SIGNIFICAND; i++)
            {
                if (significand[i] > balFloat.significand[i])
                {
                    return true;
                }
                else if (significand[i] < balFloat.significand[i])
                {
                    return false;
                }
            }
            return true;
        }

        public bool LESSTHAN(BalFloat balFloat)
        {
            for (int i = 0; i < N_TRITS_EXPONENT; i++)
            {
                if (exponent[i] < balFloat.exponent[i])
                {
                    return true;
                }
                else if (exponent[i] > balFloat.exponent[i])
                {
                    return false;
                }
            }
            for (int i = 0; i < N_TRITS_SIGNIFICAND; i++)
            {
                if (significand[i] < balFloat.significand[i])
                {
                    return true;
                }
                else if (significand[i] > balFloat.significand[i])
                {
                    return false;
                }
            }
            return false;
        }

        public bool GREATERTHAN(BalFloat balFloat)
        {
            for (int i = 0; i < N_TRITS_EXPONENT; i++)
            {
                if (exponent[i] > balFloat.exponent[i])
                {
                    return true;
                }
                else if (exponent[i] < balFloat.exponent[i])
                {
                    return false;
                }
            }
            for (int i = 0; i < N_TRITS_SIGNIFICAND; i++)
            {
                if (significand[i] > balFloat.significand[i])
                {
                    return true;
                }
                else if (significand[i] < balFloat.significand[i])
                {
                    return false;
                }
            }
            return false;
        }

        public BalFloat(double doubleValue)
        {
            DoubleValue = doubleValue;
        }

        public BalFloat(BalTrit[] wholeBalFloat)
        {
            Value = wholeBalFloat;
        }

        public override string ToString()
        {
            return new string(floatChars) + " or " + doubleValue.ToString();
        }

        public void SetValue(double value)
        {
            this.doubleValue = value;
            int exponentValueBase3 = (int)Math.Ceiling((Math.Log(Math.Abs(value)) - Math.Log(0.5)) / Math.Log(3.0));
            double doubleSignificand = value / Math.Pow(3.0, exponentValueBase3);
            double remainder = 0.0;
            (this.significand, remainder) = ConvertDoubleToBalancedTritsWithRemainder(doubleSignificand, N_TRITS_SIGNIFICAND);
            this.exponent = ConvertIntegerToBalancedTrits(exponentValueBase3, N_TRITS_EXPONENT);
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
            {
                this.wholeBalFloat[i] = exponent[i];
                this.floatChars[i] = exponent[i].TritChar;
            }
            for (int i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)
            {
                this.wholeBalFloat[i] = significand[i - N_TRITS_EXPONENT];
                this.floatChars[i] = significand[i - N_TRITS_EXPONENT].TritChar;
            }
        }

        public void SetValue(BalTrit[] value)
        {
            this.wholeBalFloat = value;
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
            {
                exponent[i] = value[i];
                floatChars[i] = value[i].TritChar;
            }
            for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)
            {
                significand[i - N_TRITS_EXPONENT] = value[i];
                floatChars[i] = value[i].TritChar;
            }
            int exponentValue = (int)Math.Pow(3, ConvertBalancedTritsToInteger(exponent));
            //if (exponentValue == MAX_EXPONENT_VALUE)
            //{
            //    doubleValue = double.PositiveInfinity
            //}
            double significandValue = ConvertBalancedTritsToDouble(significand);
            doubleValue = significandValue * exponentValue;
        }

        public void SetValue(char[] value)
        {
            this.floatChars = value;
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
            {
                if (value[i] == '+')
                {
                    exponent[i] = new BalTrit(1);
                }
                else if (value[i] == '-')
                {
                    exponent[i] = new BalTrit(-1);
                }
                else if (value[i] == '0')
                {
                    exponent[i] = new BalTrit(0);
                }
                else
                {
                    throw new ArgumentException("Invalid character in ternary char array passed to SetValue.", "value");
                }
            }
            for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)
            {
                if (value[i] == '+')
                {
                    significand[i - N_TRITS_EXPONENT] = new BalTrit(1);
                }
                else if (value[i] == '-')
                {
                    significand[i - N_TRITS_EXPONENT] = new BalTrit(-1);
                }
                else if (value[i] == '0')
                {
                    significand[i - N_TRITS_EXPONENT] = new BalTrit(0);
                }
                else
                {
                    throw new ArgumentException("Invalid character in ternary char array passed to SetValue.", "value");
                }
            }
        }

        public static BalTrit[] ConvertIntegerToBalancedTrits(int integerValue, byte nTrits)
        {
            BalTrit[] balTrits = new BalTrit[nTrits];
            int workValue = Math.Abs(integerValue);
            if (workValue <= (int)((Math.Pow(3, nTrits) - 1) / 2))
            {
                byte i = 0;
                while (workValue != 0)
                {
                    switch (workValue % 3)
                    {
                        case 0:
                            balTrits[i] = new BalTrit(0);
                            break;
                        case 1:
                            balTrits[i] = new BalTrit(1);
                            break;
                        case 2:
                            balTrits[i] = new BalTrit(-1);
                            break;
                    }
                    workValue = (workValue + 1) / 3;
                    i++;
                }
                for (int j = i; j < nTrits; j++)
                {
                    balTrits[j] = new BalTrit(0);
                }
                if (integerValue < 0)
                {
                    foreach (var trit in balTrits)
                    {
                        trit.Value = (sbyte)(trit.Value * -1);
                    }
                }
                Array.Reverse(balTrits);
                return balTrits;
            }
            else
            {
                throw new ArgumentException("The integer value passed to ConvertIntegerToBalancedTrits is too large for the number of trits passed.", "integerValue");
            }
        }

        public static int ConvertBalancedTritsToInteger(BalTrit[] balTrits)
        {
            var workTrits = balTrits;
            Array.Reverse(workTrits);
            int sum = 0;
            short exponent = 0;
            foreach (var trit in workTrits)
            {
                sum += (int)(trit.Value * Math.Pow(3, exponent));
                exponent++;
            }
            return sum;
        }

        public static double ConvertBalancedTritsToDouble(BalTrit[] balTrits)
        {
            double sum = 0;
            int exponent = -1;
            foreach (var trit in balTrits)
            {
                sum += trit.Value * Math.Pow(3, exponent);
                exponent--;
            }
            return sum;
        }

        public static (BalTrit[], double) ConvertDoubleToBalancedTritsWithRemainder(double doubleValue, int nTrits)
        {
            var balTrits = new BalTrit[nTrits];
            var sum = doubleValue;
            for (int exponent = 1; exponent <= nTrits; exponent++)
            {
                var magnitudeDiffNeg = Math.Abs(sum + Math.Pow(3.0, -exponent));
                var magnitudeDiffPos = Math.Abs(sum - Math.Pow(3.0, -exponent));
                if ((magnitudeDiffNeg < magnitudeDiffPos) && magnitudeDiffNeg < Math.Abs(sum))
                {
                    sum -= -1 * Math.Pow(3.0, -exponent);
                    balTrits[exponent - 1] = new BalTrit(-1);
                }
                else if ((magnitudeDiffPos < magnitudeDiffNeg) && magnitudeDiffPos < Math.Abs(sum))
                {
                    sum -= 1 * Math.Pow(3.0, -exponent);
                    balTrits[exponent - 1] = new BalTrit(1);
                }
                else
                {
                    balTrits[exponent - 1] = new BalTrit(0);
                }
            }
            return (balTrits, sum);
        }

        public override bool Equals(object obj)
        {
            return obj is BalFloat @float &&
                   EqualityComparer<BalTrit[]>.Default.Equals(wholeBalFloat, @float.wholeBalFloat);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(wholeBalFloat);
        }
    }


}
