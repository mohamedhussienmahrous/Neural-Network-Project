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
    public partial class Neual_network_form : Form
    {
        Task_3_View_handler NN;
        public Neual_network_form()
        {
            
            InitializeComponent();
        }

        public Neual_network_form(ReadImages RM)
        {
            NN = new Task_3_View_handler(RM);
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
            NN.handle_load_data_set_button_click(this, this.Epoch, Eta, this.NumberOfHidden, dataGridView_confusion_matrix,
                this.NNlayers, this.textBox_overall_accuracy,this.Trainingtime,this.Testing_time,label5,label6);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            NN.openimage();            
        }

        private void Testing_time_Click(object sender, EventArgs e)
        {

        }

        private void label_confusion_matrix_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView_confusion_matrix_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_overall_accuracy_Click(object sender, EventArgs e)
        {

        }

        private void textBox_overall_accuracy_TextChanged(object sender, EventArgs e)
        {

        }

        private void Trainingtime_Click(object sender, EventArgs e)
        {

        }
    }



}
