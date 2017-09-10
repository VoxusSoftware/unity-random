using UnityEngine;

namespace Voxus.Random
{
    /// <summary>
    /// Get a random number with an exponential distribution
    /// </summary>
    public class RandomExponential : AbstractRandom
    {
        /// <summary>
        /// The minimum value
        /// </summary>
        private float min;

        /// <summary>
        /// The rate parameter (1 / expectation)
        /// </summary>
        private float lambda;

        /// <summary>
        /// Get a random number with an exponential distribution
        /// See https://en.wikipedia.org/wiki/Exponential_distribution
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="lambda">Rate paramter (1 / expectation)</param>
        public RandomExponential(float min = 0, float lambda = 1)
        {
            this.min = min;
            this.lambda = lambda;
        }

        /// <summary>
        /// Get a random number with an exponential distribution
        /// </summary>
        /// <param name="random">A value between 0 and 1 to fit to the distribution</param>
        /// <returns>A random number</returns>
        public override float Get()
        {
            return min + (Mathf.Log(1 - (float)random.NextDouble()) / -lambda);
        }
    }
}
