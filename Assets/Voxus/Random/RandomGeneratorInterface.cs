namespace Voxus.Random
{
    /// <summary>
    /// Interface for random number generators
    /// </summary>
    interface RandomGeneratorInterface
    {
        /// <summary>
        /// Get a random number
        /// </summary>
        /// <returns>A random number</returns>
        float Get();

        /// <summary>
        /// Set the base random number generator's seed value
        /// </summary>
        /// <param name="seed">The seed value (0 - 1)</param>
        void SetSeed(float seed);
    }
}
