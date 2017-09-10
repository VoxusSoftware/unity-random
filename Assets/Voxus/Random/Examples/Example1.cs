using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Voxus.Random.Examples
{
    public class Example1 : MonoBehaviour
    {
        [Header("Graph Settings")]
        [SerializeField, Range(0.01f, 1)]
        private float graphPrecision = 0.1f;
        [SerializeField, Range(1000, 500000)]
        private int graphIterations = 100000;

        [Header("Linear Distribution")]
        [SerializeField, Range(-10, 10)]
        private float linearMin = 0;
        [SerializeField, Range(-10, 10)]
        private float linearMax = 10;

        [Header("Exponential Distribution")]
        [SerializeField, Range(-10, 10)]
        private float exponentialMin = 0;
        [SerializeField, Range(0.01f, 10)]
        private float exponentialLambda = 0.5f;

        [Header("Gaussian Distribution")]
        [SerializeField, Range(0, 10)]
        private float gaussianSigma = 1;
        [SerializeField, Range(-10, 10)]
        private float gaussianMu = 0;

        private float lastGraphPrecision;
        private float lastGraphIterations;

        private float lastLinearMin;
        private float lastLinearMax;

        private float lastExponentialMin;
        private float lastExponentialLambda;

        private float lastGaussianSigma;
        private float lastGaussianMu;

        private LineRenderer linearRenderer;
        private LineRenderer exponentialRenderer;
        private LineRenderer gaussianRenderer;

        private void Start()
        {
            linearRenderer = CreateGraph("Linear", Color.red);
            exponentialRenderer = CreateGraph("Exponential", Color.green);
            gaussianRenderer = CreateGraph("Gaussian", Color.blue);
        }

        private LineRenderer CreateGraph(string name, Color color)
        {
            var container = new GameObject(name);
            var lineRenderer = container.AddComponent<LineRenderer>();
            var material = new Material(Shader.Find("Transparent/Diffuse"));

            material.color = color;
            lineRenderer.widthMultiplier = 0.05f;
            lineRenderer.material = material;

            return lineRenderer;
        }

        private void Update()
        {
            var graphHasChanged = (lastGraphPrecision != graphPrecision) || (lastGraphIterations != graphIterations);
            var linearHasChanged = (lastLinearMin != linearMin) || (lastLinearMax != linearMax) || graphHasChanged;
            var exponentialHasChanged = (lastExponentialMin != exponentialMin) || (lastExponentialLambda != exponentialLambda) || graphHasChanged;
            var gaussianHasChanged = (lastGaussianSigma != gaussianSigma) || (lastGaussianMu != gaussianMu) || graphHasChanged;

            if (graphHasChanged)
            {
                lastGraphPrecision = graphPrecision;
                lastGraphIterations = graphIterations;
            }

            if (linearHasChanged)
            {
                DrawDistribution(new RandomLinear(linearMin, linearMax), linearRenderer);

                lastLinearMin = linearMin;
                lastLinearMax = linearMax;
            }

            if (exponentialHasChanged)
            {
                DrawDistribution(new RandomExponential(exponentialMin, exponentialLambda), exponentialRenderer);

                lastExponentialMin = exponentialMin;
                lastExponentialLambda = exponentialLambda;
            }

            if (gaussianHasChanged)
            {
                DrawDistribution(new RandomGaussian(gaussianSigma, gaussianMu), gaussianRenderer);

                lastGaussianSigma = gaussianSigma;
                lastGaussianMu = gaussianMu;
            }
        }

        private void DrawDistribution(RandomGeneratorInterface generator, LineRenderer lineRenderer)
        {
            var buckets = GetDistribution(generator);
            var positions = new List<Vector3>();
            var numBuckets = buckets.Count;
            var minX = buckets.Keys.Min() + 1;
            var maxX = buckets.Keys.Max() - 1;
            var maxY = (float)buckets.Values.Max();

            for (var i = minX; i < maxX; i++)
            {
                var y = buckets.ContainsKey(i) ? buckets[i] : 0f;

                positions.Add(new Vector3(i * graphPrecision, 10 * y / maxY, 0));
            }

            lineRenderer.positionCount = positions.Count;
            lineRenderer.SetPositions(positions.ToArray());
        }

        private Dictionary<int, int> GetDistribution(RandomGeneratorInterface generator)
        {
            var buckets = new Dictionary<int, int>();

            for (var i = 0; i < graphIterations; i++)
            {
                var bucket = Mathf.FloorToInt(generator.Get() / graphPrecision);

                if (!buckets.ContainsKey(bucket))
                {
                    buckets[bucket] = 0;
                }

                buckets[bucket]++;
            }

            return buckets;
        }
    }
}
