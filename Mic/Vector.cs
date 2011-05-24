using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mic.Util
{
    public struct Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        #region properties
        //Module
        public double M { get { return Math.Sqrt(X * X + Y * Y + Z * Z); } }
        //Theta
        //TODO: check formula
        public double Theta { get { double m = M; if (m == 0) return 0; return Math.Asin(X / m); } }
        //Phi
        //TODO: check formula
        public double Phi { get { double m = M; if (m == 0) return 0; return Math.Acos(Z / m); } }

        public static Vector UnitX { get { return new Vector { X = 1 }; } }
        public static Vector UnitY { get { return new Vector { Y = 1 }; } }
        public static Vector UnitZ { get { return new Vector { Z = 1 }; } }
        public static Vector NextRandomUnit
        {
            get
            {
                Random r = new Random();
                Vector v = new Vector { X = r.NextDouble(), Y = r.NextDouble(), Z = r.NextDouble() };
                return v.Normalize();
            }
        }
        #endregion properties

        #region operators
        //Negat
        public static Vector operator -(Vector a)
        {
            return new Vector { X = -a.X, Y = -a.Y, Z = -a.Z };
        }
        //Minus
        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector { X = a.X - b.X, Y = a.Y - b.Y, Z = a.Z - b.Z };
        }
        //Plus
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector { X = a.X + b.X, Y = a.Y + b.Y, Z = a.Z + b.Z };
        }
        //Product
        public static double operator *(Vector a, Vector b)
        {
            return a.X * b.X + a.Y * b.Y + a.Z * b.Z;
        }
        //Cross
        public static Vector operator ^(Vector a, Vector b)
        {
            return new Vector { X = a.Y * b.Z - a.Z * b.Y, Y = a.X * b.Z - a.Z * b.X, Z = a.X * b.Y - a.Y * b.X };
        }
        //Multiply
        public static Vector operator *(Vector a, double d)
        {
            return new Vector { X = d * a.X, Y = d * a.Y, Z = d * a.Z };
        }
        //Normalize
        public Vector Normalize()
        {
            double m = M;
            if (m != 0) { X /= m; Y /= m; Z /= m; }
            return this;
        }
        #endregion operators
        #region equality
        public override int GetHashCode()
        {
            return (int)(X.GetHashCode() * 31 ^ Y.GetHashCode() * 19 ^ Z.GetHashCode());
        }
        public override bool Equals(object obj)
        {
            if (obj is Vector)
            {
                Vector v = (Vector)obj;
                return X == v.X && Y == v.Y && Z == v.Z;
            }
            return false;
        }
        #endregion equality
        public override string ToString()
        {
            return String.Format("<Vector>({0}, {1}, {2})", X, Y, Z);
        }
    }
}
