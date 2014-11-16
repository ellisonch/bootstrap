using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap {
    public class Bootstrap {
        private static readonly Random random = new Random();

        // based on http://www.biostat.umn.edu/~will/6470stuff/Class21-12/Handout21.pdf
        public static double TwoSampleTTestInPlace(IList<double> x, IList<double> y, int iterations) {
            var xMean = MeanVariance.Calculate(x).Mean();
            var yMean = MeanVariance.Calculate(y).Mean();

            var targetT = CalculateT(x, y);

            // shift samples so they have means of 0
            var xPrime = ShiftDataInPlace(x, -xMean);
            var yPrime = ShiftDataInPlace(y, -yMean);

            var largerCount = 0;
            for (int i = 0; i < iterations; i++) {
                var sampSize = Math.Min(Math.Min(50, xPrime.Count()), yPrime.Count());
                var xSamp = SampleWithReplacement(xPrime, sampSize);
                var ySamp = SampleWithReplacement(yPrime, sampSize);

                var t = CalculateT(xSamp, ySamp);
                if (Math.Abs(t) >= Math.Abs(targetT)) {
                    largerCount++;
                }
            }

            return (1.0 * largerCount) / iterations;
        }

        private static double CalculateT(IList<double> samp1, IList<double> samp2) {
            // double x1, double x2, double s1, double s2, long n1, long n2;
            // var x1v1 = Statistics.MeanVariance(samp1);
            var x1v1 = MeanVariance.Calculate(samp1);
            var x1 = x1v1.Mean();
            var v1 = x1v1.Variance();
            var x2v2 = MeanVariance.Calculate(samp2);
            var x2 = x2v2.Mean();
            var v2 = x2v2.Variance();
            var n1 = samp1.Count;
            var n2 = samp2.Count;


            double denomBase = (v1 / n1) + (v2 / n2);
            double t = (x1 - x2) / Math.Sqrt(denomBase);

            return t;
        }

        private static IList<double> ShiftDataInPlace(IList<double> data, double amount) {
            for (int i = 0; i < data.Count; i++) {
                data[i] = data[i] + amount;
            }
            return data;
        }

        private static IList<double> SampleWithReplacement(IList<double> data, int sampleSize) {
            var l = new List<double>(data);
            var sample = new List<double>();

            for (int i = 0; i < sampleSize; i++) {
                var index = random.Next(l.Count);
                sample.Add(l[index]);
            }
            
            return sample;
        }
    }
}
