using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Project
{
    class Neuron
    {
        public double Bias;
        public double[] Weights;
        public double SignalError;
        public double Y;
        public double V;
        public double ErrorRate;
        public Neuron(double Y)
        {
            this.Y = Y;
        }
        public Neuron(double B, double n, int NumberOfWeights)
        {
            Bias = B;
            ErrorRate = n;
            Weights = new double[NumberOfWeights + 1];
            GenerateRandomWeights();
        }
        public void CalculateV(Layer L)
        {
            V = Bias * Weights[0];
            for (int i = 0; i < L.Neurons.Length; ++i)
                V += L.Neurons[i].Y * Weights[i + 1];
            this.CalculateY();
        }
        private void GenerateRandomWeights()
        {
            //Random rnd = new Random();
            for (int i = 0; i < Weights.Length; i++)
            {
                // double w= rnd.Next(0,11);
                Weights[i] = 1.0;
            }
        }
        private void CalculateY()
        {
            Y = new ActivationFunctions().Sigmoid(V, 1.0);
            // Y = new ActivationFunctions().Hyperb(V);
        }
        //public void CalculateSignalError()
        //{
        //    double DiffY = new ActivationFunctions().D_Sigmoid(V, 1);
        //}
        public void UpdateWeightss(Layer L)
        {
            this.Weights[0] += ErrorRate * SignalError * Bias;
            for (int i = 1; i <= L.NumberOfNeurons; ++i)
                this.Weights[i] += ErrorRate * SignalError * L.Neurons[i - 1].Y;
        }


    }
}
