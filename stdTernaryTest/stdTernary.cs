using System;
using System.Collections.Generic;
using System.Linq;

namespace stdTernary
{

    // FloatT versions of most Math functions, also including a log3, ILogT, and trit increment/decrement
    public static class MathT
    {
        public static FloatT PI = Math.PI;

        public static FloatT E = Math.E;

        public static FloatT Pow(FloatT a, FloatT b)
        {
            return new FloatT(Math.Pow(a.DoubleValue, b.DoubleValue));
        }

        public static FloatT Sqrt(FloatT f)
        {
            return new FloatT(Math.Sqrt(f.DoubleValue));
        }

        public static FloatT Sin(FloatT f)
        {
            return new FloatT(Math.Sin(f.DoubleValue));
        }

        public static FloatT Cos(FloatT f)
        {
            return new FloatT(Math.Cos(f.DoubleValue));
        }

        public static FloatT Tan(FloatT f)
        {
            return new FloatT(Math.Tan(f.DoubleValue));
        }

        public static FloatT Sinh(FloatT f)
        {
            return new FloatT(Math.Sinh(f.DoubleValue));
        }

        public static FloatT Cosh(FloatT f)
        {
            return new FloatT(Math.Cosh(f.DoubleValue));
        }

        public static FloatT Tanh(FloatT f)
        {
            return new FloatT(Math.Tanh(f.DoubleValue));
        }

        public static FloatT Asin(FloatT f)
        {
            return new FloatT(Math.Sin(f.DoubleValue));
        }

        public static FloatT Acos(FloatT f)
        {
            return new FloatT(Math.Cos(f.DoubleValue));
        }

        public static FloatT Atan(FloatT f)
        {
            return new FloatT(Math.Tan(f.DoubleValue));
        }

        public static FloatT Asinh(FloatT f)
        {
            return new FloatT(Math.Sinh(f.DoubleValue));
        }

        public static FloatT Acosh(FloatT f)
        {
            return new FloatT(Math.Cosh(f.DoubleValue));
        }

        public static FloatT Atanh(FloatT f)
        {
            return new FloatT(Math.Atanh(f.DoubleValue));
        }

        public static FloatT Log(FloatT f)
        {
            return new FloatT(Math.Log(f.DoubleValue));
        }

        public static FloatT Log10(FloatT f)
        {
            return new FloatT(Math.Log10(f.DoubleValue));
        }

        public static FloatT Log2(FloatT f)
        {
            return new FloatT(Math.Log2(f.DoubleValue));
        }

        public static FloatT Log3(FloatT f)
        {
            return new FloatT(Math.Log(f.DoubleValue) / Math.Log(3));
        }

        /// <summary>
        /// Calculates the integer (IntT) equivalent of the ternary logarithm (base 3) of a BalFloat
        /// </summary>
        /// <param name="f"></param>
        /// <returns>BalInt base 3 logarithm of f</returns>
        public static IntT ILogT(FloatT f)
        {
            return new IntT((long)Math.Floor(Math.Log(f.DoubleValue) / Math.Log(3)));
        }

        public static FloatT Atan2(FloatT a, FloatT b)
        {
            return new FloatT(Math.Atan2(a.DoubleValue, b.DoubleValue));
        }

        public static FloatT Abs(FloatT f)
        {
            return new FloatT(Math.Abs(f.DoubleValue));
        }

        public static FloatT Cbrt(FloatT f)
        {
            return new FloatT(Math.Cbrt(f.DoubleValue));
        }

        /// <summary>
        /// Increments a FloatT by one trit, returning the result
        /// </summary>
        /// <param name="f"></param>
        /// <returns>A new, incremented BalFloat</returns>
        public static FloatT TritIncrement(FloatT f)
        {
            sbyte carry = 1;
            Trit[] trits = new Trit[FloatT.N_TRITS_TOTAL_FLOAT];
            for (int i = FloatT.N_TRITS_TOTAL_FLOAT - 1; i >= 0; i--)
            {
                sbyte n = (sbyte)(f.Value[i].Value + carry);
                switch (n)
                {
                    case 0:
                        trits[i] = new Trit(0);
                        carry = 0;
                        break;
                    case 1:
                        trits[i] = new Trit(1);
                        carry = 0;
                        break;
                    case 2:
                        trits[i] = new Trit(-1);
                        carry = 1;
                        break;
                    case -1:
                        trits[i] = new Trit(-1);
                        carry = 0;
                        break;
                    case -2:
                        trits[i] = new Trit(1);
                        carry = -1;
                        break;
                }
            }
            return new FloatT(trits);
        }

        /// <summary>
        /// Decrements a FloatT by one trit, returning the result
        /// </summary>
        /// <param name="f"></param>
        /// <returns>A new, incremented BalFloat</returns>
        public static FloatT TritDecrement(FloatT f)
        {
            sbyte carry = -1;
            Trit[] trits = new Trit[FloatT.N_TRITS_TOTAL_FLOAT];
            for (int i = FloatT.N_TRITS_TOTAL_FLOAT - 1; i >= 0; i--)
            {
                sbyte n = (sbyte)(f.Value[i].Value + carry);
                switch (n)
                {
                    case 0:
                        trits[i] = 0;
                        carry = 0;
                        break;
                    case 1:
                        trits[i] = new Trit(1);
                        carry = 0;
                        break;
                    case 2:
                        trits[i] = new Trit(-1);
                        carry = 1;
                        break;
                    case -1:
                        trits[i] = new Trit(-1);
                        carry = 0;
                        break;
                    case -2:
                        trits[i] = new Trit(1);
                        carry = -1;
                        break;
                }
            }
            return new FloatT(trits);
        }

        public static FloatT FusedMultiplyAdd(FloatT a, FloatT b, FloatT c)
        {
            return new FloatT(Math.FusedMultiplyAdd(a.DoubleValue, b.DoubleValue, c.DoubleValue));
        }

    }


    /// <summary>
    /// Balanced Ternary Trit with sbyte enum as datatype for -1 , 1, and 0 values, and conversions for ints, sbytes, characters,
    /// and overridden operators for tritwise operations.
    /// </summary>
    public struct Trit
    {
        public enum TritVal : sbyte
        {
            p = 1,
            n = -1,
            z = 0
        }
        private TritVal trit;

        public TritVal Value { get => trit; set => SetValue(value); }
        public char GetChar { get => ConvertToChar(); }

        public static Trit operator &(Trit left, Trit right) => left.AND(right);
        public static Trit operator |(Trit left, Trit right) => left.OR(right);
        public static Trit operator ~(Trit trit) => trit.NEG();
        public static Trit operator !(Trit trit) => trit.NEG();
        public static Trit operator *(Trit left, Trit right) => left.MULT(right);
        public static Trit operator +(Trit left, Trit right) => left.SUM(right);
        public static bool operator ==(Trit left, Trit right) => left.Value == right.Value;
        public static bool operator !=(Trit left, Trit right) => left.Value != right.Value;
        public static bool operator >(Trit left, Trit right) => left.Value > right.Value;
        public static bool operator <(Trit left, Trit right) => left.Value < right.Value;
        public static bool operator >=(Trit left, Trit right) => left.Value >= right.Value;
        public static bool operator <=(Trit left, Trit right) => left.Value <= right.Value;
        public static bool operator true(Trit trit) => trit.Value == TritVal.p;
        public static bool operator false(Trit trit) => trit.Value == TritVal.n || trit.Value == TritVal.z;

        public static explicit operator bool(Trit trit) => trit.trit == TritVal.p;
        public static explicit operator Trit(bool b) => b ? new Trit(1) : new Trit(-1);
        public static implicit operator sbyte(Trit trit) => (sbyte)trit.trit;
        public static implicit operator Trit(sbyte sb) => (sb <= 1 && sb >= -1) ? new Trit(sb) : throw new ArithmeticException("Tried to assign a value too big for Trit - keep it to -1, 0, or 1");
        public static implicit operator int(Trit trit) => (int)trit.trit;
        public static implicit operator Trit(int @int) => (@int <= 1 && @int >= -1) ? new Trit(@int) : throw new ArithmeticException("Tried to assign a value too big for Trit -  keep it to -1, 0, or 1");

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Trit trit &&
                   this.trit == trit.trit;
        }

        public Trit(sbyte value)
        {
            this.trit = (TritVal)value;
        }

        public Trit(int value)
        {
            this.trit = (TritVal)value;
        }

        public Trit(TritVal trit)
        {
            this.trit = trit;
        }

        public Trit(char charValue)
        {
            switch (charValue)
            {
                case '0':
                    this.trit = TritVal.z;
                    break;
                case '+':
                    this.trit = TritVal.p;
                    break;
                case '-':
                    this.trit = TritVal.n;
                    break;
                default:
                    throw new ArgumentException("Trit SetValue not given a valid ternary character. Should be 0, +, or -", "charValue");
            }
        }

        public void SetValue(TritVal trit)
        {
            this.trit = trit;
        }

        public void SetValue(sbyte value)
        {
            this.trit = (TritVal)value;
        }

        public void SetValue(int value)
        {
            this.trit = (TritVal)value;
        }

        public void SetValue(char charValue)
        {
            switch (charValue)
            {
                case '0':
                    this.trit = TritVal.z;
                    break;
                case '+':
                    this.trit = TritVal.p;
                    break;
                case '-':
                    this.trit = TritVal.n;
                    break;
                default:
                    throw new ArgumentException("Trit SetValue not given a valid ternary character. Should be 0, z, +, p, -, or n", "charValue");
            }
        }

        public char ConvertToChar()
        {
            switch (this.trit)
            {
                case TritVal.n:
                    return '-';
                case TritVal.p:
                    return '+';
                default:
                    return '0';
            }
        }

        public Trit NEG()
        {
            return new Trit((sbyte)(((sbyte)trit) * -1));
        }

        public Trit SUM(Trit t)
        {
            if (this.trit == t.Value)
            {
                return this.NEG();
            }
            else if ((sbyte)this.trit == -(sbyte)t.Value)
            {
                return new Trit(0);
            }
            else if (this.trit == 0)
            {
                return new Trit(t.Value);
            }
            else if (t.Value == 0)
            {
                return new Trit(this.trit);
            }
            else
            {
                throw new ArgumentException("Unknown state of trit in SUM operation.", "t");
            }
        }

        public Trit CONS(Trit t)
        {
            if (this.trit == t.Value)
            {
                return new Trit(this.trit);
            }
            else
            {
                return new Trit(0);
            }
        }

        public Trit XNOR(Trit t)
        {
            return new Trit((sbyte)((sbyte)this.trit * (sbyte)t.Value));
        }

        public Trit MULT(Trit t)
        {
            return this.XNOR(t);
        }

        public Trit MIN(Trit t)
        {
            if (this.trit == TritVal.n || t.Value == TritVal.n)
            {
                return new Trit(-1);
            }
            else if (this.trit == TritVal.z || t.Value == TritVal.z)
            {
                return new Trit(0);
            }
            else
            {
                return new Trit(1);
            }
        }

        public Trit AND(Trit t)
        {
            return this.MIN(t);
        }

        public Trit MAX(Trit t)
        {
            if (this.trit == TritVal.p || t.Value == TritVal.p)
            {
                return new Trit(1);
            }
            if (this.trit == TritVal.z || t.Value == TritVal.z)
            {
                return new Trit(0);
            }
            else
            {
                return new Trit(-1);
            }
        }

        public Trit OR(Trit t)
        {
            return this.MAX(t);
        }

        public Trit EQUAL(Trit t)
        {
            if (trit == t.Value)
            {
                return new Trit(1);
            }
            else
            {
                return new Trit(-1);
            }
        }

        public Trit NOTEQUAL(Trit t)
        {
            if (trit != t.Value)
            {
                return new Trit(1);
            }
            else
            {
                return new Trit(-1);
            }
        }
    }


    /// <summary>
    /// A customizable Balanced Ternary tryte data type/struct with a range of 2 - 10 trits per tryte. Bytewise operators have been overridden
    /// for everything except ^ (XOR) - which is a specifically binary operation. I might use ^ for XNOR/MULTIPLY but not sure. There is a
    /// COMPARISON method which is for the <=> spaceship operator - a ternary comparison - but C# doesn't allow custom operators.
    /// </summary>
    public struct Tryte
    {
        /// <summary>
        /// Static member defining the number of Trits in a Tryte. Can be between 2 and 10 trits.
        /// </summary>
        public static byte N_TRITS_PER_TRYTE = 6;
        /// <summary>
        /// Maximum value representable by a Tryte of length N_TRITS_PER_TRYTE
        /// </summary>
        public static short MaxValue = (short)((Math.Pow(3, N_TRITS_PER_TRYTE) - 1) / 2);
        /// <summary>
        /// Minimum (negative) value representable by a Tryte of length N_TRITS_PER_TRYTE
        /// </summary>
        public static short MinValue = (short)-MaxValue;
        /// <summary>
        /// The Tryte value represented by an array of Trits
        /// </summary>
        private Trit[] tryte;
        /// <summary>
        /// The Tryte vaue represented by a short binary integer
        /// </summary>
        private short shortValue;

        public Trit[] Value { get => tryte; set => SetValue(value); }
        public string TryteString { get => ConvertToStringRepresentation(); }
        public short ShortValue { get => shortValue; set => SetValue(value); }

        public static Tryte operator &(Tryte left, Tryte right) => left.AND(right);
        public static Tryte operator |(Tryte left, Tryte right) => left.OR(right);
        public static Tryte operator ~(Tryte tryte) => tryte.Invert();
        public static bool operator ==(Tryte left, Tryte right) => left.shortValue == right.shortValue;
        public static bool operator ==(Tryte left, int right) => left.shortValue == right;
        public static bool operator !=(Tryte left, Tryte right) => left.shortValue != right.shortValue;
        public static bool operator !=(Tryte left, int right) => left.shortValue != right;
        public static bool operator >(Tryte left, Tryte right) => left.shortValue > right.shortValue;
        public static bool operator <(Tryte left, Tryte right) => left.shortValue < right.shortValue;
        public static bool operator >=(Tryte left, Tryte right) => left.shortValue >= right.shortValue;
        public static bool operator <=(Tryte left, Tryte right) => left.shortValue <= right.shortValue;
        public static bool operator >(Tryte left, int right) => left.shortValue > right;
        public static bool operator <(Tryte left, int right) => left.shortValue < right;
        public static bool operator >=(Tryte left, int right) => left.shortValue >= right;
        public static bool operator <=(Tryte left, int right) => left.shortValue <= right;
        public static Tryte operator +(Tryte left, Tryte right) => left.SUM(right);
        public static Tryte operator *(Tryte left, Tryte right) => left.MULT(right);
        public static Tryte operator -(Tryte left, Tryte right) => left.SUB(right);
        public static Tryte operator /(Tryte left, Tryte right) => left.DIV(right);
        public static Tryte operator %(Tryte left, Tryte right) => left.MOD(right);
        public static Tryte operator <<(Tryte tryte, int nTrits) => tryte.SHIFTLEFT(nTrits);
        public static Tryte operator >>(Tryte tryte, int nTrits) => tryte.SHIFTRIGHT(nTrits);
        public static Tryte operator ++(Tryte tryte) => new Tryte((short)(tryte.shortValue + 1));
        public static Tryte operator --(Tryte tryte) => new Tryte((short)(tryte.shortValue - 1));
        public static Tryte operator +(Tryte tryte) => new Tryte(Math.Abs(tryte.shortValue));
        public static Tryte operator -(Tryte tryte) => new Tryte((short)-tryte.shortValue);
        public static implicit operator short(Tryte tryte) => tryte.shortValue;
        public static implicit operator Tryte(short shortValue) => (shortValue <= MaxValue && shortValue >= MinValue) ? new Tryte(shortValue) : throw new ArithmeticException("Tried to assign to a tryte a short that has a magnitude too big for a tryte of " + N_TRITS_PER_TRYTE + " trits");
        public static implicit operator int(Tryte tryte) => tryte.shortValue;
        public static implicit operator Tryte(int intValue) => (intValue <= MaxValue && intValue >= MinValue) ? new Tryte((short)intValue) : throw new ArithmeticException("Tried to assign to a tryte an int that has a magnitude too big for a tryte of " + N_TRITS_PER_TRYTE + " trits");
        public static explicit operator string(Tryte tryte) => tryte.TryteString;
        public static explicit operator Tryte(string str) => new Tryte(str);

        public Tryte(Trit[] value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                this.tryte = value;
                short sum = 0;
                short exponent = (short)(N_TRITS_PER_TRYTE - 1);
                foreach (var trit in value)
                {
                    sum += (short)((sbyte)trit.Value * Math.Pow(3, exponent));   //exponent increases as the invisible index increases, and adds to the sum if the trit is -1 or 1
                    exponent--;
                }
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The trit array passed to Tryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " trits in length", "value");
            }
        }

        public Tryte(short value)
        {
            if (value <= MaxValue && value >= MinValue)
            {
                shortValue = value;
                this.tryte = ConvertIntegerToBalancedTrits(value);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The short value passed to SetValue in Tryte was too large to fit in a " + N_TRITS_PER_TRYTE + " trit tryte", "value");
            }
        }

        public Tryte(string value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                tryte = new Trit[N_TRITS_PER_TRYTE];
                short sum = 0;
                short exponent = (short)(N_TRITS_PER_TRYTE - 1);
                for (int i = 0; i < value.Length; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            sum += (short)Math.Pow(3, exponent);
                            tryte[i] = new Trit(1);
                            break;
                        case '-':
                            sum -= (short)Math.Pow(3, exponent);
                            tryte[i] = new Trit(-1);
                            break;
                        case '0':
                            tryte[i] = new Trit(0);
                            break;
                        default:
                            throw new ArgumentException("Invalid character encountered in a balanced ternary char array. Please stick to +, -, 0's", "value");
                    }
                    exponent--;
                }
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The character array passed to Tryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " chars in length", "value");
            }
        }

        public void SetValue(Trit[] value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                this.tryte = value;
                short sum = 0;
                short exponent = (short)(N_TRITS_PER_TRYTE - 1);
                foreach (var trit in value)
                {
                    sum += (short)((sbyte)trit.Value * Math.Pow(3, exponent));   //exponent increases as the invisible index increases, and adds to the sum if the trit is -1 or 1
                    exponent--;
                }
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The trit array passed to Tryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " trits in length", "value");
            }
        }

        public void SetValue(string value)
        {
            if (value.Length == N_TRITS_PER_TRYTE)
            {
                tryte = new Trit[N_TRITS_PER_TRYTE];
                short sum = 0;
                short exponent = (short)(N_TRITS_PER_TRYTE - 1);
                for (int i = 0; i < value.Length; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            sum += (short)Math.Pow(3, exponent);
                            tryte[i] = new Trit(1);
                            break;
                        case '-':
                            sum -= (short)Math.Pow(3, exponent);
                            tryte[i] = new Trit(-1);
                            break;
                        case '0':
                            tryte[i] = new Trit(0);
                            break;
                        default:
                            throw new ArgumentException("Invalid character encountered in a balanced ternary char array. Please stick to +, -, 0's", "value");
                    }
                    exponent--;
                }
                shortValue = sum;
            }
            else
            {
                throw new ArgumentException("The character array passed to Tryte was not the expected size, should be " + N_TRITS_PER_TRYTE + " chars in length", "value");
            }
        }

        public void SetValue(short value)
        {
            if (value <= MaxValue && value >= MinValue)
            {
                shortValue = value;
                this.tryte = ConvertIntegerToBalancedTrits(value);
            }
            else
            {
                throw new ArgumentOutOfRangeException("The short value passed to SetValue in Tryte was too large to fit in a " + N_TRITS_PER_TRYTE + " trit tryte", "value");
            }
        }

        public static Trit[] ConvertIntegerToBalancedTrits(int intValue)
        {
            Trit[] trits = new Trit[N_TRITS_PER_TRYTE];
            int workValue = Math.Abs(intValue);     //easier to work with a positive number...
            byte i = 0;     //easier to start with index 0 - greater numbers on the right
            while (workValue != 0)
            {
                switch (workValue % 3)
                {
                    case 0:
                        trits[i] = new Trit(0);
                        break;
                    case 1:
                        trits[i] = new Trit(1);
                        break;
                    case 2:
                        trits[i] = new Trit(-1);
                        break;
                }
                workValue = (workValue + 1) / 3;
                i++;
            }
            for (int j = i; j < N_TRITS_PER_TRYTE; j++)
            {
                trits[j] = new Trit(0);   //...add zeros to fill in to make the length match the N_TRITS_PER_INT static value
            }
            if (intValue < 0)   //...and invert if it was negative
            {
                for (int n = 0; n < N_TRITS_PER_TRYTE; n++)
                {
                    trits[n] = !trits[n];
                }
            }
            Array.Reverse(trits);    //...and reverse the trit order so greater numbers are on the left
            return trits;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Tryte tryte &&
                   EqualityComparer<Trit[]>.Default.Equals(this.tryte, tryte.tryte);
        }

        public override string ToString()
        {
            return new string(TryteString) + " which equals " + shortValue;
        }

        public string ConvertToStringRepresentation()
        {
            var temp = "";
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                switch (tryte[i].Value)
                {
                    case Trit.TritVal.n:
                        temp += "-";
                        break;
                    case Trit.TritVal.p:
                        temp += "+";
                        break;
                    case Trit.TritVal.z:
                        temp += "0";
                        break;
                    default:
                        break;
                }
            }
            return temp;
        }

        public Tryte SHIFTLEFT(int nTrits)
        {
            if (nTrits <= N_TRITS_PER_TRYTE)
            {
                var temp = new Trit[N_TRITS_PER_TRYTE];
                //Array.Copy(this.tryte, nTrits, temp, 0, N_TRITS_PER_TRYTE - nTrits);
                for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
                {
                    if (i >= N_TRITS_PER_TRYTE - nTrits)
                    {
                        temp[i] = new Trit(0);
                    }
                    else
                    {
                        temp[i] = tryte[i + nTrits];
                    }
                }
                return new Tryte(temp);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of trits to shift left is too large for a tryte of " + N_TRITS_PER_TRYTE + " trits", "nTrits");
            }
        }

        public Tryte SHIFTRIGHT(int nTrits)
        {
            if (nTrits <= N_TRITS_PER_TRYTE)
            {
                var temp = new Trit[N_TRITS_PER_TRYTE];
                //Array.Copy(this.tryte, 0, temp, nTrits, N_TRITS_PER_TRYTE - nTrits);
                for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
                {
                    if (i < nTrits)
                    {
                        temp[i] = new Trit(0);
                    }
                    else
                    {
                        temp[i] = tryte[i - nTrits];
                    }
                }
                return new Tryte(temp);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of trits to shift right is too large for a tryte of " + N_TRITS_PER_TRYTE + " trits", "nTrits");
            }
        }

        public Tryte MOD(Tryte t)
        {
            return new Tryte((short)(this.shortValue % t.shortValue));
        }

        public Tryte DIV(Tryte t)
        {
            if (t.shortValue == 0)
            {
                throw new DivideByZeroException("Attempt to divide by zero in Tryte division operation");
            }
            else
            {
                return new Tryte((short)(this.shortValue / t.shortValue));
            }
        }

        public Tryte SUB(Tryte t)
        {
            int temp = this.shortValue - t.ShortValue;
            if (temp > MaxValue || temp < MinValue)
            {
                throw new OverflowException("Integer subtraction resulted in an overflow - result too big for a tryte with " + N_TRITS_PER_TRYTE + " trits");
            }
            else
            {
                return new Tryte((short)temp);
            }
        }

        public Tryte MULT(Tryte t)
        {
            int temp = this.shortValue * t.shortValue;
            if (temp > MaxValue || temp < MinValue)
            {
                throw new OverflowException("Integer multiplication resulted in an overflow - result too big for a tryte with " + N_TRITS_PER_TRYTE + " trits");
            }
            else
            {
                return new Tryte((short)temp);
            }
        }

        public Tryte SUM(Tryte t)
        {
            int temp = this.shortValue + t.shortValue;
            if (temp > MaxValue || temp < MinValue)
            {
                throw new OverflowException("Integer addition resulted in an overflow - result too big for a tryte with " + N_TRITS_PER_TRYTE + " trits");
            }
            else
            {
                return new Tryte((short)temp);
            }
        }

        public Tryte AND(Tryte t)
        {
            var newTryte = new Tryte(0);
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                newTryte.tryte[i] = this.tryte[i] & t.tryte[i];
            }
            return newTryte;
        }

        public Tryte OR(Tryte t)
        {
            var newTryte = new Tryte(0);
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                newTryte.tryte[i] = this.tryte[i] | t.tryte[i];
            }
            return newTryte;
        }

        /// <summary>
        /// Balanced Ternary Comparison operator method - returns 1 if tryte1 is larger, -1 if it is smaller, and 0 if the trytes are equal.
        /// Supposed to be used with the spaceship operator <=> but custom operators are not allowed in C#
        /// </summary>
        /// <param name="a">First Tryte to be compared</param>
        /// <param name="b">Second Tryte to be compared</param>
        /// <returns>Returns a Trit of value 1, 0, or -1</returns>
        public static Trit COMPARISON(Tryte a, Tryte b)
        {
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                if (a.Value[i] > b.Value[i])
                {
                    return new Trit(1);
                }
                else if (a.Value[i] < b.Value[i])
                {
                    return new Trit(-1);
                }
            }
            return new Trit(0);
        }

        public Tryte Invert()
        {
            Trit[] newTryte = new Trit[N_TRITS_PER_TRYTE];
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                newTryte[i] = !tryte[i];
            }
            return new Tryte(newTryte);
        }

        public void InvertSelf()
        {
            for (int i = 0; i < N_TRITS_PER_TRYTE; i++)
            {
                tryte[i] = !tryte[i];
            }
            SetValue(tryte);
        }
    }


    /// <summary>
    /// The IntT struct is a modifiable general purpose Balanced Ternary integer, with an array of trits and a long for the values it holds.
    /// All the math is done in binary and converted to ternary. Trit-shifting is done in Ternary. Can be explicitly cast to a string of +, -, 0's
    /// </summary>
    public struct IntT
    {
        /// <summary>
        /// Static member defining the number of trits that make up the IntT
        /// </summary>
        public static byte N_TRITS_PER_INT = 24;
        /// <summary>
        /// Maximum representable number given a particular N_TRITS_PER_INT
        /// </summary>
        public static long MaxValue = (long)(Math.Pow(3, N_TRITS_PER_INT) - 1) / 2;
        /// <summary>
        /// Minimum (negative) representable number given a particular N_TRITS_PER_INT
        /// </summary>
        public static long MinValue = -MaxValue;
        /// <summary>
        /// The ternary representation of the value of the IntT as an array of Trits
        /// </summary>
        private Trit[] intt;
        /// <summary>
        /// The binary representation of the value of hte IntT as a long integer
        /// </summary>
        private long longValue;

        public Trit[] Value { get => intt; set => SetValue(value); }
        public string IntTString { get => ConvertToStringRepresentation(); }
        public long LongValue { get => longValue; set => SetValue(value); }

        public static bool operator ==(IntT left, IntT right) => EqualityComparer<Trit[]>.Default.Equals(left.Value, right.Value);
        public static bool operator !=(IntT left, IntT right) => !EqualityComparer<Trit[]>.Default.Equals(left.Value, right.Value);
        public static bool operator ==(IntT left, int right) => left.longValue == right;
        public static bool operator !=(IntT left, int right) => left.longValue != right;
        public static bool operator >(IntT left, IntT right) => left.longValue > right.longValue;
        public static bool operator <(IntT left, IntT right) => left.longValue < right.longValue;
        public static bool operator >=(IntT left, IntT right) => left.longValue >= right.longValue;
        public static bool operator <=(IntT left, IntT right) => left.longValue <= right.longValue;
        public static bool operator >(IntT left, int right) => left.longValue > right;
        public static bool operator <(IntT left, int right) => left.longValue < right;
        public static bool operator >=(IntT left, int right) => left.longValue >= right;
        public static bool operator <=(IntT left, int right) => left.longValue <= right;
        public static IntT operator +(IntT left, IntT right) => new IntT(left.longValue + right.longValue);
        public static IntT operator -(IntT left, IntT right) => new IntT(left.longValue - right.longValue);
        public static IntT operator *(IntT left, IntT right) => new IntT(left.longValue * right.longValue);
        public static IntT operator /(IntT left, IntT right) => new IntT(left.longValue / right.longValue);
        public static IntT operator %(IntT left, IntT right) => new IntT(left.longValue % right.longValue);
        public static IntT operator <<(IntT intt, int nTrits) => intt.SHIFTLEFT(nTrits);
        public static IntT operator >>(IntT intt, int nTrits) => intt.SHIFTRIGHT(nTrits);
        public static IntT operator ++(IntT intt) => new IntT(intt.longValue + 1);
        public static IntT operator --(IntT intt) => new IntT(intt.longValue - 1);
        public static IntT operator +(IntT intt) => new IntT(Math.Abs(intt.longValue));
        public static IntT operator -(IntT intt) => new IntT(-intt.longValue);
        public static implicit operator long(IntT intt) => (intt <= long.MaxValue && intt >= long.MinValue) ? intt.longValue : throw new ArithmeticException("Converting a IntT to a long value failed because it was outside the range of the long max/min values");
        public static implicit operator IntT(long @int) => (@int <= MaxValue && @int >= MinValue) ? new IntT(@int) : throw new ArithmeticException("Converting a long value to a IntT failed because it was outside the range of the IntT implementation");
        public static implicit operator int(IntT intt) => (intt <= int.MaxValue && intt >= int.MinValue) ? (int)intt.longValue : throw new ArithmeticException("Converting a IntT to an int failed because the value was outside the range of the int max/min values");
        public static implicit operator IntT(int @int) => (@int <= MaxValue && @int >= MinValue) ? new IntT(@int) : throw new ArithmeticException("Converting an int value to a IntT failed because it was outside the range of the IntT implementation");
        //public static implicit operator short(IntT intt) => (intt <= short.MaxValue && intt >= short.MinValue) ? (short)intt.longValue : throw new ArithmeticException("Converting a IntT to a short failed because the value was outside the range of the short max/min values");
        //public static implicit operator IntT(short @int) => (@int <= MaxValue && @int >= MinValue) ? new IntT(@int) : throw new ArithmeticException("Converting a short value to a IntT failed because it was outside the range of the IntT implementation");
        public static explicit operator string(IntT intt) => intt.IntTString;
        public static explicit operator IntT(string str) => new IntT(str);
        public static explicit operator double(IntT intt) => intt.longValue;

        /// <summary>
        /// Constructor for the IntT struct, taking an array of Trits
        /// </summary>
        /// <param name="value">The value passed in as an array of Trits</param>
        public IntT(Trit[] value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                intt = value;
                longValue = ConvertBalancedTritsToInteger(value);
            }
            else
            {
                throw new ArgumentException("Trit array passed to IntT SetValue method was not the expected size - should be " + N_TRITS_PER_INT + " trits in length", "value");
            }
        }

        /// <summary>
        /// Constructor for the IntT struct, taking an array of chars (0, +, -)
        /// </summary>
        /// <param name="value">The value passed in as an array of chars (0, +, -)</param>
        public IntT(string value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                intt = new Trit[N_TRITS_PER_INT];
                for (int i = 0; i < N_TRITS_PER_INT; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            intt[i] = new Trit(1);
                            break;
                        case '-':
                            intt[i] = new Trit(-1);
                            break;
                        case '0':
                            intt[i] = new Trit(0);
                            break;
                        default:
                            throw new ArgumentException("Invalid character encountered in a balanced ternary char array. Please stick to +, -, 0's", "value");
                    }
                }
                longValue = ConvertBalancedTritsToInteger(intt);
            }
            else
            {
                throw new ArgumentException("Char array passed to IntT SetValue method was not the expected size - should be " + N_TRITS_PER_INT + " chars in length", "value");
            }
        }

        /// <summary>
        /// Constructor for the IntT struct, taking a long binary integer
        /// </summary>
        /// <param name="value">The value passed in, as a long binary integer</param>
        public IntT(long value)
        {
            longValue = value;
            intt = ConvertIntegerToBalancedTrits(value);
        }

        public string ConvertToStringRepresentation()
        {
            var temp = "";
            for (int i = 0; i < N_TRITS_PER_INT; i++)
            {
                switch (this.intt[i].Value)
                {
                    case Trit.TritVal.n:
                        temp += "-";
                        break;
                    case Trit.TritVal.p:
                        temp += "+";
                        break;
                    case Trit.TritVal.z:
                        temp += "0";
                        break;
                    default:
                        break;
                }
            }
            return temp;
        }

        public override string ToString()
        {
            return IntTString + " which equals " + longValue;
        }

        public override bool Equals(object obj)
        {
            return obj is IntT @int &&
                   EqualityComparer<Trit[]>.Default.Equals(intt, @int.intt);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(intt);
        }

        public void SetValue(Trit[] value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                intt = value;
                longValue = ConvertBalancedTritsToInteger(value);
            }
            else
            {
                throw new ArgumentException("Trit array passed to IntT SetValue method was not the expected size - should be " + N_TRITS_PER_INT + " trits in length", "value");
            }
        }

        public void SetValue(long value)
        {
            if (value <= MaxValue && value >= MinValue)
            {
                longValue = value;
                intt = ConvertIntegerToBalancedTrits(value);
            }
            else
            {
                throw new ArgumentOutOfRangeException("value", "Long integer value passed to IntT SetValue too large for a IntT of size " + N_TRITS_PER_INT + " trits.");
            }
        }

        public void SetValue(string value)
        {
            if (value.Length == N_TRITS_PER_INT)
            {
                for (int i = 0; i < N_TRITS_PER_INT; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            intt[i] = new Trit(1);
                            break;
                        case '-':
                            intt[i] = new Trit(-1);
                            break;
                        case '0':
                            intt[i] = new Trit(0);
                            break;
                        default:
                            throw new ArgumentException("Invalid character encountered in a balanced ternary char array. Please stick to +, -, 0's", "value");
                    }
                }
                longValue = ConvertBalancedTritsToInteger(intt);
            }
            else
            {
                throw new ArgumentException("Char array passed to IntT SetValue method was not the expected size - should be " + N_TRITS_PER_INT + " chars in length", "value");
            }
        }

        public static long ConvertBalancedTritsToInteger(Trit[] trits)
        {
            long sum = 0;
            short exponent = (short)(N_TRITS_PER_INT - 1);
            foreach (var trit in trits)
            {
                sum += (long)((sbyte)trit.Value * Math.Pow(3, exponent));   //exponent increases as the invisible index increases, and adds to the sum if the trit is -1 or 1
                exponent--;
            }
            return sum;
        }

        public static Trit[] ConvertIntegerToBalancedTrits(long intValue)
        {
            Trit[] trits = new Trit[N_TRITS_PER_INT];
            long workValue = Math.Abs(intValue);     //easier to work with a positive number...
            byte i = 0;     //easier to start with index 0 - greater numbers on the right
            while (workValue != 0)
            {
                switch (workValue % 3)
                {
                    case 0:
                        trits[i] = new Trit(0);
                        break;
                    case 1:
                        trits[i] = new Trit(1);
                        break;
                    case 2:
                        trits[i] = new Trit(-1);
                        break;
                }
                workValue = (workValue + 1) / 3;
                i++;
            }
            for (int j = i; j < N_TRITS_PER_INT; j++)
            {
                trits[j] = new Trit(0);   //...add zeros to fill in to make the length match the N_TRITS_PER_INT static value
            }
            if (intValue < 0)   //...and invert if it was negative
            {
                for (int n = 0; n < N_TRITS_PER_INT; n++)
                {
                    trits[n] = !trits[n];
                }
            }
            Array.Reverse(trits);    //...and reverse the trit order so greater numbers are on the left
            return trits;
        }

        /// <summary>
        /// A Balanced Ternary Comparison Operator Method that returns 1 if a is larger, -1 if a is smaller, and 0 if the ints are equal.
        /// Supposed to be used with the spaceship operator <=> but C# does not support custom operators.
        /// </summary>
        /// <param name="a">The first IntT to be compared</param>
        /// <param name="b">The second IntT to be compared</param>
        /// <returns>The Trit containing a value of 1, -1, or 0 depending on the comparison</returns>
        public static Trit COMPARISON(IntT a, IntT b)
        {
            for (byte i = 0; i < N_TRITS_PER_INT; i++)
            {
                if (a.intt[i] > b.intt[i])
                {
                    return new Trit(1);
                }
                else if (a.intt[i] < b.intt[i])
                {
                    return new Trit(-1);
                }
            }
            return new Trit(0);
        }

        public IntT SHIFTLEFT(int nTrits)
        {
            if (nTrits <= N_TRITS_PER_INT)
            {
                var temp = new Trit[N_TRITS_PER_INT];
                //Array.Copy(this.balInt, nTrits, temp, 0, N_TRITS_PER_INT - nTrits);
                for (byte i = 0; i < N_TRITS_PER_INT; i++)
                {
                    if (i >= N_TRITS_PER_INT - nTrits)
                    {
                        temp[i] = new Trit(0);
                    }
                    else
                    {
                        temp[i] = intt[i + nTrits];
                    }
                }
                return new IntT(temp);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of trits to shift left is too large for a IntT of " + N_TRITS_PER_INT + " trits", "nTrits");
            }
        }

        public IntT SHIFTRIGHT(int nTrits)
        {
            if (nTrits <= N_TRITS_PER_INT)
            {
                var temp = new Trit[N_TRITS_PER_INT];
                //Array.Copy(this.balInt, 0, temp, nTrits, N_TRITS_PER_INT - nTrits);
                for (byte i = 0; i < N_TRITS_PER_INT; i++)
                {
                    if (i < nTrits)
                    {
                        temp[i] = new Trit(0);
                    }
                    else
                    {
                        temp[i] = intt[i - nTrits];
                    }
                }
                return new IntT(temp);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Number of trits to shift right is too large for a IntT of " + N_TRITS_PER_INT + " trits", "nTrits");
            }
        }

        public IntT ADD(IntT addBalInt)
        {
            Trit[] sumBalTrits = new Trit[N_TRITS_PER_INT];
            sbyte carry = 0;
            for (int i = N_TRITS_PER_INT - 1; i >= 0; i--)
            {
                sbyte n = (sbyte)((sbyte)this.intt[i].Value + (sbyte)addBalInt.Value[i].Value + carry);
                switch (n)
                {
                    case 2:
                        carry = 1;
                        sumBalTrits[i] = -1;
                        break;
                    case -2:
                        carry = -1;
                        sumBalTrits[i] = 1;
                        break;
                    case 3:
                        carry = 1;
                        sumBalTrits[i] = 0;
                        break;
                    case -3:
                        carry = -1;
                        sumBalTrits[i] = 0;
                        break;
                    default:
                        carry = 0;
                        sumBalTrits[i] = n;
                        break;
                }
            }
            switch (carry)
            {
                case 0:
                    return new IntT(sumBalTrits);
                case 1:
                    Console.WriteLine("Integer Add Overflow! Returning maximum positive integer");
                    return MaxValue;
                case -1:
                    Console.WriteLine("Integer Add Underflow! Returning maximum negative integer.");
                    return MinValue;
                default:
                    return new IntT(sumBalTrits);
            }
        }

    }



    /// <summary>
    /// The BalFloat struct is a modifiable general purpose Balanced Ternary floating point number with trits and a double. Can be customized
    /// by changing the N_TRITS_TOTAL static parameter, and the fractions in the N_TRITS_SIGNIFICAND and N_TRITS_EXPONENT static parameters.
    /// </summary>
    public struct FloatT
    {
        /// <summary>
        /// The total number of trits used by the BalFloat - 27 is a nice number
        /// </summary>
        public static byte N_TRITS_TOTAL_FLOAT = 24;
        /// <summary>
        /// The number of trits used for the significand in the BalFloat - the precision. Currently set to 3/4 of the total trits rounded up.
        /// </summary>
        public static byte N_TRITS_SIGNIFICAND = (byte)Math.Ceiling((double)N_TRITS_TOTAL_FLOAT * 3 / 4);
        /// <summary>
        /// The number of trits used for the exponent in the BalFloat - the magnitude. Currently set to 1/4 of the total trits rounded down.
        /// </summary>
        public static byte N_TRITS_EXPONENT = (byte)Math.Floor((double)N_TRITS_TOTAL_FLOAT / 4);
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

        /// <summary>
        /// The exponent component of the BalFloat as an array of BalTrits
        /// </summary>
        private Trit[] exponent;
        /// <summary>
        /// The significand component of the BalFloat as an array of BalTrits
        /// </summary>
        private Trit[] significand;
        /// <summary>
        /// The whole BalFloat value as an array of BalTrits
        /// </summary>
        private Trit[] floatt;
        /// <summary>
        /// The BalFloat value represented as a binary double
        /// </summary>
        private double doubleValue;

        public double DoubleValue { get => doubleValue; set => SetValue(value); }   //when we modify the three value types, they are calling the appropriate SetValue function for that type
        public Trit[] Value { get => floatt; set => SetValue(value); }
        public string FloatTString { get => ConvertToStringRepresentation(); }

        public static bool operator ==(FloatT left, FloatT right) => EqualityComparer<Trit[]>.Default.Equals(left.Value, right.Value);
        public static bool operator !=(FloatT left, FloatT right) => !EqualityComparer<Trit[]>.Default.Equals(left.Value, right.Value);
        public static bool operator >(FloatT left, FloatT right) => left.GREATERTHAN(right);
        public static bool operator <(FloatT left, FloatT right) => left.LESSTHAN(right);
        public static bool operator >=(FloatT left, FloatT right) => left.GREATEROREQUAL(right);
        public static bool operator <=(FloatT left, FloatT right) => left.LESSOREQUAL(right);
        public static FloatT operator +(FloatT left, FloatT right) => new FloatT(left.doubleValue + right.doubleValue);
        public static FloatT operator -(FloatT left, FloatT right) => new FloatT(left.doubleValue - right.doubleValue);
        public static FloatT operator *(FloatT left, FloatT right) => new FloatT(left.doubleValue * right.doubleValue);
        public static FloatT operator /(FloatT left, FloatT right) => new FloatT(left.doubleValue / right.doubleValue);
        public static FloatT operator %(FloatT left, FloatT right) => new FloatT(left.doubleValue % right.doubleValue);
        //public static BalFloat operator ++(BalFloat left) => new BalFloat(left.doubleValue += 1); 
        //public static BalFloat operator --(BalFloat left) => new BalFloat(left.doubleValue -= 1); //not sure if ++ or -- are appropriate for a floating point number
        public static FloatT operator +(FloatT floatt) => new FloatT(Math.Abs(floatt.doubleValue));
        public static FloatT operator -(FloatT floatt) => new FloatT(-floatt.doubleValue);

        public static implicit operator double(FloatT floatt) => floatt.DoubleValue;
        public static implicit operator FloatT(double doubleVal) => new FloatT(doubleVal);
        public static explicit operator string(FloatT floatt) => floatt.FloatTString;
        public static explicit operator FloatT(string str) => new FloatT(str);

        public override bool Equals(object obj) //just making sure I'm following all the rules and implementing an Equals function
        {
            return obj is FloatT @float &&
                   EqualityComparer<Trit[]>.Default.Equals(floatt, @float.floatt);
        }

        public override int GetHashCode()   //same with the hash code
        {
            return HashCode.Combine(floatt);
        }

        /// <summary>
        /// Constructor for BalFloat struct, passing in a double as the value to be converted to Ternary
        /// </summary>
        /// <param name="value">The double value to be converted to Ternary</param>
        public FloatT(double value)
        {
            floatt = new Trit[N_TRITS_TOTAL_FLOAT];
            exponent = new Trit[N_TRITS_EXPONENT];
            significand = new Trit[N_TRITS_SIGNIFICAND];
            if (value == 0 || Math.Abs(value) < FloatT.Epsilon)
            {
                doubleValue = 0;
                SetAllExponentTrits(-1);
                SetAllSignificandTrits(0);
            }
            else if (double.IsPositiveInfinity(value) || value > FloatT.MaxValue)  //special cases like infinity, neg infinity, NaN/undefined
            {
                doubleValue = double.PositiveInfinity;
                SetAllExponentTrits(1);
                SetAllSignificandTrits(1);
            }
            else if (double.IsNegativeInfinity(value) || value < FloatT.MinValue)
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
                floatt = new Trit[N_TRITS_TOTAL_FLOAT];
                for (byte i = 0; i < N_TRITS_EXPONENT; i++) //takes the exponent and significand (below) and puts them together into the whole balanced float, including chars +/-/0
                {
                    floatt[i] = exponent[i];
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)  // continues here with significand
                {
                    floatt[i] = significand[i - N_TRITS_EXPONENT];
                }
            }
        }

        /// <summary>
        /// Constructor for the BalFloat taking an array of BalTrits to be converted to binary
        /// </summary>
        /// <param name="value">The array of BalTrits to pass into the constructor</param>
        public FloatT(Trit[] value)
        {
            if (value.Length == N_TRITS_TOTAL_FLOAT)
            {
                floatt = value;
                exponent = new Trit[N_TRITS_EXPONENT];
                significand = new Trit[N_TRITS_SIGNIFICAND];
                for (byte i = 0; i < N_TRITS_EXPONENT; i++)
                {
                    exponent[i] = value[i];
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)
                {
                    significand[i - N_TRITS_EXPONENT] = value[i];
                }

                if (exponent.All(t => (sbyte)t.Value == 1))    //infinities and NaNs here
                {
                    if (significand.All(t => (sbyte)t.Value == 1))
                    {
                        doubleValue = double.PositiveInfinity;
                    }
                    else if (significand.All(t => (sbyte)t.Value == -1))
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
                else if (significand.All(t => t.Value == 0) && exponent.All(t => (sbyte)t.Value == -1))    //zero case
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
                throw new ArgumentException("Trit array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL_FLOAT + " trits in length", "value");
            }
        }

        /// <summary>
        /// A constructor passing in a string of +, - , and 0's and converting to trits and a double
        /// </summary>
        /// <param name="value">Character Array representing Balanced Ternary</param>
        public FloatT(string value)
        {
            if (value.Length == N_TRITS_TOTAL_FLOAT)
            {
                floatt = new Trit[N_TRITS_TOTAL_FLOAT];
                exponent = new Trit[N_TRITS_EXPONENT];
                significand = new Trit[N_TRITS_SIGNIFICAND];
                for (byte i = 0; i < N_TRITS_EXPONENT; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            exponent[i] = new Trit(1);
                            floatt[i] = new Trit(1);
                            break;
                        case '-':
                            exponent[i] = new Trit(-1);
                            floatt[i] = new Trit(-1);
                            break;
                        case '0':
                            exponent[i] = new Trit(0);
                            floatt[i] = new Trit(0);
                            break;
                        default:
                            throw new ArgumentException("Invalid character in ternary char array passed to SetValue. Please stick to +, -, 0", "value");
                    }
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)
                {
                    switch (value[i])
                    {
                        case '+':
                            significand[i - N_TRITS_EXPONENT] = new Trit(1);
                            floatt[i] = new Trit(1);
                            break;
                        case '-':
                            significand[i - N_TRITS_EXPONENT] = new Trit(-1);
                            floatt[i] = new Trit(-1);
                            break;
                        case '0':
                            significand[i - N_TRITS_EXPONENT] = new Trit(0);
                            floatt[i] = new Trit(0);
                            break;
                        default:
                            throw new ArgumentException("Invalid character in ternary char array passed to SetValue. Please stick to +, -, 0", "value");
                    }
                }

                if (exponent.All(t => (sbyte)t.Value == 1))    //infinities and NaNs here
                {
                    if (significand.All(t => (sbyte)t.Value == 1))
                    {
                        doubleValue = double.PositiveInfinity;
                    }
                    else if (significand.All(t => (sbyte)t.Value == -1))
                    {
                        doubleValue = double.NegativeInfinity;
                    }
                    else if (significand.All(t => (sbyte)t.Value == 0))
                    {
                        doubleValue = double.NaN;
                    }
                    else
                    {
                        doubleValue = 0;
                    }
                }
                else if (significand.All(t => t.Value == 0) && exponent.All(t => (sbyte)t.Value == -1))    //zero case
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
                throw new ArgumentException("Char array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL_FLOAT + " chars in length", "value");
            }
        }

        public string ConvertToStringRepresentation()
        {
            var temp = "";
            for (byte i = 0; i < N_TRITS_TOTAL_FLOAT; i++)
            {
                switch (floatt[i].Value)
                {
                    case Trit.TritVal.n:
                        temp += "-";
                        break;
                    case Trit.TritVal.p:
                        temp += "+";
                        break;
                    case Trit.TritVal.z:
                        temp += "0";
                        break;
                    default:
                        break;
                }
            }
            return temp;
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
        /// Returns 0 if the two floats are equal, 1 if a is larger, and -1 if a float is smaller.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns>A Trit with value of 1, -1, or 0 based on the comparison</returns>
        public static Trit COMPARISON(FloatT a, FloatT b)
        {
            for (byte i = 0; i < N_TRITS_TOTAL_FLOAT; i++)
            {
                if (a.floatt[i] > b.floatt[i])
                {
                    return new Trit(1);
                }
                else if (a.floatt[i] < b.floatt[i])
                {
                    return new Trit(-1);
                }
            }
            //for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
            //{
            //    if (a.significand[i] > b.significand[i])
            //    {
            //        return new Trit(1);
            //    }
            //    else if (a.significand[i] < b.significand[i])
            //    {
            //        return new Trit(-1);
            //    }
            //}
            return new Trit(0);
        }

        public bool LESSOREQUAL(FloatT f)
        {
            for (byte i = 0; i < N_TRITS_TOTAL_FLOAT; i++)  //first checks the exponent
            {
                if (this.floatt[i] < f.floatt[i]) //the first time we encounter one being less than the other, return true
                {
                    return true;
                }
                else if (this.floatt[i] > f.floatt[i])  //the first time we encounter one being greater than the other, return false
                {
                    return false;
                }
            }
            //for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)   //same with the significand
            //{
            //    if (significand[i] < balFloat.significand[i])
            //    {
            //        return true;
            //    }
            //    else if (significand[i] > balFloat.significand[i])
            //    {
            //        return false;
            //    }
            //}
            return true;    //if everything was equal, return true
        }

        public bool GREATEROREQUAL(FloatT f)   //same thing for greater than or equal to
        {
            for (byte i = 0; i < N_TRITS_TOTAL_FLOAT; i++)
            {
                if (this.floatt[i] > f.floatt[i])
                {
                    return true;
                }
                else if (this.floatt[i] < f.floatt[i])
                {
                    return false;
                }
            }
            //for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
            //{
            //    if (significand[i] > balFloat.significand[i])
            //    {
            //        return true;
            //    }
            //    else if (significand[i] < balFloat.significand[i])
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        public bool LESSTHAN(FloatT f)     //same thing for less than except...
        {
            for (byte i = 0; i < N_TRITS_TOTAL_FLOAT; i++)
            {
                if (this.floatt[i] < f.floatt[i])
                {
                    return true;
                }
                else if (this.floatt[i] > f.floatt[i])
                {
                    return false;
                }
            }
            //for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
            //{
            //    if (significand[i] < balFloat.significand[i])
            //    {
            //        return true;
            //    }
            //    else if (significand[i] > balFloat.significand[i])
            //    {
            //        return false;
            //    }
            //}
            return false;   //...we return false if they're equal
        }

        public bool GREATERTHAN(FloatT f)  //same thing for greater than
        {
            for (byte i = 0; i < N_TRITS_TOTAL_FLOAT; i++)
            {
                if (this.floatt[i] > f.floatt[i])
                {
                    return true;
                }
                else if (this.floatt[i] < f.floatt[i])
                {
                    return false;
                }
            }
            //for (byte i = 0; i < N_TRITS_SIGNIFICAND; i++)
            //{
            //    if (significand[i] > balFloat.significand[i])
            //    {
            //        return true;
            //    }
            //    else if (significand[i] < balFloat.significand[i])
            //    {
            //        return false;
            //    }
            //}
            return false;
        }

        public override string ToString()
        {
            return FloatTString + " which equals " + doubleValue;
        }

        private readonly void SetAllExponentTrits(sbyte t)
        {
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
            {
                floatt[i] = new Trit(t);
                exponent[i] = new Trit(t);
            }
        }

        private readonly void SetAllSignificandTrits(sbyte t)
        {
            for (int i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)
            {
                this.floatt[i] = new Trit(t);
                this.significand[i - N_TRITS_EXPONENT] = new Trit(t);
            }
        }

        public void SetAllExponentTritsTo(Trit trit) //set all the exponent trits to a particular trit value
        {
            for (byte i = 0; i < N_TRITS_EXPONENT; i++)
            {
                floatt[i] = new Trit(trit.Value);
                exponent[i] = new Trit(trit.Value);
            }
        }

        public void SetAllSignificandTritsTo(Trit trit)      //set all the signficand trits to a particular trit value
        {
            for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)
            {
                floatt[i] = new Trit(trit.Value);
                significand[i - N_TRITS_EXPONENT] = new Trit(trit.Value);
            }
        }

        public void SetValue(double value)
        {
            if (value == 0 || Math.Abs(value) < FloatT.Epsilon)
            {
                doubleValue = 0;
                SetAllExponentTritsTo(-1);
                SetAllSignificandTritsTo(0);
            }
            else if (double.IsPositiveInfinity(value) || value > FloatT.MaxValue)  //special cases like infinity, neg infinity, NaN/undefined
            {
                doubleValue = double.PositiveInfinity;
                SetAllExponentTritsTo(1);
                SetAllSignificandTritsTo(1);
            }
            else if (double.IsNegativeInfinity(value) || value < FloatT.MinValue)
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
                    floatt[i] = exponent[i];
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)  // continues here with significand
                {
                    floatt[i] = significand[i - N_TRITS_EXPONENT];
                }
            }
        }

        public void SetValue(Trit[] value)   //separates the whole balanced float into exponent and significand...
        {
            if (value.Length == N_TRITS_TOTAL_FLOAT)
            {
                floatt = value;
                for (byte i = 0; i < N_TRITS_EXPONENT; i++)
                {
                    exponent[i] = value[i];
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)
                {
                    significand[i - N_TRITS_EXPONENT] = value[i];
                }
                CreateDoubleValueIncludingSpecialCases();   //...and converts them into a double including infinities and NaNs
            }
            else
            {
                throw new ArgumentException("Trit array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL_FLOAT + " trits in length", "value");
            }
        }

        public void SetValue(string value)  // in case we're dealing with strings of +/-/0's this sets the trits to their appropriate values and...
        {
            if (value.Length == N_TRITS_TOTAL_FLOAT)
            {
                for (byte i = 0; i < N_TRITS_EXPONENT; i++)
                {
                    if (value[i] == '+')
                    {
                        exponent[i] = new Trit(1);
                        floatt[i] = new Trit(1);
                    }
                    else if (value[i] == '-')
                    {
                        exponent[i] = new Trit(-1);
                        floatt[i] = new Trit(-1);
                    }
                    else if (value[i] == '0')
                    {
                        exponent[i] = new Trit(0);
                        floatt[i] = new Trit(0);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid character in ternary char array passed to SetValue.", "value");
                    }
                }
                for (byte i = N_TRITS_EXPONENT; i < N_TRITS_TOTAL_FLOAT; i++)
                {
                    if (value[i] == '+')
                    {
                        significand[i - N_TRITS_EXPONENT] = new Trit(1);
                        floatt[i] = new Trit(1);
                    }
                    else if (value[i] == '-')
                    {
                        significand[i - N_TRITS_EXPONENT] = new Trit(-1);
                        floatt[i] = new Trit(-1);
                    }
                    else if (value[i] == '0')
                    {
                        significand[i - N_TRITS_EXPONENT] = new Trit(0);
                        floatt[i] = new Trit(0);
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
                throw new ArgumentException("Char array passed to BalFloat SetValue method was not the expected size - should be " + N_TRITS_TOTAL_FLOAT + " chars in length", "value");
            }
        }

        /// <summary>
        /// Creates a double value based on the exponent and significand and puts it in the doubleValue struct member.
        /// Takes into account special values like infinities and NaNs, and does so without needing to know how many
        /// total trits are involved - uses LINQ's All function.
        /// </summary>
        private void CreateDoubleValueIncludingSpecialCases()
        {
            if (exponent.All(t => (sbyte)t.Value == 1))    //infinities and NaNs here
            {
                if (significand.All(t => (sbyte)t.Value == 1))
                {
                    doubleValue = double.PositiveInfinity;
                }
                else if (significand.All(t => (sbyte)t.Value == -1))
                {
                    doubleValue = double.NegativeInfinity;
                }
                else if (significand.All(t => (sbyte)t.Value == 0))
                {
                    doubleValue = double.NaN;
                }
            }
            else if (significand.All(t => t.Value == 0) && exponent.All(t => (sbyte)t.Value == -1))    //zero case
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


        public static Trit[] ConvertIntegerToBalancedTrits(int integerValue, byte nTrits)
        {
            Trit[] balTrits = new Trit[nTrits];
            int workValue = Math.Abs(integerValue);     //easier to work with a positive number...
            if (workValue <= (int)((Math.Pow(3, nTrits) - 1) / 2))  //make sure the value passed in is within the nTrits passed maximum value
            {
                byte i = 0;
                while (workValue != 0)      //easier to start with index 0 - greater numbers on the right
                {
                    switch (workValue % 3)
                    {
                        case 0:
                            balTrits[i] = new Trit(0);
                            break;
                        case 1:
                            balTrits[i] = new Trit(1);
                            break;
                        case 2:
                            balTrits[i] = new Trit(-1);
                            break;
                    }
                    workValue = (workValue + 1) / 3;
                    i++;
                }
                for (byte j = i; j < nTrits; j++)
                {
                    balTrits[j] = new Trit(0);   //...add zeros to fill in to make the length match the nTrits passed in
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

        public static int ConvertBalancedTritsToInteger(Trit[] balTrits)
        {
            int sum = 0;
            short exponent = (short)(balTrits.Length - 1);
            foreach (var trit in balTrits)
            {
                sum += (int)((sbyte)trit.Value * Math.Pow(3, exponent));
                exponent--;
            }
            return sum;
        }

        public static double ConvertBalancedTritsToDouble(Trit[] balTrits)   //same idea here, except we're counting exponents from -1 to the smallest exponent allowed by the implementation
        {
            double sum = 0;
            int exponent = -1;
            foreach (var trit in balTrits)
            {
                sum += (sbyte)trit.Value * Math.Pow(3, exponent);  //exponents are negative, so it's like doing 1/3^n and adding them up
                exponent--;
            }
            return sum;
        }

        public static (Trit[], double) ConvertDoubleToBalancedTritsWithRemainder(double doubleValue, int nTrits) //converts double to BalTrits[]
        {
            var balTrits = new Trit[nTrits];
            var sum = doubleValue;  //start with the sum total
            for (int exponent = 1; exponent <= nTrits; exponent++)  //start with 1/3
            {
                var place = Math.Pow(3, -exponent);
                var diffNegative = Math.Abs(sum - -place);
                var diffPositive = Math.Abs(sum - +place);
                if ((diffNegative < diffPositive) && diffNegative < Math.Abs(sum))  //is the negative difference smaller? smaller than if it's a zero?
                {
                    sum -= -place;   //subtract negative from sum if negative was smaller
                    balTrits[exponent - 1] = new Trit(-1);
                }
                else if ((diffPositive < diffNegative) && diffPositive < Math.Abs(sum)) //is the positive difference smaller? smaller than if it's a zero?
                {
                    sum -= +place;    //subtract positive from sum if positive was smaller
                    balTrits[exponent - 1] = new Trit(1);
                }
                else
                {
                    balTrits[exponent - 1] = new Trit(0);    //if zero was smaller, fill in a zero
                }
            }
            return (balTrits, sum); //return the array of trits, as well as the remainder (how much of the double value was not considered by the ternary conversion)
        }

    }

}
