﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace stdTernary
{

    // BalFloat versions of most Math functions, also including a log3 and trit increment/decrement
    public static class TernaryMath
    {
        public static BalFloat PI = Math.PI;

        public static BalFloat E = Math.E;

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

        public static BalInt ILogT(BalFloat balFloat)
        {
            return new BalInt((long)Math.Floor(Math.Log(balFloat.DoubleValue) / Math.Log(3)));
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

        public static BalFloat FusedMultiplyAdd(BalFloat balFloat1, BalFloat balFloat2, BalFloat balFloat3)
        {
            return new BalFloat(Math.FusedMultiplyAdd(balFloat1.DoubleValue, balFloat2.DoubleValue, balFloat3.DoubleValue));
        }


    }


    /// <summary>
    /// Balanced Ternary Trit with sbyte as datatype for -1 , 1, and 0 values, also with a char for trit characters  -, +, 0
    /// Considered using two bools or a bool? (three-valued bool with null as a possible value for zero).
    /// On Stack Overflow the answer seems to be that a bool is no faster than a byte, as the binary computer works in
    /// multiples of bytes, not on individual bits. Sticking with an sbyte for now.
    /// </summary>
    public struct BalTrit
    {
        private sbyte trit;
        private char tritChar;

        public sbyte Value { get => trit; set => SetValue(value); }
        public char TritChar { get => tritChar; set => SetValue(value); }

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


        public BalTrit(sbyte value)
        {
            if (value < 0)
            {
                trit = -1;
                tritChar = '-';
            }
            else if (value > 0)
            {
                trit = 1;
                tritChar = '+';
            }
            else
            {
                trit = 0;
                tritChar = '0';
            }
        }

        public BalTrit(char charValue)
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return tritChar.ToString() + " which equals " + trit;
        }

        public void SetValue(sbyte value)
        {
            if (value < 0)
            {
                trit = -1;
                tritChar = '-';
            }
            else if (value > 0)
            {
                trit = 1;
                tritChar = '+';
            }
            else
            {
                trit = 0;
                tritChar = '0';
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
    /// A customizable Balanced Ternary tryte data type/struct with a range of 2 - 10 trits per tryte. Bytewise operators have been overridden
    /// for everything except ^ (XOR) - which is a specifically binary operation. I might use ^ for XNOR/MULTIPLY but not sure. There is a
    /// BTCOMPARISON method which is for the <=> spaceship operator - but C# doesn't allow custom operators.
    /// </summary>
    public struct BalTryte
    {
        public static byte N_TRITS_PER_TRYTE = 9;   //can be from 2 - 10 trits
        public static short MaxValue = (short)((Math.Pow(3, N_TRITS_PER_TRYTE) - 1) / 2);
        public static short MinValue = (short)-MaxValue;
        //private BalTrit[] tryte = new BalTrit[N_TRITS_PER_TRYTE];
        //private char[] tryteChars = new char[N_TRITS_PER_TRYTE];
        private BalTrit[] tryte;
        private char[] tryteChars;
        private short shortValue;

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
        public static implicit operator BalTryte(short shortValue) => (shortValue <= MaxValue && shortValue >= MinValue) ? new BalTryte(shortValue) : throw new ArithmeticException("Tried to assign to a tryte a short that has a magnitude too big for a tryte of " + N_TRITS_PER_TRYTE + " trits");
        public static implicit operator int(BalTryte tryte) => tryte.shortValue;
        public static implicit operator BalTryte(int intValue) => (intValue <= MaxValue && intValue >= MinValue) ? new BalTryte((short)intValue) : throw new ArithmeticException("Tried to assign to a tryte an int that has a magnitude too big for a tryte of " + N_TRITS_PER_TRYTE + " trits");
        public static explicit operator string(BalTryte tryte) => new string(tryte.tryteChars);
        public static explicit operator BalTryte(string str) => new BalTryte(str.ToCharArray());

        public BalTryte(BalTrit[] value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                tryte = value;
                tryteChars = new char[N_TRITS_PER_TRYTE];
                short sum = 0;
                byte exponent = (byte)(N_TRITS_PER_TRYTE - 1);
                for (int i = 0; i < value.Length; i++)
                {
                    BalTrit trit = value[i];
                    sum += (short)(trit.Value * Math.Pow(3, exponent));
                    tryteChars[i] = trit.TritChar;
                    exponent--;
                }
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The trit array passed to BalTryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " trits in length", "value");
            }
        }

        public BalTryte(short value)
        {
            shortValue = value;
            tryte = new BalTrit[N_TRITS_PER_TRYTE];
            tryteChars = new char[N_TRITS_PER_TRYTE];
            short workValue = Math.Abs(value);
            if (workValue <= MaxValue)
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

        public BalTryte(char[] value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                tryteChars = value;
                tryte = new BalTrit[N_TRITS_PER_TRYTE];
                short sum = 0;
                short exponent = (short)(N_TRITS_PER_TRYTE - 1);
                for (int i = 0; i < value.Length; i++)
                {
                    char trit = value[i];
                    switch (trit)
                    {
                        case '+':
                            sum += (short)Math.Pow(3, exponent);
                            tryte[i] = new BalTrit(1);
                            break;
                        case '-':
                            sum -= (short)Math.Pow(3, exponent);
                            tryte[i] = new BalTrit(-1);
                            break;
                        case '0':
                            tryte[i] = new BalTrit(0);
                            break;
                    }
                    exponent--;
                }
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The character array passed to BalTryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " chars in length", "value");
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return new string(tryteChars) + " which equals " + shortValue;
        }

        public BalTryte SHIFTLEFT(int nTrits)
        {
            if (nTrits <= N_TRITS_PER_TRYTE)
            {
                var temp = new BalTrit[N_TRITS_PER_TRYTE];
                //Array.Copy(this.tryte, nTrits, temp, 0, N_TRITS_PER_TRYTE - nTrits);
                for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
                {
                    if (i >= N_TRITS_PER_TRYTE - nTrits)
                    {
                        temp[i] = new BalTrit(0);
                    }
                    else
                    {
                        temp[i] = tryte[i + nTrits];
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
            if (nTrits <= N_TRITS_PER_TRYTE)
            {
                var temp = new BalTrit[N_TRITS_PER_TRYTE];
                //Array.Copy(this.tryte, 0, temp, nTrits, N_TRITS_PER_TRYTE - nTrits);
                for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
                {
                    if (i < nTrits)
                    {
                        temp[i] = new BalTrit(0);
                    }
                    else
                    {
                        temp[i] = tryte[i - nTrits];
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
            if (temp > MaxValue || temp < MinValue)
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
            if (temp > MaxValue || temp < MinValue)
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
            if (temp > MaxValue || temp < MinValue)
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
                tryteChars = new char[N_TRITS_PER_TRYTE];
                short sum = 0;
                byte exponent = (byte)(N_TRITS_PER_TRYTE - 1);
                for (int i = 0; i < value.Length; i++)
                {
                    BalTrit trit = value[i];
                    sum += (short)(trit.Value * Math.Pow(3, exponent));
                    tryteChars[i] = trit.TritChar;
                    exponent--;
                }
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
                tryte = new BalTrit[N_TRITS_PER_TRYTE];
                short sum = 0;
                short exponent = (short)(N_TRITS_PER_TRYTE - 1);
                for (int i = 0; i < value.Length; i++)
                {
                    char trit = value[i];
                    switch (trit)
                    {
                        case '+':
                            sum += (short)Math.Pow(3, exponent);
                            tryte[i] = new BalTrit(1);
                            break;
                        case '-':
                            sum -= (short)Math.Pow(3, exponent);
                            tryte[i] = new BalTrit(-1);
                            break;
                        case '0':
                            tryte[i] = new BalTrit(0);
                            break;
                    }
                    exponent--;
                }
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
            if (workValue <= MaxValue)
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
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                tryte[i] = !tryte[i];
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
    /// The BalInt struct is a modifiable general purpose Balanced Ternary integer, with an array of trits, chars, and a long for the values it holds.
    /// All the math is done in binary and converted to ternary. Trit-shifting is done in Ternary. Can be explicitly cast to a string of +, -, 0's
    /// </summary>
    public struct BalInt
    {
        public static byte N_TRITS_PER_INT = 27;
        public static long MaxValue = (long)(Math.Pow(3, N_TRITS_PER_INT) - 1) / 2;
        public static long MinValue = -MaxValue;

        //private BalTrit[] balInt = new BalTrit[N_TRITS_PER_INT];
        //private char[] integerChars = new char[N_TRITS_PER_INT];
        private BalTrit[] balInt;
        private char[] integerChars;
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
        public static implicit operator long(BalInt @int) => (@int <= long.MaxValue && @int >= long.MinValue) ? @int.integerValue : throw new ArithmeticException("Converting a BalInt to a long value failed because it was outside the range of the long max/min values");
        public static implicit operator BalInt(long @int) => (@int <= MaxValue && @int >= MinValue) ? new BalInt(@int) : throw new ArithmeticException("Converting a long value to a BalInt failed because it was outside the range of the BalInt implementation");
        public static implicit operator int(BalInt @int) => (@int <= int.MaxValue && @int >= int.MinValue) ? (int)@int.integerValue : throw new ArithmeticException("Converting a BalInt to an int failed because the value was outside the range of the int max/min values");
        public static implicit operator BalInt(int @int) => (@int <= MaxValue && @int >= MinValue) ? new BalInt(@int) : throw new ArithmeticException("Converting an int value to a BalInt failed because it was outside the range of the BalInt implementation");
        public static implicit operator short(BalInt @int) => (@int <= short.MaxValue && @int >= short.MinValue) ? (short)@int.integerValue : throw new ArithmeticException("Converting a BalInt to a short failed because the value was outside the range of the short max/min values");
        public static implicit operator BalInt(short @int) => (@int <= MaxValue && @int >= MinValue) ? new BalInt(@int) : throw new ArithmeticException("Converting a short value to a BalInt failed because it was outside the range of the BalInt implementation");
        public static explicit operator string(BalInt @int) => new string(@int.integerChars);
        public static explicit operator BalInt(string str) => new BalInt(str.ToCharArray());
        public static explicit operator double(BalInt @int) => @int.integerValue;


        public BalInt(BalTrit[] value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                balInt = value;
                integerChars = new char[N_TRITS_PER_INT];
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

        public BalInt(char[] value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                integerChars = value;
                balInt = new BalTrit[N_TRITS_PER_INT];
                for (int i = 0; i < N_TRITS_PER_INT; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            balInt[i] = new BalTrit(1);
                            break;
                        case '-':
                            balInt[i] = new BalTrit(-1);
                            break;
                        case '0':
                            balInt[i] = new BalTrit(0);
                            break;
                        default:
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

        public BalInt(long value)
        {
            integerValue = value;
            balInt = ConvertIntegerToBalancedTrits(value);
            integerChars = new char[N_TRITS_PER_INT];
            for (int i = 0; i < N_TRITS_PER_INT; i++)
            {
                integerChars[i] = balInt[i].TritChar;
            }
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
                integerChars = new char[N_TRITS_PER_INT];
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
                    switch (value[i])
                    {
                        case '+':
                            balInt[i] = new BalTrit(1);
                            break;
                        case '-':
                            balInt[i] = new BalTrit(-1);
                            break;
                        case '0':
                            balInt[i] = new BalTrit(0);
                            break;
                        default:
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

        public static long ConvertBalancedTritsToInteger(BalTrit[] balTrits)
         {
            long sum = 0;
            short exponent = (short)(N_TRITS_PER_INT - 1);
            foreach (var trit in balTrits)
            {
                sum += (long)(trit.Value * Math.Pow(3, exponent));   //exponent increases as the invisible index increases, and adds to the sum if the trit is -1 or 1
                exponent--;
            }
            return sum;
        }

        public static BalTrit[] ConvertIntegerToBalancedTrits(long intValue)
        {
            BalTrit[] balTrits = new BalTrit[N_TRITS_PER_INT];
            long workValue = Math.Abs(intValue);     //easier to work with a positive number...
            if (workValue <= MaxValue)  //make sure the value passed in is within the nTrits passed maximum value
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
                    for (int n = 0; n < N_TRITS_PER_INT; n++)
                    {
                        balTrits[n] = !balTrits[n];
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
            for (byte i = 0; i < N_TRITS_PER_INT; i++)
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
                //Array.Copy(this.balInt, nTrits, temp, 0, N_TRITS_PER_INT - nTrits);
                for (byte i = 0; i < N_TRITS_PER_INT; i++)
                {
                    if (i >= N_TRITS_PER_INT - nTrits)
                    {
                        temp[i] = new BalTrit(0);
                    }
                    else
                    {
                        temp[i] = balInt[i + nTrits];
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
                for (byte i = 0; i < N_TRITS_PER_INT; i++)
                {
                    if (i < nTrits)
                    {
                        temp[i] = new BalTrit(0);
                    }
                    else
                    {
                        temp[i] = balInt[i - nTrits];
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
    /// The BalFloat struct is a modifiable general purpose Balanced Ternary floating point number with trits, chars, and a double. Might get rid of the chars because
    /// it slows things down, but it's intended for interoperability with my Action Ternary Simulator project, which uses strings of +/-/0's. Can be customized
    /// by changing the N_TRITS_TOTAL static parameter, and the fractions in the N_TRITS_SIGNIFICAND and N_TRITS_EXPONENT static parameters.
    /// </summary>
    public struct BalFloat
    {
        /// <summary>
        /// The total number of trits used by the BalFloat - 27 is a nice number
        /// </summary>
        public static byte N_TRITS_TOTAL = 27;
        /// <summary>
        /// The number of trits used for the significand in the BalFloat - the precision. Currently set to 3/4 of the total trits rounded up.
        /// </summary>
        public static byte N_TRITS_SIGNIFICAND = (byte)Math.Ceiling((double)N_TRITS_TOTAL * 3 / 4);
        /// <summary>
        /// The number of trits used for the exponent in the BalFloat - the magnitude. Currently set to 1/4 of the total trits rounded down.
        /// </summary>
        public static byte N_TRITS_EXPONENT = (byte)Math.Floor((double)N_TRITS_TOTAL / 4);
        /// <summary>
        /// The calculated number of digits of precision with a given N_TRITS_SIGNIFICAND
        /// </summary>
        public static byte N_DIGITS_PRECISION = (byte)Math.Abs(Math.Floor(Math.Log10(1 / Math.Pow(3, N_TRITS_SIGNIFICAND))));
        /// <summary>
        /// The smallest representable value for the BalFloat
        /// </summary>
        public static double Epsilon = Math.Pow(3, -(Math.Pow(3, N_TRITS_EXPONENT) - 1) / 2) / Math.Pow(3, N_TRITS_SIGNIFICAND);
        /// <summary>
        /// The maximum representable value for the BalFloat
        /// </summary>
        public static double MaxValue = Math.Pow(3, (Math.Pow(3, N_TRITS_EXPONENT) - 1) / 2 - 1) * 0.5;
        /// <summary>
        /// The minimum (negative) value representable for the BalFloat
        /// </summary>
        public static double MinValue = Math.Pow(3, (Math.Pow(3, N_TRITS_EXPONENT) - 1) / 2) * -0.5;

        private BalTrit[] exponent;
        private BalTrit[] significand;
        private BalTrit[] wholeBalFloat;
        private double doubleValue;
        private char[] floatChars;

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
        public static explicit operator BalFloat(string str) => new BalFloat(str.ToCharArray());

        /// <summary>
        /// Constructor for BalFloat struct, passing in a double as the value to be converted to Ternary
        /// </summary>
        /// <param name="value">The double value to be converted to Ternary</param>
        public BalFloat(double value)
        {
            wholeBalFloat = new BalTrit[N_TRITS_TOTAL];
            exponent = new BalTrit[N_TRITS_EXPONENT];
            significand = new BalTrit[N_TRITS_SIGNIFICAND];
            floatChars = new char[N_TRITS_TOTAL];
            if (value == 0 || Math.Abs(value) < BalFloat.Epsilon)
            {
                doubleValue = 0;
                SetAllExponentTrits(-1);
                SetAllSignificandTrits(0);
            }
            else if (double.IsPositiveInfinity(value) || value > BalFloat.MaxValue)  //special cases like infinity, neg infinity, NaN/undefined
            {
                doubleValue = double.PositiveInfinity;
                SetAllExponentTrits(1);
                SetAllSignificandTrits(1);
            }
            else if (double.IsNegativeInfinity(value) || value < BalFloat.MinValue)
            {
                doubleValue = double.NegativeInfinity;
                SetAllExponentTrits(1);
                SetAllSignificandTrits(-1);
            }
            else if (double.IsNaN(value))
            {
                doubleValue = double.NaN;
                SetAllExponentTrits(1);
                SetAllSignificandTrits(0);
            }
            else     //real, nonzero numbers are calculated here
            {
                //this.doubleValue = value;
                doubleValue = RoundToNearestDigitOfPrecision(value);
                int exponentValueBase3 = (int)Math.Ceiling((Math.Log(Math.Abs(doubleValue)) - Math.Log(0.5)) / Math.Log(3));  //calculate the exponent of 3 (magnitude)
                double significandValue = doubleValue / Math.Pow(3, exponentValueBase3);    //calculate the significand double value
                double remainder;   //remainder is how much is left after coverting to balanced ternary
                (significand, remainder) = ConvertDoubleToBalancedTritsWithRemainder(significandValue, N_TRITS_SIGNIFICAND); //significand in ternary floating point
                exponent = ConvertIntegerToBalancedTrits(exponentValueBase3, N_TRITS_EXPONENT);    //exponent in ternary integer
                wholeBalFloat = new BalTrit[N_TRITS_TOTAL];
                floatChars = new char[N_TRITS_TOTAL];
                for (byte i = 0; i < N_TRITS_EXPONENT; i++) //takes the exponent and significand (below) and puts them together into the whole balanced float, including chars +/-/0
                {
                    wholeBalFloat[i] = exponent[i];
                    floatChars[i] = exponent[i].TritChar;
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)  // continues here with significand
                {
                    wholeBalFloat[i] = significand[i - N_TRITS_EXPONENT];
                    floatChars[i] = significand[i - N_TRITS_EXPONENT].TritChar;
                }
            }
        }

        private readonly void SetAllSignificandTrits(sbyte t)
        {
            for (int i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)
            {
                this.wholeBalFloat[i] = new BalTrit(t);
                this.significand[i - N_TRITS_EXPONENT] = new BalTrit(t);
                this.floatChars[i] = wholeBalFloat[i].TritChar;
            }
        }

        private readonly void SetAllExponentTrits(sbyte t)
        {
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
            {
                wholeBalFloat[i] = new BalTrit(t);
                exponent[i] = new BalTrit(t);
                floatChars[i] = wholeBalFloat[i].TritChar;
            }
        }

        /// <summary>
        /// Constructor for the BalFloat taking an array of BalTrits to be converted to binary
        /// </summary>
        /// <param name="value">The array of BalTrits to pass into the constructor</param>
        public BalFloat(BalTrit[] value)
        {
            if (value.Length == N_TRITS_TOTAL)
            {
                wholeBalFloat = value;
                exponent = new BalTrit[N_TRITS_EXPONENT];
                significand = new BalTrit[N_TRITS_SIGNIFICAND];
                floatChars = new char[N_TRITS_TOTAL];
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
                    else
                    {
                        doubleValue = 0;
                    }
                }
                else if (significand.All(t => t.Value == 0) && exponent.All(t => t.Value == -1))    //zero case
                {
                    doubleValue = 0;
                }
                else      //real nonzero numbers calculated here
                {
                    double exponentValue = (double)Math.Pow(3, ConvertBalancedTritsToInteger(exponent));  //double for the exponent
                    double significandValue = ConvertBalancedTritsToDouble(significand);    //and double for the significand
                    doubleValue = significandValue * exponentValue; // multiply them together to get the final value
                    doubleValue = RoundToNearestDigitOfPrecision(doubleValue);  //round to nearest digit of precision
                }

            }
            else
            {
                throw new ArgumentException("Trit array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL + " trits in length", "value");
            }
        }

        /// <summary>
        /// A constructor passing in an array of chars and converting to trits and a double
        /// </summary>
        /// <param name="value">Character Array representing Balanced Ternary</param>
        public BalFloat(char[] value)
        {
            if (value.Length == N_TRITS_TOTAL)
            {
                floatChars = value;
                wholeBalFloat = new BalTrit[N_TRITS_TOTAL];
                exponent = new BalTrit[N_TRITS_EXPONENT];
                significand = new BalTrit[N_TRITS_SIGNIFICAND];
                for (byte i = 0; i < N_TRITS_EXPONENT; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            exponent[i] = new BalTrit(1);
                            break;
                        case '-':
                            exponent[i] = new BalTrit(-1);
                            break;
                        case '0':
                            exponent[i] = new BalTrit(0);
                            break;
                        default:
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
                    else
                    {
                        doubleValue = 0;
                    }
                }
                else if (significand.All(t => t.Value == 0) && exponent.All(t => t.Value == -1))    //zero case
                {
                    doubleValue = 0;
                }
                else      //real nonzero numbers calculated here
                {
                    double exponentValue = (double)Math.Pow(3, ConvertBalancedTritsToInteger(exponent));  //integer for the exponent
                    double significandValue = ConvertBalancedTritsToDouble(significand);    //and double for the significand
                    doubleValue = significandValue * exponentValue; // multiply them together to get the final value
                    doubleValue = RoundToNearestDigitOfPrecision(doubleValue);
                }

            }
            else
            {
                throw new ArgumentException("Char array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL + " chars in length", "value");
            }
        }

        /// <summary>
        /// Rounds to the nearest digit of precision as calculated in the static member N_DIGITS_PRECISION.
        /// If it's a whole number, it returns the whole number. If it's in scientific notation, it returns
        /// a rounded version, and if it's a floating point number not in scientific notation, it rounds
        /// to the nearest digit of precision including the digits before the floating point.
        /// </summary>
        /// <param name="doubleValue">The double value passed in to be rounded</param>
        /// <returns>The double value of the rounded floating point number</returns>
        public static double RoundToNearestDigitOfPrecision(double doubleValue)
        {
            var doubleString = doubleValue.ToString();
            if (doubleString.Contains('E'))
            {
                var sigsplit = doubleString.Split('E');
                var significand = double.Parse(sigsplit[0]);
                significand = Math.Round(significand, N_DIGITS_PRECISION - 1);
                return significand * Math.Pow(10, int.Parse(sigsplit[1]));
            }
            else
            {
                doubleString = Math.Abs(doubleValue).ToString();
                if (doubleString.Contains('.'))
                {
                    var splitString = doubleString.Split('.');
                    var split = splitString[0];
                    if (split == "0")
                    {
                        return Math.Round(doubleValue, N_DIGITS_PRECISION);
                    }
                    else if (split.Length <= N_DIGITS_PRECISION)
                    {
                        return Math.Round(doubleValue, N_DIGITS_PRECISION - split.Length);
                    }
                    else
                    {
                        return Math.Round(doubleValue, 0);
                    }
                }
                else
                {
                    return doubleValue;
                }
            }
        }

        /// <summary>
        /// Balanced Ternary Comparison Operator - supposed to be used with the spaceship operator <=> but C# doesn't support custom operators at this time.
        /// Returns 0 if the two floats are equal, 1 if the first float is larger, and -1 if the first float is smaller. Checks the exponent first, then
        /// the significand.
        /// </summary>
        /// <param name="float1"></param>
        /// <param name="float2"></param>
        /// <returns>A BalTrit with value of 1, -1, or 0</returns>
        public static BalTrit BTCOMPARISON (BalFloat float1, BalFloat float2)    
        {                                                                       
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)  
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
            for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
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
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)  //first checks the exponent
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
            for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)   //same with the significand
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
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)  
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
            for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
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
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
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
            for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
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
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
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
            for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
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
                wholeBalFloat[i] = new BalTrit(trit.Value);
                exponent[i] = new BalTrit(trit.Value);
                floatChars[i] = trit.TritChar;
            }
        }

        public void SetAllSignificandTritsTo(BalTrit trit)      //set all the signficand trits to a particular trit value
        {
            for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)
            {
                wholeBalFloat[i] = new BalTrit(trit.Value);
                significand[i - N_TRITS_EXPONENT] = new BalTrit(trit.Value);
                floatChars[i] = trit.TritChar;
            }
        }

        public void SetValue(double value)
        {
            if (value == 0 || Math.Abs(value) < BalFloat.Epsilon)
            {
                doubleValue = 0;
                SetAllExponentTritsTo(-1);
                SetAllSignificandTritsTo(0);
            }
            else if (double.IsPositiveInfinity(value) || value > BalFloat.MaxValue)  //special cases like infinity, neg infinity, NaN/undefined
            {
                doubleValue = double.PositiveInfinity;
                SetAllExponentTritsTo(1);
                SetAllSignificandTritsTo(1);
            }
            else if (double.IsNegativeInfinity(value) || value < BalFloat.MinValue)
            {
                doubleValue = double.NegativeInfinity;
                SetAllExponentTritsTo(1);
                SetAllSignificandTritsTo(-1);
            }
            else if (double.IsNaN(value))
            {
                doubleValue = double.NaN;
                SetAllExponentTritsTo(1);
                SetAllSignificandTritsTo(0);
            }
            else     //real, nonzero numbers are calculated here
            {
                doubleValue = RoundToNearestDigitOfPrecision(value);
                int exponentValueBase3 = (int)Math.Ceiling((Math.Log(Math.Abs(doubleValue)) - Math.Log(0.5)) / Math.Log(3));  //calculate the exponent of 3 (magnitude)
                double significandValue = doubleValue / Math.Pow(3, exponentValueBase3);    //calculate the significand double value
                double remainder;   //remainder is how much is left after coverting to balanced ternary
                (significand, remainder) = ConvertDoubleToBalancedTritsWithRemainder(significandValue, N_TRITS_SIGNIFICAND); //significand in ternary floating point
                exponent = ConvertIntegerToBalancedTrits(exponentValueBase3, N_TRITS_EXPONENT);    //exponent in ternary integer
                for (byte i = 0; i < N_TRITS_EXPONENT; i++) //takes the exponent and significand (below) and puts them together into the whole balanced float, including chars +/-/0
                {
                    wholeBalFloat[i] = exponent[i];
                    floatChars[i] = exponent[i].TritChar;
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL; i++)  // continues here with significand
                {
                    wholeBalFloat[i] = significand[i - N_TRITS_EXPONENT];
                    floatChars[i] = significand[i - N_TRITS_EXPONENT].TritChar;
                }
            }
        }

        public void SetValue(BalTrit[] value)   //separates the whole balanced float into exponent and significand...
        {
            if (value.Length == N_TRITS_TOTAL)
            {
                wholeBalFloat = value;
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
                floatChars = value;
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

        /// <summary>
        /// Creates a double value based on the exponent and significand and puts it in the doubleValue struct member.
        /// Takes into account special values like infinities and NaNs, and does so without needing to know how many
        /// total trits are involved - uses LINQ's All function.
        /// </summary>
        private void CreateDoubleValueIncludingSpecialCases()
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
            else      //real nonzero numbers calculated here
            {
                double exponentValue = (double)Math.Pow(3, ConvertBalancedTritsToInteger(exponent));  //double for the exponent (incluing negative exponents)
                double significandValue = ConvertBalancedTritsToDouble(significand);    //and double for the significand
                doubleValue = significandValue * exponentValue; // multiply them together to get the final value
                doubleValue = RoundToNearestDigitOfPrecision(doubleValue);
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
                for (byte j = i; j < nTrits; j++)
                {
                    balTrits[j] = new BalTrit(0);   //...add zeros to fill in to make the length match the nTrits passed in
                }
                if (integerValue < 0)   //...and invert if it was negative
                {
                    for (byte n = 0; n < nTrits; n++)
                    {
                        balTrits[n] = !balTrits[n];
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
            int sum = 0;
            short exponent = (short)(balTrits.Length - 1);
            foreach (var trit in balTrits)
            {
                sum += (int)(trit.Value * Math.Pow(3, exponent));
                exponent--;
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
                var place = Math.Pow(3, -exponent);
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
