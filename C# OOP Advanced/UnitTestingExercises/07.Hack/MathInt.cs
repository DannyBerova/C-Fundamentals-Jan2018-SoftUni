using System;

namespace _07.Hack
{
    public class MathInt : IMathAbs, IMathFloor
    {
        //public MathInt(int integer)
        //{
        //   this.Integer = integer;
        //}
        //public int Integer { get; set; }

        public double MathAbs(double value)
        {
            var result = Math.Abs(value);
            return result;
        }

        public double MathFloor(double value)
        {
            var result = Math.Floor(value);
            return result;
        }
    }
}
