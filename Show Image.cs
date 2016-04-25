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
    public partial class Show_Image : Form
    {
        public string loodim ;
        public Show_Image()
        {    
            InitializeComponent();          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loodim = ofd.FileName;

            }
           
            pictureBox1.Image = new Bitmap(loodim);
        }
    }
}
