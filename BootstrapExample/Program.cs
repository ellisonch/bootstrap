using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootstrapExample {
    class Program {
        static void Main(string[] args) {
            for (int times = 0; times < 3; times++) {
                Stopwatch sw = Stopwatch.StartNew();
                for (int i = 0; i < 200; i++) {
                    Example1();
                    Example2();
                    // Console.WriteLine(p);
                }
                sw.Stop();
                Console.WriteLine("{0}s", sw.Elapsed.TotalMilliseconds / 1000.0);
            }
            Console.ReadKey();
        }

        private static void Example1() {
            var x = new List<double> { 4.0, 4.2, 4.5, 4.6, 4.6, 4.7, 5.0, 5.3, 5.5, 5.5, 5.8, 6.0, 6.6, 8.2 };
            var y = new List<double> { 2.8, 3.6, 3.7, 4.2, 4.3, 4.9, 4.9, 4.9, 5.1, 5.2, 5.3, 5.4, 5.6, 5.7 };

            var p = Bootstrap.Bootstrap.TwoSampleTTestInPlace(x, y, 4000);
        }
        private static void Example2() {
            var x = new List<double> { 14.12, 0.84, 383.79, 0.02, 1692.02, 0.04, 5129.18, 566.42, 0.01, 2506.74, 0.08, 0, 4640.75, 0, 310.61, 871.59, 0.27, 388.47, 47.75, 0, 0.3, 0.32, 511.08, 0, 0.01, 8873.18, 0, 6722.73, 4858.59, 371.25, 0, 944.7, 173.41, 0, 0, 7759.24, 0, 0, 139.96, 776.41, 0.65, 0, 0, 5277.42, 1355.16, 3097.6, 3959.87, 321.87, 0.19, 3021.25, 0.16, 2273.71, 1.17, 297.61, 43.85, 13.46, 0, 5.9, 1201.91, 0, 1157.73, 0.47, 0, 34.99, 0, 0.01, 559.27, 0.1, 36.11, 0, 1332.71, 0.01, 3199.73, 0, 5.2, 7497.56, 898.68, 0.01, 0.12, 0, 3930.82, 0, 0, 512.21, 0, 19.46, 8.76, 1305.49, 5130.33, 453.04, 354.91, 16.69, 52.73, 1327.3, 0, 1266.32, 67.75, 3905.3, 5689.77, 4087.58 };
            var y = new List<double> { 2477.92, 3.78, 0.01, 0.26, 0, 2455.03, 0, 0, 0.87, 0, 6234.44, 0.45, 753.06, 0.12, 0.01, 0, 0.97, 0, 14.95, 4277.07, 25.54, 0.21, 0.11, 15.42, 1972.32, 0.35, 0.27, 108.34, 0.89, 3051.41, 0, 4406.8, 2226.35, 0.01, 0, 26.04, 22.31, 0.66, 3695.41, 0 };

            var p = Bootstrap.Bootstrap.TwoSampleTTestInPlace(x, y, 4000);
        }
    }
}
