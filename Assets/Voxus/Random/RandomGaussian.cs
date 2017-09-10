using UnityEngine;

namespace Voxus.Random
{
    /// <summary>
    /// Get a random number with a Gaussian distribution
    /// </summary>
    public class RandomGaussian : AbstractRandom
    {
        /// <summary>
        /// Standard deviation
        /// </summary>
        private float sigma;

        /// <summary>
        /// Mean (expectation) value
        /// </summary>
        private float mu;

        /// <summary>
        /// Generate random numbers with a Gaussian distribution
        /// See https://en.wikipedia.org/wiki/Normal_distribution
        /// </summary>
        /// <param name="sigma">The standard deviation</param>
        /// <param name="mu">The mean (expectation) value</param>
        public RandomGaussian(float sigma = 1, float mu = 0)
        {
            this.sigma = sigma;
            this.mu = mu;
        }

        /// <summary>
        /// Get a random number with a Gaussian distribution
        /// </summary>
        /// <returns>A random number</returns>
        public override float Get()
        {
            float x1, x2, w, y1; //, y2;

            do
            {
                x1 = 2f * (float)random.NextDouble() - 1f;
                x2 = 2f * (float)random.NextDouble() - 1f;
                w = x1 * x1 + x2 * x2;
            } while (w >= 1f);

            w = Mathf.Sqrt((-2f * Mathf.Log(w)) / w);
            y1 = x1 * w;
            // y2 = x2 * w;

            return (y1 * sigma) + mu;
        }
    }
}
