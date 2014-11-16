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
            var xMV = MeanVariance.Calculate(x);
            var yMV = MeanVariance.Calculate(y);

            var targetT = CalculateT(xMV, yMV);

            // shift samples so they have means of 0
            var xPrime = ShiftDataInPlace(x, -xMV.Mean());
            var yPrime = ShiftDataInPlace(y, -yMV.Mean());

            var largerCount = 0;
            for (int i = 0; i < iterations; i++) {
                var sampSize = Math.Min(Math.Min(50, xPrime.Count()), yPrime.Count());
                var xSampMV = GetSampleMeanVariance(xPrime, sampSize);
                var ySampMV = GetSampleMeanVariance(yPrime, sampSize);

                var t = CalculateT(xSampMV, ySampMV);
                if (Math.Abs(t) >= Math.Abs(targetT)) {
                    largerCount++;
                }
            }

            return (1.0 * largerCount) / iterations;
        }

        private static double CalculateT(MeanVariance samp1MV, MeanVariance samp2MV) {
            var x1 = samp1MV.Mean();
            var v1 = samp1MV.Variance();
            var n1 = samp1MV.Count();
            var x2 = samp2MV.Mean();
            var v2 = samp2MV.Variance();
            var n2 = samp2MV.Count();

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

        private static MeanVariance GetSampleMeanVariance(IList<double> data, int sampleSize) {
            var mv = new MeanVariance();

            for (int i = 0; i < sampleSize; i++) {
                var index = random.Next(data.Count);
                mv.Push(data[index]);
            }
            
            return mv;
        }
    }
}
