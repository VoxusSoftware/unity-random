namespace Voxus.Random
{
    /// <summary>
    /// Get a random number with a linear distribution
    /// </summary>
    public class RandomLinear : AbstractRandom
    {
        /// <summary>
        /// The minimum value
        /// </summary>
        private float min;

        /// <summary>
        /// The maximum value
        /// </summary>
        private float max;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="min">The minimum value</param>
        /// <param name="max">The maximum value</param>
        public RandomLinear(float min, float max)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// Get a random number in the range specified in the constructor
        /// </summary>
        /// <returns>A random number</returns>
        public override float Get()
        {
            return ((float)random.NextDouble() * (max - min)) + min;
        }
    }
}
