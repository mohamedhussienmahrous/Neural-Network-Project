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
    public partial class Form1 : Form
    {
        Task_3_View_handler NN;
        public Form1()
        {
            NN = new Task_3_View_handler();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            NN.Run();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NN.handle_load_data_set_button_click(this, this.Epoch, Eta, this.NumberOfHidden, dataGridView_confusion_matrix, this.NNlayers, this.textBox_overall_accuracy);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NN.openimage();
        }
    }



}
