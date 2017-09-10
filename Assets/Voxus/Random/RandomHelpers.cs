using UnityEngine;

namespace Voxus.Random
{
    /// <summary>
    /// Random helpers
    /// </summary>
    public static class RandomHelpers
    {
        /// <summary>
        /// Return a number between min (inclusive) and max (exclusive)
        /// </summary>
        /// <param name="random">A random number between 0 and 1 (exclusive)</param>
        /// <param name="min">The inclusive minimum of the range</param>
        /// <param name="max">The exclusive maximum of the range</param>
        /// <returns>A random number between min (inclusive) and max (exclusive)</returns>
        public static int Range(float random, int min, int max)
        {
            return (int)(random * (max - min)) + min;
        }

        /// <summary>
        /// Convert two linearly distributed numbers between 0 and 1 to a point on a unit sphere (radius = 1)
        /// </summary>
        /// <param name="random1">Linearly distributed random number between 0 and 1</param>
        /// <param name="random2">Linearly distributed random number between 0 and 1</param>
        /// <returns>A cartesian point on the unit sphere</returns>
        public static Vector3 OnUnitSphere(float random1, float random2)
        {
            var theta = random1 * 2 * Mathf.PI;
            var phi = Mathf.Acos((2 * random2) - 1);

            // Convert from spherical coordinates to Cartesian
            var sinPhi = Mathf.Sin(phi);

            var x = sinPhi * Mathf.Cos(theta);
            var y = sinPhi * Mathf.Sin(theta);
            var z = Mathf.Cos(phi);

            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Get a random point on a unit sphere (radius = 1)
        /// </summary>
        /// <param name="randomGenerator">Linearl random number generator</param>
        /// <returns>A cartesian point on the unit sphere</returns>
        public static Vector3 OnUnitSphere(RandomLinear randomGenerator)
        {
            var random1 = randomGenerator.Get();
            var random2 = randomGenerator.Get();

            return OnUnitSphere(random1, random2);
        }
    }
}
