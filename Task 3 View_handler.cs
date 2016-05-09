using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Drawing;


namespace Neural_Project
{
    class Task_3_View_handler
    {
        ReadImages ReadIm;
        int[,] confusion_matrix;
        double overall_accuracy;
        MultiLayerPerceptron ML;
        int numberallsamplesinaccurcy = 0;
        int number_of_rigth_samples = 0;
        public DataGridView confusion_matrix_control, NumberOfNeuronsInEachLayer;
        TextBox overall_accuracy_control;
        public int NumberOfHiddenLayers, Epochs;
        double Eta;
        Label trainingtime;
        Label testingtime;

        public Task_3_View_handler(ReadImages RM)
        {
            this.ReadIm = RM;
        }
        public void handle_load_data_set_button_click(Form parent_form, TextBox Epoch, TextBox Eta, TextBox NumberOfHiddenLayers,
            DataGridView dgrdv_confusion_matrix,
            DataGridView NumberOfNeuronsinHidden,
            TextBox textbox_overall_accuracy, Label trainingtime, Label TestingTime)
        {
            confusion_matrix_control = dgrdv_confusion_matrix;
            overall_accuracy_control = textbox_overall_accuracy;
            this.Eta = double.Parse(Eta.Text.ToString());
            this.Epochs = int.Parse(Epoch.Text.ToString());
            this.NumberOfHiddenLayers = int.Parse(NumberOfHiddenLayers.Text.ToString());
            this.NumberOfNeuronsInEachLayer = NumberOfNeuronsinHidden;
            this.trainingtime = trainingtime;
            this.testingtime = TestingTime;
            MessageBox.Show("Done");
            CreateHiddenLayersDGV();
        }
        public void Run()
        {
            confusion_matrix = new int[1, this.ReadIm.classes.Count];
            for (int f = 0; f < 1; f++)
                for (int x = 0; x < this.ReadIm.classes.Count; x++)
                    confusion_matrix[f, x] = 0;

            int[] w = GetNumberOfNeurins();
            ML = new MultiLayerPerceptron(ReadIm, Eta, Epochs, NumberOfHiddenLayers, w);
            Benchmark.Start();
            ML.MLPTraining();
            Benchmark.End();
            this.trainingtime.Text = "The Training time : " + Benchmark.GetSeconds().ToString();
            double[] output = new double[ReadIm.classes.Count];
            loadimage LMR;
            for (int c = 0; c < this.ReadIm.TestingImages.Length; c++)
            {
                LMR = new loadimage(this.ReadIm.TestingImages[c]);
                output = ML.MLPTesting(LMR);
                Voting(output, confusion_matrix, LMR.classes);
            }

            display_results(confusion_matrix_control, overall_accuracy_control);
            overall_accuracy_control.Text = (((this.number_of_rigth_samples) / (double)(this.numberallsamplesinaccurcy)) * 100).ToString()+" %";
            MessageBox.Show("Done Testing");
        }

        void Voting(double[] output, int[,] confusionmatrix, string[] clases)
        {
            double[] beforeoutput = output;
            List<string> mylistout = clases.ToList();
            for (int s = 0; s < output.Length; s++)
            {
                if (output[s] > 3)
                {
                    confusionmatrix[0, s]++;

                }

            }
            int index = 0;
            for (int b = 0; b < clases.Length; b++)
            {
               index = mylistout.IndexOf(clases[b]);
                if (index != -1 && output[index] > 3)
                    ++number_of_rigth_samples;
                ++numberallsamplesinaccurcy;
            }


        }

        private int des(double[] hu)
        {
            double x = hu.Max();
            for (int v = 0; v < hu.Length; v++)
                if (hu[v] >= x)
                    return v;
            return 0;
        }

        private int[] GetNumberOfNeurins()
        {
            int[] NF = new int[this.NumberOfHiddenLayers];
            for (int w = 0; w < this.NumberOfHiddenLayers; w++)
                NF[w] = int.Parse(this.NumberOfNeuronsInEachLayer.Rows[w].Cells[1].Value.ToString());
            return NF;
        }
        public void CreateHiddenLayersDGV()
        {

            this.NumberOfNeuronsInEachLayer.Rows.Clear();
            this.NumberOfNeuronsInEachLayer.Columns.Clear();
            DataGridView_Helpers object_data_grid_view_helpers = new DataGridView_Helpers();
            object_data_grid_view_helpers.add_grid_column("Hidden Layer Number ", "Layer Number", new DataGridViewTextBoxCell(), this.NumberOfNeuronsInEachLayer);
            object_data_grid_view_helpers.add_grid_column("Number Of Neurons", "#Neurons", new DataGridViewTextBoxCell(), this.NumberOfNeuronsInEachLayer);
            for (int i = 1; i <= this.NumberOfHiddenLayers; ++i)
                this.NumberOfNeuronsInEachLayer.Rows.Add(i.ToString());
        }


        public void display_results(DataGridView dgrdv_confusion_matrix, TextBox textbox_overall_accuracy)
        {
            dgrdv_confusion_matrix.Rows.Clear();
            dgrdv_confusion_matrix.Columns.Clear();
            textbox_overall_accuracy.Text = overall_accuracy.ToString();
            DataGridView_Helpers object_data_grid_view_helpers = new DataGridView_Helpers();
            object_data_grid_view_helpers.add_grid_column("actions", "/", new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);

            List<string> all = this.ReadIm.classes.ToList();
            for (int b = 0; b < all.Count; b++)
            {
                object_data_grid_view_helpers.add_grid_column(all[b], all[b], new DataGridViewTextBoxCell(), dgrdv_confusion_matrix);
                //   dgrdv_confusion_matrix.Rows.Add(all[b]);
            }

            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < this.ReadIm.classes.Count; j++)
                {
                    dgrdv_confusion_matrix.Rows[i].Cells[j + 1].Value = confusion_matrix[i, j];
                }
            }
            textbox_overall_accuracy.Text = ((this.overall_accuracy) / (this.ReadIm.TestingImages.Length) * 100).ToString();

        }
        public void openimage()
        {
            Show_Image SI = new Show_Image();
            SI.ShowDialog();
            loadimage KM = new loadimage(SI.loodim);
            Benchmark.Start();
            double[] res = this.ML.MLPTesting(KM);
            string output_to_Messagebox = "the output is ";
            string[] f = this.ReadIm.classes.ToArray();
            for (int d = 0; d < res.Length; d++)
            {
                if (res[d] > 3)
                    output_to_Messagebox += " " + f[d];
            }
            Benchmark.End();
            this.testingtime.Text = "The Testing Time : " + Benchmark.GetSeconds().ToString();
            MessageBox.Show(output_to_Messagebox);

        }
    }
}
