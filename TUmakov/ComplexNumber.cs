namespace TUmakov
{
    internal class ComplexNumber
    {
        public double valid { get; set; }
        public double imaginary { get; set; }

        public ComplexNumber(double valid, double imaginary)
        {
            this.valid = valid;
            this.imaginary = imaginary;
        }
        public static ComplexNumber operator +(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.valid + y.valid, x.imaginary + y.imaginary);
        }
        public static ComplexNumber operator -(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.valid - y.valid, x.imaginary - y.imaginary);
        }
        public static ComplexNumber operator *(ComplexNumber x, ComplexNumber y)
        {
            return new ComplexNumber(x.valid * y.valid - x.imaginary * y.imaginary, x.valid * y.imaginary + x.imaginary * y.valid);
        }
        public static bool operator ==(ComplexNumber x, ComplexNumber y)
        {
            return x.valid == y.valid & x.imaginary == y.imaginary;
        }
        public static bool operator !=(ComplexNumber x, ComplexNumber y)
        {
            return !(x == y);
        }
        public override int GetHashCode()
        {
            return valid.GetHashCode() ^ imaginary.GetHashCode(); // HashCode.Combine(valid, imaginary);
        }
        public override string ToString()
        {
            if (valid == 0)
                return $"{imaginary}i";
            else if (imaginary == 0)
                return $"{valid}";

            return $"{valid} + {imaginary}i";
        }
        public override bool Equals(object obj)
        {
            if (obj is ComplexNumber)
            {
                ComplexNumber other = (ComplexNumber)obj;
                return this == other;
            }
            return false;
        }
    }
}
