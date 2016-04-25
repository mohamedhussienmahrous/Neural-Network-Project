using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Network_Tasks
{
    class Adder
    {
        public double ApplyAdder(double Bais,double []WT,double[] X)
        {
            double V=0;
            for (int i = 0; i < WT.Length; ++i)
                V += (WT[i] * X[i]);
            V += Bais;
            return V;
        }
        public double ApplySpeacialAdder(double Bias,double W1,double W2,double X1,double X2)
        {
            return (Bias + W1 * X1 + W2 * X2);
        }
    }
}
