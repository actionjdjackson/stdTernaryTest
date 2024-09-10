using System;
using System.Collections.Generic;
using System.Linq;

namespace stdTernary
{

    // BalFloat versions of most Math functions, including a log3 and trit increment/decrement
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

        public static BalFloat TritIncrement(BalFloat balFloat)
        {
            sbyte carry = 1;
            BalTrit[] balTrits = new BalTrit[BalFloat.N_TRITS_TOTAL];
            for (int i = BalFloat.N_TRITS_TOTAL - 1; i >= 0; i--)
            {
                sbyte n = (sbyte)(balFloat.Value[i].Value + carry);
                if (n == 0)
                {
                    balTrits[i] = new BalTrit(0);
                    carry = 0;
                }
                else if (n == 1)
                {
                    balTrits[i] = new BalTrit(1);
                    carry = 0;
                }
                else if (n == 2)
                {
                    balTrits[i] = new BalTrit(-1);
                    carry = 1;
                }
                else if (n == -1)
                {
                    balTrits[i] = new BalTrit(-1);
                    carry = 0;
                }
                else if (n == -2)
                {
                    balTrits[i] = new BalTrit(1);
                    carry = -1;
                }
            }
            return new BalFloat(balTrits);
        }

        public static BalFloat TritDecrement(BalFloat balFloat)
        {
            sbyte carry = -1;
            BalTrit[] balTrits = new BalTrit[BalFloat.N_TRITS_TOTAL];
            for (int i = BalFloat.N_TRITS_TOTAL - 1; i >= 0; i--)
            {
                sbyte n = (sbyte)(balFloat.Value[i].Value + carry);
                if (n == 0)
                {
                    balTrits[i] = new BalTrit(0);
                    carry = 0;
                }
                else if (n == 1)
                {
                    balTrits[i] = new BalTrit(1);
                    carry = 0;
                }
                else if (n == 2)
                {
                    balTrits[i] = new BalTrit(-1);
                    carry = 1;
                }
                else if (n == -1)
                {
                    balTrits[i] = new BalTrit(-1);
                    carry = 0;
                }
                else if (n == -2)
                {
                    balTrits[i] = new BalTrit(1);
                    carry = -1;
                }
            }
            return new BalFloat(balTrits);
        }


    }


    /// <summary>
    /// Balanced Ternary Trit with sbyte as datatype for -1 , 1, and 0 values, also with a char for trit characters  -, +, 0
    /// Considered using two bools or a bool? (three-valued bool with null as a possible value for zero).
    /// On Stack Overflow the answer seems to be that a bool is no faster than a byte, as the binary computer works in
    /// multiples of bytes, not on individual bits. Sticking with an sbyte for now.
    /// </summary>
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
            return tritChar.ToString() + " which equals " + trit;
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
                throw new ArgumentException("BalTrit SetValue not given a valid ternary character. Should be 0, +, or -.", "charValue");
            }
        }

        public static BalTrit operator &(BalTrit trit1, BalTrit trit2) => trit1.AND(trit2);
        public static BalTrit operator |(BalTrit trit1, BalTrit trit2) => trit1.OR(trit2);
        public static BalTrit operator ~(BalTrit trit) => trit.NEG();
        public static BalTrit operator !(BalTrit trit) => trit.NEG();
        public static BalTrit operator *(BalTrit trit1, BalTrit trit2) => trit1.MULT(trit2);
        public static BalTrit operator +(BalTrit trit1, BalTrit trit2) => trit1.SUM(trit2);
        public static bool operator ==(BalTrit trit1, BalTrit trit2) => trit1.Value == trit2.Value;
        public static bool operator !=(BalTrit trit1, BalTrit trit2) => trit1.Value != trit2.Value;
        public static bool operator >(BalTrit trit1, BalTrit trit2) => trit1.Value > trit2.Value;
        public static bool operator <(BalTrit trit1, BalTrit trit2) => trit1.Value < trit2.Value;
        public static bool operator >=(BalTrit trit1, BalTrit trit2) => trit1.Value >= trit2.Value;
        public static bool operator <=(BalTrit trit1, BalTrit trit2) => trit1.Value <= trit2.Value;
        public static bool operator true(BalTrit trit) => trit.Value == 1;
        public static bool operator false(BalTrit trit) => trit.Value == -1 || trit.Value == 0;

        public static explicit operator bool(BalTrit trit) => trit.trit == 1;
        public static explicit operator BalTrit(bool b) => b ? new BalTrit(1) : new BalTrit(-1);
        public static implicit operator sbyte(BalTrit trit) => trit.trit;
        public static implicit operator BalTrit(sbyte sb) => (sb <= 1 && sb >= -1) ? new BalTrit(sb) : throw new ArithmeticException("Tried to assign a value too big for BalTrit - keep it to -1, 0, or 1");
        public static implicit operator int(BalTrit trit) => trit.trit;
        public static implicit operator BalTrit(int @int) => (@int <= 1 && @int >= -1) ? new BalTrit((sbyte)@int) : throw new ArithmeticException("Tried to assign a value too big for BalTrit -  keep it to -1, 0, or 1");

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
                throw new ArgumentException("Unknown state of trit in SUM operation.", "btrit");
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


    /// <summary>
    /// A customizable Balanced Ternary tryte data type/class with a range of 2 - 10 trits per tryte. Bytewise operators have been overridden
    /// for everything except ^ (XOR) - which is a specifically binary operation. I might use ^ for XNOR/MULTIPLY but not sure. There is a
    /// BTCOMPARISON method which is for the <=> spaceship operator - but C# doesn't allow custom operators.
    /// </summary>
    public class BalTryte
    {
        public static byte N_TRITS_PER_TRYTE = 9;   //can be from 2 - 10 trits
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
            return new string(tryteChars) + " which equals " + shortValue;
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
        public static BalTryte operator -(BalTryte tryte) => new BalTryte((short)-tryte.shortValue);
        public static implicit operator short(BalTryte tryte) => tryte.shortValue;
        public static implicit operator BalTryte(short shortValue) => (shortValue <= MAX_POSITIVE_INTEGER && shortValue >= MAX_NEGATIVE_INTEGER) ? new BalTryte(shortValue) : throw new ArithmeticException("Tried to assign to a tryte a short that has a magnitude too big for a tryte of " + N_TRITS_PER_TRYTE + " trits");
        public static implicit operator int(BalTryte tryte) => tryte.shortValue;
        public static implicit operator BalTryte(int intValue) => (intValue <= MAX_POSITIVE_INTEGER && intValue >= MAX_NEGATIVE_INTEGER) ? new BalTryte((short)intValue) : throw new ArithmeticException("Tried to assign to a tryte an int that has a magnitude too big for a tryte of " + N_TRITS_PER_TRYTE + " trits");
        public static explicit operator string(BalTryte tryte) => new string(tryte.tryteChars);
        public static explicit operator BalTryte(string str) => (str.Length == N_TRITS_PER_TRYTE) ? new BalTryte(str.ToCharArray()) : throw new ArithmeticException("Conversion from string to BalTryte unsuccessful because the string was the wrong length - should be " + N_TRITS_PER_TRYTE + " trits");

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
                throw new ArgumentOutOfRangeException("Number of trits to shift left is too large for a tryte of " + N_TRITS_PER_TRYTE + " trits", "nTrits");
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
                throw new ArgumentOutOfRangeException("Number of trits to shift right is too large for a tryte of " + N_TRITS_PER_TRYTE + " trits", "nTrits");
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

        public static BalTrit BTCOMPARISON(BalTryte tryte1, BalTryte tryte2)
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
                throw new ArgumentException("The trit array passed to BalTryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " trits in length", "value");
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
                throw new ArgumentException("The character array passed to BalTryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " chars in length", "value");
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
                throw new ArgumentOutOfRangeException("The short value passed to SetValue in BalTryte was too large to fit in a " + N_TRITS_PER_TRYTE + " trit tryte", "value");
            }
        }

        public BalTryte Invert()
        {
            BalTryte newTryte = 0;
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                newTryte.Value[i] = !tryte[i];
            }
            newTryte.SetValue(newTryte.tryte);
            return newTryte;
        }

        public void InvertSelf()
        {
            foreach (var trit in tryte)
            {
                trit.Value = !trit;
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

    /// <summary>
    /// The BalInt class is a modifiable general purpose Balanced Ternary integer, with an array of trits, chars, and a long for the values it holds.
    /// All the math is done in binary and converted to ternary. Trit-shifting is done in Ternary. Can be explicitly cast to a string of +, -, 0's
    /// </summary>
    public class BalInt
    {
        public static byte N_TRITS_PER_INT = 27;
        public static long MAX_POSITIVE_INTEGER = (long)(Math.Pow(3, N_TRITS_PER_INT) - 1) / 2;
        public static long MAX_NEGATIVE_INTEGER = -MAX_POSITIVE_INTEGER;

        private BalTrit[] balInt = new BalTrit[N_TRITS_PER_INT];
        private char[] integerChars = new char[N_TRITS_PER_INT];
        private long integerValue;

        public BalTrit[] Value { get => balInt; set => SetValue(value); }
        public char[] IntegerChars { get => integerChars; set => SetValue(value); }
        public long IntegerValue { get => integerValue; set => SetValue(value); }

        public static bool operator ==(BalInt int1, BalInt int2) => EqualityComparer<BalTrit[]>.Default.Equals(int1.Value, int2.Value);
        public static bool operator !=(BalInt int1, BalInt int2) => !EqualityComparer<BalTrit[]>.Default.Equals(int1.Value, int2.Value);
        public static bool operator >(BalInt int1, BalInt int2) => int1.integerValue > int2.integerValue;
        public static bool operator <(BalInt int1, BalInt int2) => int1.integerValue < int2.integerValue;
        public static bool operator >=(BalInt int1, BalInt int2) => int1.integerValue >= int2.integerValue;
        public static bool operator <=(BalInt int1, BalInt int2) => int1.integerValue <= int2.integerValue;
        public static BalInt operator +(BalInt int1, BalInt int2) => new BalInt(int1.integerValue + int2.integerValue);
        public static BalInt operator -(BalInt int1, BalInt int2) => new BalInt(int1.integerValue - int2.integerValue);
        public static BalInt operator *(BalInt int1, BalInt int2) => new BalInt(int1.integerValue * int2.integerValue);
        public static BalInt operator /(BalInt int1, BalInt int2) => new BalInt(int1.integerValue / int2.integerValue);
        public static BalInt operator %(BalInt int1, BalInt int2) => new BalInt(int1.integerValue % int2.integerValue);
        public static BalInt operator <<(BalInt @int, int nTrits) => @int.SHIFTLEFT(nTrits);
        public static BalInt operator >>(BalInt @int, int nTrits) => @int.SHIFTRIGHT(nTrits);
        public static BalInt operator ++(BalInt @int) => new BalInt(@int.integerValue + 1);
        public static BalInt operator --(BalInt @int) => new BalInt(@int.integerValue - 1);
        public static BalInt operator +(BalInt @int) => new BalInt(Math.Abs(@int.integerValue));
        public static BalInt operator -(BalInt @int) => new BalInt(-@int.integerValue);
        public static implicit operator long(BalInt @int) => @int.integerValue;
        public static implicit operator BalInt(long @int) => (@int <= MAX_POSITIVE_INTEGER && @int >= MAX_NEGATIVE_INTEGER) ? new BalInt(@int) : throw new ArithmeticException("Converting a long value to a BalInt failed because it was outside the range of the BalInt implementation");
        public static implicit operator int(BalInt @int) => (@int <= int.MaxValue && @int >= int.MinValue) ? (int)@int.integerValue : throw new ArithmeticException("Converting a BalInt to an int failed because the value was outside the range of the int max/min values");
        public static implicit operator BalInt(int @int) => (@int <= MAX_POSITIVE_INTEGER && @int >= MAX_NEGATIVE_INTEGER) ? new BalInt(@int) : throw new ArithmeticException("Converting an int value to a BalInt failed because it was outside the range of the BalInt implementation");
        public static implicit operator short(BalInt @int) => (@int <= short.MaxValue && @int >= short.MinValue) ? (short)@int.integerValue : throw new ArithmeticException("Converting a BalInt to a short failed because the value was outside the range of the short max/min values");
        public static implicit operator BalInt(short @int) => (@int <= MAX_POSITIVE_INTEGER && @int >= MAX_NEGATIVE_INTEGER) ? new BalInt(@int) : throw new ArithmeticException("Converting a short value to a BalInt failed because it was outside the range of the BalInt implementation");
        public static explicit operator string(BalInt @int) => new string(@int.integerChars);
        public static explicit operator BalInt(string str) => (str.Length == N_TRITS_PER_INT) ? new BalInt(str.ToCharArray()) : throw new ArithmeticException("Converting a string to a BalInt failed because it wasn't the expected length (" + N_TRITS_PER_INT + " trits)");
        public static explicit operator double(BalInt @int) => @int.integerValue;


        public BalInt(BalTrit[] balTrits)
        {
            Value = balTrits;
        }

        public BalInt(char[] balChars)
        {
            IntegerChars = balChars;
        }

        public BalInt(long integer)
        {
            IntegerValue = integer;
        }

        public override string ToString()
        {
            return new string(integerChars) + " which equals " + integerValue;
        }

        public override bool Equals(object obj)
        {
            return obj is BalInt @int &&
                   EqualityComparer<BalTrit[]>.Default.Equals(balInt, @int.balInt);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(balInt);
        }

        public void SetValue(BalTrit[] value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                balInt = value;
                integerValue = ConvertBalancedTritsToInteger(value);
                for (int i = 0; i < N_TRITS_PER_INT; i++)
                {
                    integerChars[i] = balInt[i].TritChar;
                }
            }
            else
            {
                throw new ArgumentException("BalTrit array passed to BalInt SetValue method was not the expected size - should be " + N_TRITS_PER_INT + " trits in length", "value");
            }
        }

        public void SetValue(long value)
        {
            integerValue = value;
            balInt = ConvertIntegerToBalancedTrits(value);
            for (int i = 0; i < N_TRITS_PER_INT; i++)
            {
                integerChars[i] = balInt[i].TritChar;
            }
        }

        public void SetValue(char[] value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                integerChars = value;
                for (int i = 0; i < N_TRITS_PER_INT; i++)
                {
                    if (value[i] == '+')
                    {
                        balInt[i] = new BalTrit(1);
                    }
                    else if (value[i] == '-')
                    {
                        balInt[i] = new BalTrit(-1);
                    }
                    else if (value[i] == '0')
                    {
                        balInt[i] = new BalTrit(0);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid character encountered in a balanced ternary char array. Please stick to +, -, 0's", "value");
                    }
                }
                integerValue = ConvertBalancedTritsToInteger(balInt);
            }
            else
            {
                throw new ArgumentException("Char array passed to BalInt SetValue method was not the expected size - should be " + N_TRITS_PER_INT + " chars in length", "value");
            }
        }

        public static int ConvertBalancedTritsToInteger(BalTrit[] balTrits)
        {
            var workTrits = balTrits;
            Array.Reverse(workTrits);   //easier to work with the array of trits reversed
            int sum = 0;
            short exponent = 0;
            foreach (var trit in workTrits)
            {
                sum += (int)(trit.Value * Math.Pow(3, exponent));   //exponent increases as the invisible index increases, and adds to the sum if the trit is -1 or 1
                exponent++;
            }
            return sum;
        }

        public static BalTrit[] ConvertIntegerToBalancedTrits(long intValue)
        {
            BalTrit[] balTrits = new BalTrit[N_TRITS_PER_INT];
            long workValue = Math.Abs(intValue);     //easier to work with a positive number...
            if (workValue <= MAX_POSITIVE_INTEGER)  //make sure the value passed in is within the nTrits passed maximum value
            {
                byte i = 0;
                while (workValue != 0)      //easier to start with index 0 - greater numbers on the right
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
                for (int j = i; j < N_TRITS_PER_INT; j++)
                {
                    balTrits[j] = new BalTrit(0);   //...add zeros to fill in to make the length match the nTrits passed in
                }
                if (intValue < 0)   //...and invert if it was negative
                {
                    foreach (var trit in balTrits)
                    {
                        trit.Value = !trit;
                    }
                }
                Array.Reverse(balTrits);    //...and reverse the trit order so greater numbers are on the left
                return balTrits;
            }
            else
            {
                throw new ArgumentException("The integer value passed to ConvertIntegerToBalancedTrits is too large for the number of trits passed.", "intValue");
            }
        }

        public static BalTrit BTCOMPARISON(BalInt int1, BalInt int2)
        {
            for (int i = 0; i < N_TRITS_PER_INT; i++)
            {
                if (int1.balInt[i] > int2.balInt[i])
                {
                    return new BalTrit(1);
                }
                else if (int1.balInt[i] < int2.balInt[i])
                {
                    return new BalTrit(-1);
                }
            }
            return new BalTrit(0);
        }

        public BalInt SHIFTLEFT(int nTrits)
        {
            if (nTrits < N_TRITS_PER_INT)
            {
                var temp = new BalTrit[N_TRITS_PER_INT];
                Array.Copy(this.balInt, nTrits, temp, 0, N_TRITS_PER_INT - nTrits);
                for (int i = 0; i < N_TRITS_PER_INT; i++)
                {
                    if (((object)temp[i]) == null)
                    {
                        temp[i] = new BalTrit(0);
                    }
                }
                return new BalInt(temp);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of trits to shift left is too large for a BalInt of " + N_TRITS_PER_INT + " trits", "nTrits");
            }
        }

        public BalInt SHIFTRIGHT(int nTrits)
        {
            if (nTrits < N_TRITS_PER_INT)
            {
                var temp = new BalTrit[N_TRITS_PER_INT];
                Array.Copy(this.balInt, 0, temp, nTrits, N_TRITS_PER_INT - nTrits);
                for (int i = 0; i < N_TRITS_PER_INT; i++)
                {
                    if (((object)temp[i]) == null)
                    {
                        temp[i] = new BalTrit(0);
                    }
                }
                return new BalInt(temp);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of trits to shift right is too large for a BalInt of " + N_TRITS_PER_INT + " trits", "nTrits");
            }
            
        }
    }


    /// <summary>
    /// The BalFloat class is a modifiable general purpose Balanced Ternary floating point number with trits, chars, and a double. Might get rid of the chars because
    /// it slows things down, but it's intended for interoperability with my Action Ternary Simulator project, which uses strings of +/-/0's
    /// </summary>
    public class BalFloat
    {
        public static byte N_TRITS_TOTAL = 27;  //here is where you can specify what number of trits you want to use for the BalFloat
        public static byte N_TRITS_SIGNIFICAND = (byte)Math.Ceiling((double)N_TRITS_TOTAL * 3 / 4);  //calculates the significand size as 2/3 of the total - may be a bit lean, might try 3/4
        public static byte N_TRITS_EXPONENT = (byte)Math.Floor((double)N_TRITS_TOTAL / 4);    //calculates the exponent size as 1/3 of the total - may be a bit excessive, might try 1/4
        public static byte N_DIGITS_PRECISION = (byte)Math.Abs(Math.Ceiling(Math.Log10(1 / Math.Pow(3, N_TRITS_SIGNIFICAND)))); //how many digits of precision?
        public static double Epsilon = Math.Pow(3.0, -(Math.Pow(3, N_TRITS_EXPONENT) - 1) / 2) / Math.Pow(3.0, N_TRITS_SIGNIFICAND); //Epsilon value (smallest representable number for the BalFloat)
        public static double MaxValue = Math.Pow(3.0, (Math.Pow(3, N_TRITS_EXPONENT) - 1) / 2 - 1) * 0.5;
        public static double MinValue = Math.Pow(3.0, Math.Pow(3, N_TRITS_EXPONENT) - 1) / 2 * -0.5;

        private BalTrit[] exponent = new BalTrit[N_TRITS_EXPONENT];
        private BalTrit[] significand = new BalTrit[N_TRITS_SIGNIFICAND];
        private BalTrit[] wholeBalFloat = new BalTrit[N_TRITS_TOTAL];
        private double doubleValue;
        private char[] floatChars = new char[N_TRITS_TOTAL];

        public double DoubleValue { get => doubleValue; set => SetValue(value); }   //when we modify the three value types, they are calling the appropriate SetValue function for that type
        public BalTrit[] Value { get => wholeBalFloat; set => SetValue(value); }
        public char[] FloatChars { get => floatChars; set => SetValue(value); }

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
        //public static BalFloat operator ++(BalFloat float1) => new BalFloat(float1.doubleValue += 1); 
        //public static BalFloat operator --(BalFloat float1) => new BalFloat(float1.doubleValue -= 1); //not sure if ++ or -- are appropriate for a floating point number
        public static BalFloat operator +(BalFloat @float) => new BalFloat(Math.Abs(@float.doubleValue));
        public static BalFloat operator -(BalFloat @float) => new BalFloat(-@float.doubleValue);

        public static implicit operator double(BalFloat @float) => @float.DoubleValue;
        public static implicit operator BalFloat(double doubleVal) => new BalFloat(doubleVal);
        public static explicit operator string(BalFloat @float) => new string(@float.floatChars);
        public static explicit operator BalFloat(string str) => (str.Length == N_TRITS_TOTAL) ? new BalFloat(str.ToCharArray()) : throw new ArithmeticException("Conversion from string to BalFloat unsuccessful because the string was not the expected length.");


        public BalFloat(double doubleValue)     //constructor calls the double property
        {
            DoubleValue = doubleValue;
        }

        public BalFloat(BalTrit[] wholeBalFloat)    //constructor calls the BalTrit[] property
        {
            Value = wholeBalFloat;
        }

        public BalFloat(char[] charValue)   //constructor calls the char[] property
        {
            FloatChars = charValue;
        }


        public static BalTrit BTCOMPARISON(BalFloat float1, BalFloat float2)
        {
            for (int i = 0; i < N_TRITS_EXPONENT; i++)
            {
                if (float1.exponent[i] > float2.exponent[i])
                {
                    return new BalTrit(1);
                }
                else if (float1.exponent[i] < float2.exponent[i])
                {
                    return new BalTrit(-1);
                }
            }
            for (int i = 0; i < N_TRITS_SIGNIFICAND; i++)
            {
                if (float1.significand[i] > float2.significand[i])
                {
                    return new BalTrit(1);
                }
                else if (float1.significand[i] < float2.significand[i])
                {
                    return new BalTrit(-1);
                }
            }
            return new BalTrit(0);
        }

        public bool LESSOREQUAL(BalFloat balFloat)
        {
            for (int i = 0; i < N_TRITS_EXPONENT; i++)  //first checks the exponent
            {
                if (exponent[i] < balFloat.exponent[i]) //the first time we encounter one being less than the other, return true
                {
                    return true;
                }
                else if (exponent[i] > balFloat.exponent[i])  //the first time we encounter one being greater than the other, return false
                {
                    return false;
                }
            }
            for (int i = 0; i < N_TRITS_SIGNIFICAND; i++)   //same with the significand
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
            return true;    //if everything was equal, return true
        }

        public bool GREATEROREQUAL(BalFloat balFloat)   //same thing for greater than or equal to
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

        public bool LESSTHAN(BalFloat balFloat)     //same thing for less than except...
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
            return false;   //...we return false if they're equal
        }

        public bool GREATERTHAN(BalFloat balFloat)  //same thing for greater than
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

        public override string ToString()
        {
            return new string(floatChars) + " which equals " + doubleValue;
        }

        public void SetAllExponentTritsTo(BalTrit trit) //set all the exponent trits to a particular trit value
        {
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
            {
                this.wholeBalFloat[i] = new BalTrit(trit.Value);
                this.exponent[i] = new BalTrit(trit.Value);
                this.floatChars[i] = trit.TritChar;
            }
        }

        public void SetAllSignificandTritsTo(BalTrit trit)      //set all the signficand trits to a particular trit value
        {
            for (int i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)
            {
                this.wholeBalFloat[i] = new BalTrit(trit.Value);
                this.significand[i - N_TRITS_EXPONENT] = new BalTrit(trit.Value);
                this.floatChars[i] = trit.TritChar;
            }
        }

        public void SetValue(double value)
        {
            this.doubleValue = value;
            if (value == 0)
            {
                SetAllExponentTritsTo(-1);
                SetAllSignificandTritsTo(0);
            }
            else if (double.IsPositiveInfinity(value))  //special cases like infinity, neg infinity, NaN/undefined
            {
                SetAllExponentTritsTo(1);
                SetAllSignificandTritsTo(1);
            }
            else if (double.IsNegativeInfinity(value))
            {
                SetAllExponentTritsTo(1);
                SetAllSignificandTritsTo(-1);
            }
            else if (double.IsNaN(value))
            {
                SetAllExponentTritsTo(1);
                SetAllSignificandTritsTo(0);
            }
            else     //real numbers are calculated here
            {
                int exponentValueBase3 = (int)Math.Ceiling((Math.Log(Math.Abs(value)) - Math.Log(0.5)) / Math.Log(3.0));  //calculate the exponent of 3 (magnitude)
                double significandValue = value / Math.Pow(3.0, exponentValueBase3);    //calculate the significand double value
                double remainder;   //remainder is how much is left after coverting to balanced ternary
                (this.significand, remainder) = ConvertDoubleToBalancedTritsWithRemainder(significandValue, N_TRITS_SIGNIFICAND); //significand in ternary floating point
                this.exponent = ConvertIntegerToBalancedTrits(exponentValueBase3, N_TRITS_EXPONENT);    //exponent in ternary integer
                for (byte i = 0; i < N_TRITS_EXPONENT; i++) //takes the exponent and significand (below) and puts them together into the whole balanced float, including chars +/-/0
                {
                    this.wholeBalFloat[i] = exponent[i];
                    this.floatChars[i] = exponent[i].TritChar;
                }
                for (int i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)  // continues here with significand
                {
                    this.wholeBalFloat[i] = significand[i - N_TRITS_EXPONENT];
                    this.floatChars[i] = significand[i - N_TRITS_EXPONENT].TritChar;
                }
            }
        }

        public void SetValue(BalTrit[] value)   //separates the whole balanced float into exponent and significand...
        {
            if (value.Length == N_TRITS_TOTAL)
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
                CreateDoubleValueIncludingSpecialCases();   //...and converts them into a double including infinities and NaNs
            }
            else
            {
                throw new ArgumentException("Trit array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL + " trits in length", "value");
            }
        }

        public void SetValue(char[] value)  // in case we're dealing with strings of +/-/0's this sets the trits to their appropriate values and...
        {
            if (value.Length == N_TRITS_TOTAL)
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
                CreateDoubleValueIncludingSpecialCases();   //...and does the same conversion to double with special cases
            }
            else
            {
                throw new ArgumentException("Char array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL + " chars in length", "value");
            }
        }


        public void CreateDoubleValueIncludingSpecialCases()
        {
            if (exponent.All(t => t.Value == 1))    //infinities and NaNs here
            {
                if (significand.All(t => t.Value == 1))
                {
                    doubleValue = double.PositiveInfinity;
                }
                else if (significand.All(t => t.Value == -1))
                {
                    doubleValue = double.NegativeInfinity;
                }
                else if (significand.All(t => t.Value == 0))
                {
                    doubleValue = double.NaN;
                }
            }
            else if (significand.All(t => t.Value == 0) && exponent.All(t => t.Value == -1))    //zero case
            {
                doubleValue = 0;
            }
            else      //real numbers calculated here
            {
                double exponentValue = (double)Math.Pow(3, ConvertBalancedTritsToInteger(exponent));  //integer for the exponent
                double significandValue = ConvertBalancedTritsToDouble(significand);    //and double for the significand
                doubleValue = significandValue * exponentValue; // multiply them together to get the final value
            }
        }


        public static BalTrit[] ConvertIntegerToBalancedTrits(int integerValue, byte nTrits)
        {
            BalTrit[] balTrits = new BalTrit[nTrits];
            int workValue = Math.Abs(integerValue);     //easier to work with a positive number...
            if (workValue <= (int)((Math.Pow(3, nTrits) - 1) / 2))  //make sure the value passed in is within the nTrits passed maximum value
            {
                byte i = 0;
                while (workValue != 0)      //easier to start with index 0 - greater numbers on the right
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
                    balTrits[j] = new BalTrit(0);   //...add zeros to fill in to make the length match the nTrits passed in
                }
                if (integerValue < 0)   //...and invert if it was negative
                {
                    foreach (var trit in balTrits)
                    {
                        trit.Value = !trit;
                    }
                }
                Array.Reverse(balTrits);    //...and reverse the trit order so greater numbers are on the left
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
            Array.Reverse(workTrits);   //easier to work with the array of trits reversed
            int sum = 0;
            short exponent = 0;
            foreach (var trit in workTrits)
            {
                sum += (int)(trit.Value * Math.Pow(3, exponent));   //exponent increases as the invisible index increases, and adds to the sum if the trit is -1 or 1
                exponent++;
            }
            return sum;
        }

        public static double ConvertBalancedTritsToDouble(BalTrit[] balTrits)   //same idea here, except we're counting exponents from -1 to the smallest exponent allowed by the implementation
        {
            double sum = 0;
            int exponent = -1;
            foreach (var trit in balTrits)
            {
                sum += trit.Value * Math.Pow(3, exponent);  //exponents are negative, so it's like doing 1/3^n and adding them up
                exponent--;
            }
            return sum;
        }

        public static (BalTrit[], double) ConvertDoubleToBalancedTritsWithRemainder(double doubleValue, int nTrits) //converts double to BalTrits[]
        {
            var balTrits = new BalTrit[nTrits];
            var sum = doubleValue;  //start with the sum total
            for (int exponent = 1; exponent <= nTrits; exponent++)  //start with 1/3
            {
                var place = Math.Pow(3.0, -exponent);
                var diffNegative = Math.Abs(sum - -place);
                var diffPositive = Math.Abs(sum - +place);
                if ((diffNegative < diffPositive) && diffNegative < Math.Abs(sum))  //is the negative difference smaller? smaller than if it's a zero?
                {
                    sum -= -place;   //subtract negative from sum if negative was smaller
                    balTrits[exponent - 1] = new BalTrit(-1);
                }
                else if ((diffPositive < diffNegative) && diffPositive < Math.Abs(sum)) //is the positive difference smaller? smaller than if it's a zero?
                {
                    sum -= +place;    //subtract positive from sum if positive was smaller
                    balTrits[exponent - 1] = new BalTrit(1);
                }
                else
                {
                    balTrits[exponent - 1] = new BalTrit(0);    //if zero was smaller, fill in a zero
                }
            }
            return (balTrits, sum); //return the array of trits, as well as the remainder (how much of the double value was not considered by the ternary conversion)
        }

        public override bool Equals(object obj) //just making sure I'm following all the rules and implementing an Equals function
        {
            return obj is BalFloat @float &&
                   EqualityComparer<BalTrit[]>.Default.Equals(wholeBalFloat, @float.wholeBalFloat);
        }

        public override int GetHashCode()   //same with the hash code
        {
            return HashCode.Combine(wholeBalFloat);
        }
    }


}
