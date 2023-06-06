using System;
using UnityEngine;


namespace Developed.Extentions
{
    public enum Relation
    {
        more, equal, less,
        moreOrEqual, lessOrEqual
    }


    public static class MathCustom
    {
        //TODO: Approximate comparison between floating point values

        /// <summary>
        /// The position of value relative to interval
        /// </summary>
        /// <param name="a">One side of interval</param>
        /// <param name="b">Other side of interval</param>
        /// <returns>Relative position, found by (value - min) / magnitude</returns>
        public static float IntervalRelativePosition(float value, float a, float b)
        {
            if (a == b)
                throw new ArgumentException("Interval length is close to 0!");

            var magnitude = Mathf.Abs(b - a);

            if (a < b)
                return (value - a) / magnitude;

            return (value - b) / magnitude;
        }


        /// <summary>
        /// Check if number is even or odd
        /// </summary>
        public static bool IsEvenNumber(this int value)
        {
            var isEvenInt = value & 1;

            return isEvenInt == 0;
        }


        /// <summary>
        /// Check if sentence "a (relation) b" is valid
        /// </summary>
        public static bool CheckRelation(int a, int b, Relation relation)
        {
            switch (relation)
            {
                case Relation.more:
                    return a > b;

                default:
                case Relation.equal:
                    return a == b;

                case Relation.less:
                    return a < b;

                case Relation.moreOrEqual:
                    return a >= b;

                case Relation.lessOrEqual:
                    return a <= b;
            }
        }

        /// <summary>
        /// Clamp value between a and b
        /// </summary>
        /// <returns>Provided value, clamped between a and b</returns>
        public static int ClampInterval(int value, int a, int b)
        {
            if (a < b)
                return Mathf.Clamp(value, a, b);
            if (a > b)
                return Mathf.Clamp(value, b, a);

            return a;
        }

        /// <summary>
        /// Clamp value between a and b
        /// </summary>
        /// <returns>Provided value, clamped between a and b</returns>
        public static float ClampInterval(float value, float a, float b)
        {
            if (a < b)
                return Mathf.Clamp(value, a, b);
            if (a > b)
                return Mathf.Clamp(value, b, a);

            return a;
        }


        /// <summary>
        /// Clamp each coordinate of provided Vector2 between two vectors
        /// </summary>
        /// <returns>Provided value, each coordinate clamped between a and b</returns>
        public static Vector2 ClampBetween(this Vector2 value, Vector2 a, Vector2 b)
        {
            return new Vector2(MathCustom.ClampInterval(value.x, a.x, b.x), MathCustom.ClampInterval(value.y, a.y, b.y));
        }


        /// <summary>
        /// Rotate vector on specified angle
        /// </summary>
        /// <param name="value">Vector to rotate</param>
        /// <param name="degrees">Angle in degrees</param>
        /// <returns>Rotated vector</returns>
        public static Vector2 Rotate(this ref Vector2 value, float degrees)
        {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);

            float xCurrent = value.x;
            float yCurrent = value.y;
            value.x = (cos * xCurrent) - (sin * yCurrent);
            value.y = (sin * xCurrent) + (cos * yCurrent);

            return value;
        }
    }
}