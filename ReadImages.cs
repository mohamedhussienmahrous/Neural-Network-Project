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
    class ReadImages
    {
        public List<Sample> TrainingSamples;
        public List<Sample> TestingSamples;
        public SortedSet<string> classes = new SortedSet<string>();

        public ReadImages()
        {
            TrainingSamples = new List<Sample>();
            TestingSamples = new List<Sample>();


            string[] TraingImages = Directory.GetFiles(Application.StartupPath + "\\Data set\\Training");
            string[] TestingImages = Directory.GetFiles(Application.StartupPath + "\\Data set\\Testing");
            // DataSet = new Bitmap[TraingImages.Length];
            Read(TraingImages, ref TrainingSamples);
            Read(TestingImages, ref TestingSamples);
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

    }
}
