using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Features2D;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;


namespace Neural_Project
{
    public class Sample
    {
        public string[] Lable; //el desired
        public ImageFeature<float> Feature; //guwaha l 128 descriptors
        public Sample()
        {

        }

    }
}
