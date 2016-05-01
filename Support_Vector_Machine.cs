using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Features2D;
using System.Drawing;
using Emgu.CV.ML;
using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;


namespace Neural_Project
{
    class Support_Vector_Machine
    {
        SortedSet<string> Clases;
        Matrix<float> trainData;
        Matrix<float> trainClasses;
        Matrix<float> sample;
        SVM model;
        ReadImages DAtaset;
        SVMParams p;
        public Support_Vector_Machine(ReadImages RM)
        {
            this.Clases = RM.classes;
            this.DAtaset = RM;
            trainData = new Matrix<float>(RM.TrainingSamples.Count, RM.TrainingSamples[0].Feature.Descriptor.Length);
            trainClasses = new Matrix<float>(RM.TrainingSamples.Count, 1);
            sample = new Matrix<float>(1, RM.TrainingSamples[0].Feature.Descriptor.Length);
            string[] all_classes = RM.classes.ToArray();
 /// make function to load training data set
            for (int u = 0; u < RM.TrainingSamples.Count; u++)
            {
                for (int p2 = 0; p2 < RM.TrainingSamples[0].Feature.Descriptor.Length; ++p2)
                    trainData[u, p2] = RM.TrainingSamples[u].Feature.Descriptor[p2];

                trainClasses[u, 0] = Map(RM.TrainingSamples[u].Lable[0]) + 1;
            }

            model = new SVM();
            p = new SVMParams();
            p.KernelType = Emgu.CV.ML.MlEnum.SVM_KERNEL_TYPE.LINEAR;
            p.SVMType = Emgu.CV.ML.MlEnum.SVM_TYPE.C_SVC;
            p.C = 1;
            p.TermCrit = new MCvTermCriteria(100, 0.00001);
            //bool trained = model.Train(trainData, trainClasses, null, null, p);
            bool trained = model.TrainAuto(trainData, trainClasses, null, null, p.MCvSVMParams, 5);

        }
        public double[] testing(loadimage InputSample)
        {
            double[] output;
            float response = 0;
            output = new double[this.DAtaset.classes.Count];
            for (int trainindex = 0; trainindex < InputSample.image.Count; trainindex++)
            {
                for (int p1 = 0; p1 < DAtaset.TrainingSamples[0].Feature.Descriptor.Length; ++p1)
                    sample.Data[0, p1] = InputSample.image[trainindex].Feature.Descriptor[p1];
                response = model.Predict(sample);
                ++output[Convert.ToInt32(response) - 1];
            }
            return output;
        }

        private int Map(string C)
        {
            List<string> D = Clases.ToList();
            return D.IndexOf(C);

        }
    }

}

