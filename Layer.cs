using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Project
{
    class Layer
    {
        public int NumberOfNeurons;
        public Neuron[] Neurons;
        public Layer(int NumberOfNeurons, double Eta, int NF)
        {
            this.NumberOfNeurons = NumberOfNeurons;
            this.Neurons = new Neuron[this.NumberOfNeurons];
            for (int i = 0; i < Neurons.Length; ++i)
                Neurons[i] = new Neuron(1, Eta, NF);
        }
        public void SetY(float[] F)
        {
            for (int i = 0; i < F.Length; ++i)
                this.Neurons[i].Y = F[i];
        }
        public void Forward(Layer L)
        {
            for (int i = 0; i < this.Neurons.Length; ++i)
                this.Neurons[i].CalculateV(L);
        }
        public void CalculateSignalError(Layer L)
        {
            for (int i = 0; i < this.NumberOfNeurons; ++i)
            {
                double sum = 0;
                for (int j = 0; j < L.Neurons.Length; ++j)
                {
                    sum += L.Neurons[j].SignalError * L.Neurons[j].Weights[i + 1];

                }
                double DiffY = new ActivationFunctions().D_Sigmoid(this.Neurons[i].V, 1.0);
                // double DiffY = new ActivationFunctions().D_Hyperb(this.Neurons[i].V);
                this.Neurons[i].SignalError = DiffY * sum;
            }
        }
        public void CalculateOutputLayerSignalError(double[] Desired)
        {
            for (int i = 0; i < this.Neurons.Length; ++i)
            {
                double DiffY = new ActivationFunctions().D_Sigmoid(this.Neurons[i].V, 1.0);
                //double DiffY = new ActivationFunctions().D_Hyperb(this.Neurons[i].V);
                this.Neurons[i].SignalError = (Desired[i] - this.Neurons[i].Y) * DiffY;
            }
        }
        public void UpdateWeight(Layer L)
        {
            for (int i = 0; i < this.NumberOfNeurons; ++i)
                this.Neurons[i].UpdateWeightss(L);
        }

    }
}
