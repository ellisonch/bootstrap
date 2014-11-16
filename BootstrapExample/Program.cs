using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapExample {
    class Program {
        static readonly int NumRuns = 3;
        static readonly int NumIterations = 200;

        static void Main(string[] args) {
            for (int run = 0; run < NumRuns; run++) {
                Stopwatch sw = Stopwatch.StartNew();
                Console.Write("Run {0} of {1}... ", run + 1, NumRuns);
                for (int iteration = 0; iteration < NumIterations; iteration++) {
                    var p1 = Bootstrap.Bootstrap.TwoSampleTTestInPlace(x1, y1, 1000);
                    var p2 = Bootstrap.Bootstrap.TwoSampleTTestInPlace(x2, y2, 1000);
                    var p3 = Bootstrap.Bootstrap.TwoSampleTTestInPlace(x3, y3, 1000);
                    // Console.WriteLine(p3);
                }
                sw.Stop();
                Console.WriteLine("{0}s", sw.Elapsed.TotalMilliseconds / 1000.0);
            }
            Console.ReadKey();
        }

        static List<double> x1 = new List<double> { 4.0, 4.2, 4.5, 4.6, 4.6, 4.7, 5.0, 5.3, 5.5, 5.5, 5.8, 6.0, 6.6, 8.2 };
        static List<double> y1 = new List<double> { 2.8, 3.6, 3.7, 4.2, 4.3, 4.9, 4.9, 4.9, 5.1, 5.2, 5.3, 5.4, 5.6, 5.7 };

        static List<double> x2 = new List<double> { 14.12, 0.84, 383.79, 0.02, 1692.02, 0.04, 5129.18, 566.42, 0.01, 2506.74, 0.08, 0, 4640.75, 0, 310.61, 871.59, 0.27, 388.47, 47.75, 0, 0.3, 0.32, 511.08, 0, 0.01, 8873.18, 0, 6722.73, 4858.59, 371.25, 0, 944.7, 173.41, 0, 0, 7759.24, 0, 0, 139.96, 776.41, 0.65, 0, 0, 5277.42, 1355.16, 3097.6, 3959.87, 321.87, 0.19, 3021.25, 0.16, 2273.71, 1.17, 297.61, 43.85, 13.46, 0, 5.9, 1201.91, 0, 1157.73, 0.47, 0, 34.99, 0, 0.01, 559.27, 0.1, 36.11, 0, 1332.71, 0.01, 3199.73, 0, 5.2, 7497.56, 898.68, 0.01, 0.12, 0, 3930.82, 0, 0, 512.21, 0, 19.46, 8.76, 1305.49, 5130.33, 453.04, 354.91, 16.69, 52.73, 1327.3, 0, 1266.32, 67.75, 3905.3, 5689.77, 4087.58 };
        static List<double> y2 = new List<double> { 2477.92, 3.78, 0.01, 0.26, 0, 2455.03, 0, 0, 0.87, 0, 6234.44, 0.45, 753.06, 0.12, 0.01, 0, 0.97, 0, 14.95, 4277.07, 25.54, 0.21, 0.11, 15.42, 1972.32, 0.35, 0.27, 108.34, 0.89, 3051.41, 0, 4406.8, 2226.35, 0.01, 0, 26.04, 22.31, 0.66, 3695.41, 0 };

        static List<double> x3 = new List<double> { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 7, 7, 7, 8, 8, 9, 9, 12, 13, 13, 15, 17, 18, 19, 19, 20, 21, 22, 23, 23, 24, 24, 29, 30, 33, 36, 40, 42, 47, 49, 54, 55, 56, 56, 56, 67, 77, 79, 80, 82, 83, 83, 109, 113, 119, 128, 131, 166, 179, 179, 254, 280, 324, 399, 
1, 1, 1, 1, 2, 3, 3, 3, 5, 5, 5, 5, 5, 6, 6, 7, 8, 8, 8, 8, 9, 9, 10, 10, 11, 12, 12, 12, 13, 14, 17, 18, 23, 24, 25, 31, 33, 33, 35, 45, 48, 48, 49, 52, 55, 62, 62, 63, 68, 71, 75, 81, 96, 98, 101, 116, 183, 211, 218, 440, 442, 584, 693 };
        static List<double> y3 = new List<double> { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 9, 9, 10, 10, 10, 12, 14, 15, 17, 17, 20, 21, 22, 23, 25, 25, 28, 28, 28, 29, 33, 35, 38, 42, 43, 46, 55, 58, 62, 72, 77, 83, 97, 118, 125, 136, 142, 167, 179, 208, 218, 347, 355, 645, 1353 };
    }
}
