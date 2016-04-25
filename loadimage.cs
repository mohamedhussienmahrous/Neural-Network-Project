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
        public loadimage(string p)
        {
            this.path = p;
            LM = new Bitmap(path);
            image = new List<Sample>();

        }
        public void Load_samples()
        {

            string tmp = path.Split('\\').Last();
            tmp = tmp.Split('.').First();
            tmp = tmp.Split('-').Last();
            string[] Cs = tmp.Split(' ');
            /////filter Classes Array to remove the Null Elements 
            ImageFeature<float>[] Points = SIFFt(LM);
            for (int x = 0; x < Points.Length; ++x)
            {
                Sample S = new Sample();
                S.Lable = null;
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
    }
}
