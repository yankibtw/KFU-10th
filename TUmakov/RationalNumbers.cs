using System;

namespace TUmakov
{
    internal class RationalNumbers
    {
        public int numerator;
        public int denominator;

        public RationalNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Знаменатель не может быть 0!!!");
            this.numerator = numerator;
            this.denominator = denominator;
            Simplify();
        }

        public static bool operator ==(RationalNumbers x, RationalNumbers y)
        {
            return x.Equals(y);
        }
        public static bool operator !=(RationalNumbers x, RationalNumbers y)
        {
            return !x.Equals(y);
        }
        public static RationalNumbers operator +(RationalNumbers x, RationalNumbers y)
        {
            return new RationalNumbers(x.numerator * y.denominator + x.denominator * y.numerator, x.denominator * y.denominator);
        }
        public static RationalNumbers operator -(RationalNumbers x, RationalNumbers y)
        {
            return new RationalNumbers(x.numerator * y.denominator - x.denominator * y.numerator, x.denominator * y.denominator);
        }
        public static RationalNumbers operator *(RationalNumbers x, RationalNumbers y)
        {
            return new RationalNumbers(x.numerator * y.numerator, x.denominator * y.denominator);
        }
        public static RationalNumbers operator /(RationalNumbers x, RationalNumbers y)
        {
            if (y.numerator == 0)
                throw new DivideByZeroException("Деление на ноль!!!");
            return new RationalNumbers(x.numerator * y.denominator, x.denominator * y.numerator);
        }
        public static RationalNumbers operator %(RationalNumbers x, RationalNumbers y)
        {
            if (y.numerator == 0)
                throw new DivideByZeroException("Деление на ноль!!!");
            return new RationalNumbers(((x.numerator * y.denominator) % (x.denominator * y.numerator)), x.denominator * y.denominator);
        }
        public static bool operator <(RationalNumbers x, RationalNumbers y)
        {
            return (x.numerator * y.denominator < x.denominator * y.numerator);
        }
        public static bool operator >(RationalNumbers x, RationalNumbers y)
        {
            return (x.numerator * y.denominator > x.denominator * y.numerator);
        }
        public static bool operator <=(RationalNumbers x, RationalNumbers y)
        {
            return (x.numerator * y.denominator <= x.denominator * y.numerator);
        }
        public static bool operator >=(RationalNumbers x, RationalNumbers y)
        {
            return (x.numerator * y.denominator >= x.denominator * y.numerator);
        }
        public static RationalNumbers operator ++(RationalNumbers x)
        {
            return x + new RationalNumbers(1, 1);
        }
        public static RationalNumbers operator --(RationalNumbers x)
        {
            return x - new RationalNumbers(1, 1);
        }
        public override string ToString()
        {
            if (numerator == denominator | numerator == 0)
            {
                return (numerator / denominator).ToString();
            }
            return $"{numerator}/{denominator}";
        }
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            RationalNumbers other = (RationalNumbers)obj;
            return numerator == other.numerator && denominator == other.denominator;
        }
        public override int GetHashCode()
        {
            return numerator.GetHashCode() ^ denominator.GetHashCode(); // HashCode.Combine(numerator, denominator);
        }

        public static implicit operator float(RationalNumbers rational)
        {
            return (float)rational.numerator / rational.denominator;
        }

        public static implicit operator int(RationalNumbers rational)
        {
            return rational.numerator / rational.denominator;
        }

        public static implicit operator RationalNumbers(float num)
        {
            int numerator = (int)(num * (int)Math.Pow(10, 10));
            return new RationalNumbers(numerator, (int)Math.Pow(10, 10));
        }
        private void Simplify()
        {
            int gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            numerator /= gcd;
            denominator /= gcd;

            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
