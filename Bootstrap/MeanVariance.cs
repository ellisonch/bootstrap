using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootstrap {
    // based on code from http://www.johndcook.com/blog/standard_deviation/
    // a 1962 paper by B. P. Welford and is presented in Donald Knuth’s Art of Computer Programming, Vol 2, page 232, 3rd edition.
    public class MeanVariance {
        private int m_n = 0;
        double m_oldM;
        double m_newM;
        double m_oldS;
        double m_newS;


        public static MeanVariance Calculate(IEnumerable<double> data) {
            var mv = new MeanVariance();
            foreach (var x in data) {
                mv.Push(x);
            }
            return mv;
        }

        public void Push(double x) {
            m_n++;

            // See Knuth TAOCP vol 2, 3rd edition, page 232
            if (m_n == 1) {
                m_oldM = m_newM = x;
                m_oldS = 0.0;
            } else {
                m_newM = m_oldM + (x - m_oldM) / m_n;
                m_newS = m_oldS + (x - m_oldM) * (x - m_newM);

                // set up for next iteration
                m_oldM = m_newM;
                m_oldS = m_newS;
            }
        }

        public int Count() {
            return m_n;
        }

        public double Mean() {
            return (m_n > 0) ? m_newM : 0.0;
        }

        public double Variance() {
            return ( (m_n > 1) ? m_newS/(m_n - 1) : 0.0 );
        }

        public double StandardDeviation() {
            return Math.Sqrt(Variance());
        }
    }
}
