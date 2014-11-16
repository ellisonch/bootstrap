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
                    var x = new List<double> { 4.0, 4.2, 4.5, 4.6, 4.6, 4.7, 5.0, 5.3, 5.5, 5.5, 5.8, 6.0, 6.6, 8.2 };
                    var y = new List<double> { 2.8, 3.6, 3.7, 4.2, 4.3, 4.9, 4.9, 4.9, 5.1, 5.2, 5.3, 5.4, 5.6, 5.7 };

                    var p = Bootstrap.Bootstrap.TwoSampleTTestInPlace(x, y, 4000);
                    // Console.WriteLine(p);
                }
                sw.Stop();
                Console.WriteLine("{0}s", sw.Elapsed.TotalMilliseconds / 1000.0);
            }
            Console.ReadKey();
        }
    }
}
