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
        const int number_of_features = 4,
            number_of_states_of_nature = 3,
            number_of_samples_per_state_of_nature = 50,
            number_of_training_samples_per_state_of_nature = 30,
            number_of_test_samples_per_state_of_nature = 20;

        const char file_delimeter = ',';
        public DataGridView confusion_matrix_control, NumberOfNeuronsInEachLayer;
        TextBox overall_accuracy_control;
        public int NumberOfHiddenLayers, Epochs;
        double Eta;



        public void handle_load_data_set_button_click(Form parent_form, TextBox Epoch, TextBox Eta, TextBox NumberOfHiddenLayers,
            DataGridView dgrdv_confusion_matrix,
            DataGridView NumberOfNeuronsinHidden,
            TextBox textbox_overall_accuracy)
        {
            confusion_matrix_control = dgrdv_confusion_matrix;
            overall_accuracy_control = textbox_overall_accuracy;

            ReadIm = new ReadImages();
            this.Eta = double.Parse(Eta.Text.ToString());
            this.Epochs = int.Parse(Epoch.Text.ToString());
            this.NumberOfHiddenLayers = int.Parse(NumberOfHiddenLayers.Text.ToString());
            this.NumberOfNeuronsInEachLayer = NumberOfNeuronsinHidden;
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
            ML.MLPTraining();
            double[] output = new double[ReadIm.classes.Count];

            for (int j = 0; j < this.ReadIm.TestingSamples.Count; ++j)
            {
                output = ML.MLPTesting(this.ReadIm.TestingSamples[j]);
                confusion_matrix[0, des(output)]++;
            }

            display_results(confusion_matrix_control, overall_accuracy_control);
            MessageBox.Show("Done Testing");
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
            double sum = 0.0;
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < this.ReadIm.classes.Count; j++)
                {
                    dgrdv_confusion_matrix.Rows[i].Cells[j + 1].Value = confusion_matrix[i, j];

                }
            }
            //for (int o = 0; o < all.Count; o++)
            //    sum += confusion_matrix[o, o];
            textbox_overall_accuracy.Text = ((sum) / (this.ReadIm.TestingSamples.Count) * 100).ToString();

        }


        public void openimage()
        {
            Show_Image SI = new Show_Image();
            SI.ShowDialog();
            loadimage KM = new loadimage(SI.loodim);
            KM.Load_samples();
            //this.ML.MLPTesting();

        }
    }
}
