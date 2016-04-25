using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Project
{
    class ActivationFunctions
    {
        public int sign(double Y, int C1, int C2)
        {
            if (Y >= 0)
                return 1;
            return -1;
        }

        public double Hyperb(double X)
        {
            return (Math.Exp(X * 2) - 1.0) / ((Math.Exp(2 * X)) + 1.0);
        }
        public double D_Hyperb(double X)
        {
            return (4.0 * Math.Exp(X * 2.0)) / (Math.Pow(1.0 + Math.Exp(2 * X), 2.0));
        }
        public double Sigmoid(double V, double a)
        {
            double e = Math.Exp(-a * V);
            double Ys = (1.0 + e);
            double X = 1.0 / Ys;
            return X;
        }

        public double D_Sigmoid(double V, double a)
        {
            double FV = this.Sigmoid(V, 1.0);
            double X = a * FV * (1.0 - FV);
            return X;
        }

    }
}
