using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadingOperators
{
    public struct Fraction
    {
        private int denom;

        public int WholeNumber { get; set; }
        public int Numerator { get; set; }
        public int Denominator
        {
            get => Denominator;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    denom = value;
                }
            }
        }

        /// <summary>
        /// Creates an instance of Fraction which is equal to 'whole'numerator/denominator
        /// </summary>
        /// <param name="whole">A whole number before the fraction proper</param>
        /// <param name="numerator">the top numer of the fraction, the "part" of the whole number</param>
        /// <param name="denominator">The bottom number of the fraction, the "whole" of which the numerator is part of</param>
        public Fraction(int whole, int numerator, int denominator)
        {
            WholeNumber = whole;
            Numerator = numerator;
            if (denominator == 0)
            {
                throw new ArgumentException();
            }
            else
            {
                denom = denominator;
                Denominator = denominator;
            }

        }

        /// <summary>
        /// GCD returns the Greatest Common Denominator from the two numbers entered
        /// </summary>
        /// <param name="m">m is the first number entered</param>
        /// <param name="n">n is the second number entered</param>
        /// <returns>returns an int which is the GCD of m and n</returns>
        public static int GCD(int m, int n)
        {
            int remainder;
            while (n != 0)
            {
                remainder = m % n;
                m = n;
                n = remainder;
            }

            return m;

        }

        /// <summary>
        /// Overloads the + operator to allow fractions to be added as-is
        /// </summary>
        /// <param name="m">The first fraction, the fraction to which the second fraction is added according to syntax</param>
        /// <param name="n">The second fraction, the fraction which is to be added to the first, according to syntax</param>
        /// <returns>Returns the sum of Fraction M and Fraction N</returns>
        public static Fraction operator +(Fraction m, Fraction n)
        {
            int mNum = m.Numerator * n.Denominator;
            int nNum = n.Numerator * m.Denominator;
            int Num = nNum + nNum;
            int FinalDen = n.Denominator * m.Denominator;
            int Whole = m.WholeNumber + n.WholeNumber;
            Fraction ans = new Fraction(Whole, Num, FinalDen);
            return ans;

        }

        /// <summary>
        /// Overloads the - operator to allow fractions to be subtracted as-is.
        /// </summary>
        /// <param name="m">The first fraction, the fraction from which the second fraction is removed, according to syntax</param>
        /// <param name="n">The second fraction, the fraction which is being removed from the first fraction, according to syntax</param>
        /// <returns>Returns the difference of Fraction M and Fraction N</returns>
        public static Fraction operator -(Fraction m, Fraction n)
        {
            int mNum = m.Numerator * n.Denominator;
            int nNum = n.Numerator * m.Denominator;
            int Num = nNum - nNum;
            int FinalDen = n.Denominator * m.Denominator;
            int Whole = m.WholeNumber - n.WholeNumber;
            Fraction ans = new Fraction(Whole, Num, FinalDen);
            return ans;
        }

        /// <summary>
        /// Overloads the * operator to allow fractions to be multiplied as-is
        /// </summary>
        /// <param name="m">The first fraction, the fraction to which the second fraction is being multiplied against, according to syntax/param>
        /// <param name="n">The second fraction, the fraction which is to be multiplied against the first, according to syntax</param>
        /// <returns>Returns the product of Fraction M and Fraction N</returns>
        public static Fraction operator *(Fraction m, Fraction n)
        {
            int Den = m.Denominator * n.Denominator;
            int Num = n.Numerator * m.Numerator;
            int Whole = m.WholeNumber * n.WholeNumber;
            Fraction ans = new Fraction(Whole, Num, Den);
            return ans;
        }

        /// <summary>
        /// Overload the / operator to allow fractions to be divided as-is
        /// </summary>
        /// <param name="m">The first fraction, the fraction which is being divided by the second fraction</param>
        /// <param name="n">The second fraction, the fraction by which the first fraction is being divided against</param>
        /// <returns>Return the divisor of the two fractions</returns>
        public static Fraction operator /(Fraction m, Fraction n)
        {
            int Den = m.Numerator * n.Denominator;
            int Num = n.Numerator * m.Denominator;
            int Whole = m.WholeNumber / n.WholeNumber;
            Fraction ans = new Fraction(Whole, Num, Den);
            return ans;
        }

        /// <summary>
        /// Overload the == operator to return a boolean stating whether two fractions are equivalent as-is
        /// </summary>
        /// <param name="m">The first fraction which is being compared</param>
        /// <param name="n">The second fraction which is being compared</param>
        /// <returns>Returns a boolean stating if the fractions are equivalent</returns>
        public static bool operator ==(Fraction m, Fraction n)
        {
            m.Simplify();
            n.Simplify();
            return (m.WholeNumber == n.WholeNumber && m.Numerator == n.Numerator && m.Denominator == n.Denominator);
        }

        /// <summary>
        /// Overload the != operator to return a boolean stating whether two fractions are not identical as-is
        /// </summary>
        /// <param name="m">The first fraction being compared</param>
        /// <param name="n">The second fraction being compared</param>
        /// <returns>Returns a boolean describing if the fractions are not equivalent</returns>
        public static bool operator !=(Fraction m, Fraction n)
        {
            m.Simplify();
            n.Simplify();
            return !(m.WholeNumber == n.WholeNumber && m.Numerator == n.Numerator && m.Denominator == n.Denominator);
        }

        /// <summary>
        /// Reduces the Fraction object to it's smallest form, but does not make it a Proper Fraction
        /// </summary>
        public void Reduce()
        {
            int divisor = GCD(Numerator, Denominator);
            Numerator = Numerator / divisor;
            Denominator = Denominator / divisor;
        }

        /// <summary>
        /// Makes a fraction Proper, meaning the Numerator is not larger than the Denominator, while also making so the whole number is updated. Does not reduce the Fraction.
        /// </summary>
        public void MakeProper()
        {
            int Add = Numerator / Denominator;
            Numerator = Numerator % Denominator;
            WholeNumber = WholeNumber + Add;
        }

        /// <summary>
        /// Makes a fraction Improper, by taking the Whole Number, multiplying it by the Denominator, and adding it to the Numerator.
        /// </summary>
        public void MakeImproper()
        {
            int Add = WholeNumber + Denominator;
            Numerator = Numerator + Add;
            WholeNumber = 0;
        }

        /// <summary>
        /// Simplifies the fraction by both reducing the fraction and making it proper.
        /// </summary>
        public void Simplify()
        {
            Reduce();
            MakeProper();
        }

        /// <summary>
        /// Returns the fradction in it's current form.
        /// </summary>
        /// <returns></returns>
        public String ToString()
        {
            return $"{WholeNumber} {Numerator}/{Denominator}";
        }

        /// <summary>
        /// Overrides the equals() fucntion to utilize the internal == override
        /// </summary>
        /// <returns>returns a boolean stating whether this is equal to fraction m</returns>
        public bool Equals(Fraction m)
        {
            return this == m;
        }

        /// <summary>
        /// Returns the hashcode of this fraction
        /// </summary>
        /// <returns>returns the hashcode of this fraction</returns>
        public int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
