using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural_Project
{
    public partial class Showdrawing : Form
    {
        public PictureBox IM = new PictureBox();

        public Showdrawing()
        {
            InitializeComponent();
        }

        private void Showdrawing_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = IM.Image;
        }
    }
}
