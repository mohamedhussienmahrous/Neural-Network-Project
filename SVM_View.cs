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
    public partial class SVM_View : Form
    {
        SVM_handler SH = null;
        public SVM_View(ReadImages RM)
        {
            InitializeComponent();
            SH = new SVM_handler(RM,this.dataGridView_confusion_matrix, this.textBox_overall_accuracy, this.Trainingtime, this.Testing_time);
        }
        public SVM_View()
        {
            InitializeComponent(); 
        }
        private void button4_Click(object sender, EventArgs e)
        {
            SH.openIMage();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
