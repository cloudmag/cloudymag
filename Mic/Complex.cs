using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mic
{
    public struct Complex
    {
        #region properties
        public double R { get; set; }
        public double I { get; set; }
        public double M { get { return Math.Sqrt(I * I + R * R); } }
        #endregion properties

        #region operators
        public static implicit operator Complex(double d) { return new Complex { R=d }; }

        //Negat
        public static Complex operator -(Complex c)
        {
            return new Complex { R = -c.R, I = -c.I };
        }
        //Minus
        public static Complex operator -(Complex a, Complex b)
        {
            return new Complex { R = a.R - b.R, I = a.I - b.I }; 
        }
        //Plus
        public static Complex operator +(Complex a, Complex b)
        {
            return new Complex { R = a.R + b.R, I = a.I + b.I };
        }
        //Multiple
        public static Complex operator *(Complex a, double b)
        {
            return new Complex { R = a.R * b.I, I = a.I * b.I };
        }

        #endregion operators
    }
}
