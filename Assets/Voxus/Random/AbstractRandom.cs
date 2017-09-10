using UnityEngine;
using UnityEngine.Assertions;

namespace Voxus.Random
{
    public abstract class AbstractRandom : RandomGeneratorInterface
    {
        /// <summary>
        /// The base random number generator
        /// </summary>
        protected System.Random random = new System.Random();

        /// <summary>
        /// Set the base random number generator's seed value (0 - 1)
        /// </summary>
        /// <param name="seed">The seed value (0 - 1)</param>
        public void SetSeed(float seed)
        {
            Assert.IsTrue((seed >= 0) && (seed <= 1), "Seed must be between 0 and 1");

            // -64 is a hack to account for floating-point inaccuracy
            var intSeed = Mathf.FloorToInt(seed * (System.Int32.MaxValue - 64));

            random = new System.Random(intSeed);
        }

        /// <summary>
        /// Get a random number
        /// </summary>
        /// <returns>A random number</returns>
        public abstract float Get();
    }
}
