using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Project
{
    class MultiLayerPerceptron
    {

        public int NumberOfEpochs;
        public int NumberOfHiddenLayers;
        public int[] NumberOfNeuronsForEachHiddenLayer;
        public Layer[] AllLayers;
        public ReadImages Dataset;
        public MultiLayerPerceptron(ReadImages RI, double Eta, int NumberOfEpochs, int NumberOfHiddenLayers, int[] NumberOfNeuronsForEachHiddenLayer)
        {

            this.NumberOfEpochs = NumberOfEpochs;
            this.NumberOfHiddenLayers = NumberOfHiddenLayers;
            this.NumberOfNeuronsForEachHiddenLayer = NumberOfNeuronsForEachHiddenLayer;
            this.AllLayers = new Layer[NumberOfHiddenLayers + 2];
            this.Dataset = RI;
            AllLayers[0] = new Layer(Dataset.TrainingSamples[0].Feature.Descriptor.Count(), Eta, Dataset.TrainingSamples[0].Feature.Descriptor.Count());
            for (int i = 1; i <= this.NumberOfHiddenLayers; ++i)
                AllLayers[i] = new Layer(NumberOfNeuronsForEachHiddenLayer[i - 1], Eta, AllLayers[i - 1].NumberOfNeurons);
            AllLayers[this.NumberOfHiddenLayers + 1] = new Layer(Dataset.classes.Count(), Eta, NumberOfNeuronsForEachHiddenLayer[NumberOfNeuronsForEachHiddenLayer.Length - 1]);

        }
        public void MLPTraining()
        {
            for (int i = 0; i < this.NumberOfEpochs; ++i)
            {

                //Raye7
                for (int s = 0; s < Dataset.TrainingSamples.Count(); ++s)
                {
                    ///take feature input
                    AllLayers[0].SetY(Dataset.TrainingSamples[s].Feature.Descriptor);
                    ///forward finished
                    for (int L = 1; L < AllLayers.Length; ++L)
                        AllLayers[L].Forward(AllLayers[L - 1]);
                    ////Back Propagation
                    ////Output Layer 
                    AllLayers[AllLayers.Length - 1].CalculateOutputLayerSignalError(Map(Dataset.TrainingSamples[s].Lable));
                    if (s == 1000)
                    {
                        int x = 0;
                    }
                    ////All Hidden
                    for (int x = AllLayers.Length - 2; x > 0; x--)
                        AllLayers[x].CalculateSignalError(AllLayers[x + 1]);
                    //////Update Weights
                    for (int p = 1; p < AllLayers.Length; ++p)
                        AllLayers[p].UpdateWeight(AllLayers[p - 1]);

                }

            }
        }
        private double[] Map(string[] C)
        {
            List<string> D = Dataset.classes.ToList();
            double[] d = new double[Dataset.classes.Count()];
            for (int i = 0; i < d.Length; ++i)
                d[i] = 0;
            d[D.IndexOf(C[0])] = 1;
            return d;
        }
        public double[] MLPTesting(loadimage InputSample)
        {
            double[] result = new double[this.Dataset.classes.Count];
            double[] x = new double[AllLayers[AllLayers.Length - 1].Neurons.Length];
            for (int g = 0; g < InputSample.image.Count; g++)
            {
                AllLayers[0].SetY(InputSample.image[g].Feature.Descriptor);

                ///forward finished
                for (int L = 1; L < AllLayers.Length; ++L)
                    AllLayers[L].Forward(AllLayers[L - 1]);

                for (int i = 0; i < AllLayers[AllLayers.Length - 1].Neurons.Length; i++)
                {
                    x[i] = AllLayers[AllLayers.Length - 1].Neurons[i].Y;

                }

                result[des(x)]++;
            }
            return result;
        }

        private int des(double[] hu)
        {
            double x = hu.Max();
            for (int v = 0; v < hu.Length; v++)
                if (hu[v] >= x)
                    return v;
            return 0;
        }


    }
}
