using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.Features2D;

namespace Neural_Project
{
    public class ReadImages
    {
        public List<Sample> TrainingSamples;
        private List<Sample> TMP;
        public List<Sample> TestingSamples;
        public string[] TestingImages;
        public string[] TraingImages;
        public SortedSet<string> classes = new SortedSet<string>();
        float[] Mean;
        float[] Max;
        public ReadImages()
        {
            TrainingSamples = new List<Sample>();
            TestingSamples = new List<Sample>();
            TMP = new List<Sample>();
            TraingImages = Directory.GetFiles(Application.StartupPath + "\\Data set\\Training");
            TestingImages = Directory.GetFiles(Application.StartupPath + "\\Data set\\Testing");
            Read(TraingImages, ref TMP);
            DataNormalization();
            //Read(TestingImages, ref TestingSamples);
        }
        public void Read(string[] Images, ref List<Sample> Samples)
        {
            for (int i = 0; i < Images.Length; ++i)
            {
                Bitmap Temp = new Bitmap(Images[i]);
                string tmp = Images[i].Split('\\').Last();
                tmp = tmp.Split('.').First();
                tmp = tmp.Split('-').Last();
                string[] Cs = tmp.Split(' ');
                /////filter Classes Array to remove the Null Elements 
                string[] Classes = Filter(Cs);
                ImageFeature<float>[] Points = SIFFt(Temp);
                for (int x = 0; x < Points.Length; ++x)
                {
                    Sample S = new Sample();
                    S.Lable = Classes;
                    S.Feature = Points[x];
                   
                    Samples.Add(S);
                }
            }
        }

        private string[] Filter(string[] Cs)
        {
            List<string> Res = new List<string>();
            for (int i = 0; i < Cs.Length; ++i)
                if (Cs[i] == "")
                    continue;
                else
                {
                    classes.Add(Cs[i]);
                    Res.Add(Cs[i]);
                }
            return Res.ToArray();
        }
        private ImageFeature<float>[] SIFFt(Bitmap M)
        {
            Image<Gray, byte> image = new Image<Gray, byte>(M);
            SIFTDetector sift = new SIFTDetector();
            VectorOfKeyPoint keys = new VectorOfKeyPoint();
            MKeyPoint[] key = sift.DetectKeyPoints(image, null);
            ImageFeature<float>[] res = sift.ComputeDescriptors(image, null, key);
            return res;
        }

        private void DataNormalization()
        {
             Mean = new float[TMP[0].Feature.Descriptor.Length];
             Max = new float[TMP[0].Feature.Descriptor.Length];

            ///////CalCulate Sum
            for(int i=0;i<TMP.Count;++i)
                for(int j=0;j<TMP[0].Feature.Descriptor.Length;++j)
                {
                    Mean[j] += TMP[i].Feature.Descriptor[j];
                }
            ///// intiatize Max and  Average Sum
            for (int i = 0; i < TMP[0].Feature.Descriptor.Length; ++i)
            {
                Max[i] = float.MinValue;
                Mean[i] /= TMP.Count;
            }
            ////subtract Mean and Get Sum
            for (int i = 0; i < TMP.Count; ++i)
                for (int j = 0; j < TMP[0].Feature.Descriptor.Length; ++j)
                {
                    TMP[i].Feature.Descriptor[j] -= Mean[j];
                    if(Max[j]<TMP[i].Feature.Descriptor[j])
                    Max[j] = TMP[i].Feature.Descriptor[j];
                }
            ////// Add New samples to Training Samples
            for (int i = 0; i < TMP.Count; ++i)
            {
                Sample S = new Sample();
                S.Lable = TMP[i].Lable;
                S.Feature = TMP[i].Feature;
                for (int j = 0; j < TMP[0].Feature.Descriptor.Length; ++j)
                {
                    S.Feature.Descriptor[j] = TMP[i].Feature.Descriptor[j] / Max[j];
                    
                }
                TrainingSamples.Add(S);
            }
        }
    }
}
