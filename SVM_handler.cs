using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Neural_Project
{
    class SVM_handler
    {
        int[,] confusion_matrix;
        double overall_accuracy = 0;
        int numberallsamplesinaccurcy = 0;
        int number_of_rigth_samples = 0;
        ReadImages RI;
        loadimage LM;
        Support_Vector_Machine S_V_M;
        Label trainingtime;
        Label testingtime;
        public DataGridView confusion_matrix_control;
        TextBox overall_accuracy_control;
        public SVM_handler(ReadImages RM2, DataGridView confusion_matrix_control, TextBox overall_accuracy_control, Label trainingtime, Label testingtime)
        {
            RI = RM2;
            confusion_matrix = new int[1, this.RI.classes.Count];
            for (int f = 0; f < 1; f++)
                for (int x = 0; x < this.RI.classes.Count; x++)
                    confusion_matrix[f, x] = 0;
            this.confusion_matrix_control = confusion_matrix_control;
            this.trainingtime = trainingtime;
            this.testingtime = testingtime;
            this.overall_accuracy_control = overall_accuracy_control;

            Benchmark.Start();
            S_V_M = new Support_Vector_Machine(RI);
            Benchmark.End();
            this.trainingtime.Text = " The Training Time : " + Benchmark.GetSeconds().ToString();
            for (int d = 0; d < this.RI.TestingImages.Length; ++d)
            {
                LM = new loadimage(RI.TestingImages[d]);
                Voting(S_V_M.testing(LM), confusion_matrix, this.LM.classes);
            }

            display_results(this.confusion_matrix_control, this.overall_accuracy_control);
            MessageBox.Show("Done Testing");
        }
        public void display_results(DataGridView dgrdv_confusion_matrix, TextBox textbox_overall_accuracy)
        {
            dgrdv_confusion_matrix.Rows.Clear();
            dgrdv_confusion_matrix.Columns.Clear();
            textbox_overall_accuracy.Text = overall_accuracy.ToString();
            DataGridView_Helpers object_data_grid_view_helpers = new DataGridView_Helpers();
            object_data_grid_view_helpers.add_grid_column("actions", "/", new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);

            List<string> all = this.RI.classes.ToList();
            for (int b = 0; b < all.Count; b++)
            {
                object_data_grid_view_helpers.add_grid_column(all[b], all[b], new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
                //   dgrdv_confusion_matrix.Rows.Add(all[b]);
            }
            double sum = 0.0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < this.RI.classes.Count; j++)
                    dgrdv_confusion_matrix.Rows[i].Cells[j + 1].Value = confusion_matrix[i, j];
            }
            //for (int o = 0; o < all.Count; o++)
            //    sum += confusion_matrix[o, o];
            textbox_overall_accuracy.Text = (((this.number_of_rigth_samples) /(double) (this.numberallsamplesinaccurcy)) * 100).ToString();
        }

        public void openIMage()
        {
            Show_Image SI = new Show_Image();
            SI.ShowDialog();
            loadimage KM = new loadimage(SI.loodim);
            Benchmark.Start();
            double[] res = this.S_V_M.testing(KM);
            string output_to_Messagebox = "the output is ";
            string[] f = this.RI.classes.ToArray();
            double maxf = res.Max();
            //int indexk = 0;
            //for (int d = 0; d < res.Length; d++)
            //{
            //    if (res[d] >= maxf)
            //        indexk = d;
            //}
            //output_to_Messagebox = f[indexk];
            for (int d = 0; d < res.Length; d++)
            {
                if (res[d] > 3)
                    output_to_Messagebox += " " + f[d];
            }
            Benchmark.End();
            this.testingtime.Text = "The Testing Time : " + Benchmark.GetSeconds().ToString();
            this.overall_accuracy_control.Text = this.overall_accuracy.ToString();
            MessageBox.Show(output_to_Messagebox);
        }
        void Voting(Double[] output, int[,] confusionmatrix, string[] clases)
        {
            double[] beforeoutput = output;
            List<string> mylistout = RI.classes.ToList();
            for (int s = 0; s < output.Length; s++)
            {
                if (output[s] > 3)
                {
                    confusionmatrix[0, s]++;
                }

            }
            int index;

            for (int b = 0; b < clases.Length; b++)
            {
                index = mylistout.IndexOf(clases[b]);
                if (index != -1 && output[index] > 3)
                    ++number_of_rigth_samples;
                ++numberallsamplesinaccurcy;
            }
        }
    }
}