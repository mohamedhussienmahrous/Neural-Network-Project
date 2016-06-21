using Emgu.CV;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural_Project
{
    class loadimage
    {
        public Bitmap LM;
        public List<Sample> image;
        string path;
        public string[] classes;
        public loadimage(string p)
        {
            this.path = p;
            this.LM = new Bitmap(path);
            this.image = new List<Sample>();
            this.Load_samples();

        }
        public void Load_samples()
        {
            string tmp = path.Split('\\').Last();
            tmp = tmp.Split('.').First();
            tmp = tmp.Split('-').Last();
            string[] Cs = tmp.Split(' ');
            /////filter Classes Array to remove the Null Elements 
            classes = this.Filter(Cs);
            ImageFeature<float>[] Points = SURF(LM);
            for (int x = 0; x < Points.Length; ++x)
            {
                Sample S = new Sample();
                S.Lable = classes;
                S.Feature = Points[x];
                image.Add(S);
            }
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

        private string[] Filter(string[] Cs)
        {
            List<string> Res = new List<string>();
            for (int i = 0; i < Cs.Length; ++i)
                if (Cs[i] == "")
                    continue;
                else
                    Res.Add(Cs[i]);
            return Res.ToArray();
        }
        private ImageFeature<float>[] SURF(Bitmap M)
        {
            Image<Gray, byte> image = new Image<Gray, byte>(M);
            SURFDetector sift = new SURFDetector(1.0f, true);
            VectorOfKeyPoint keys = new VectorOfKeyPoint();
            MKeyPoint[] key = sift.DetectKeyPoints(image, null);
            ImageFeature<float>[] res = sift.ComputeDescriptors(image, null, key);
            return res;
        }
    }
}
