using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace SpaceMiner
{
    public static class HelperFuncs
    {
        public const float deg2Rad = MathF.PI / 180;
        public const float rad2Deg = 180 / MathF.PI;

        public static float degreesToRadians(this float deg)
        {
            return deg * deg2Rad;
        }
        public static float radiansToDegrees(this float rad)
        {
            return rad * rad2Deg;
        }

        /// <summary>
        /// Gets amount of items in a 2D array
        /// </summary>
        /// <typeparam name="T">2D Array type</typeparam>
        /// <param name="arr">Array</param>
        /// <returns>2D array size</returns>
        public static int ArraySize2D<T>(T[][] arr)
        {
            int size = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                size += arr[i].Length;
            }
            return size;
        }

        /// <summary>
        /// Generate random number in range
        /// </summary>
        /// <param name="from">Min random number</param>
        /// <param name="to">Max random number</param>
        /// <returns>Random number in min-max range</returns>
        public static int RandomRange(int from, int to)
        {
            Random r = new Random();
            return r.Next(from, to);
        }

        public static Vector3 ToVector3(this Vector2 v2)
        {
            return new Vector3(v2.X, v2.Y, 0);
        }
        public static Vector2 ToVector2(this Vector3 v3)
        {
            return new Vector2(v3.X, v3.Y);
        }

        public static float GetAngle(Vector2 from, Vector2 to)
        {
            return MathF.Atan2(from.Y - to.Y, from.X - to.X);
        }
    }
}
