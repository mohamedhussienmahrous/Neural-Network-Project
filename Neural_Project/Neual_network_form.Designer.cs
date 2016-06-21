namespace Neural_Project
{
    partial class Neual_network_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.NNlayers = new System.Windows.Forms.DataGridView();
            this.label_overall_accuracy = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label_confusion_matrix = new System.Windows.Forms.Label();
            this.dataGridView_confusion_matrix = new System.Windows.Forms.DataGridView();
            this.textBox_overall_accuracy = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.NumberOfHidden = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Eta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Epoch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Trainingtime = new System.Windows.Forms.Label();
            this.Testing_time = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.NNlayers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_confusion_matrix)).BeginInit();
            this.SuspendLayout();
            // 
            // NNlayers
            // 
            this.NNlayers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NNlayers.Location = new System.Drawing.Point(409, 51);
            this.NNlayers.Name = "NNlayers";
            this.NNlayers.Size = new System.Drawing.Size(240, 150);
            this.NNlayers.TabIndex = 38;
            // 
            // label_overall_accuracy
            // 
            this.label_overall_accuracy.AutoSize = true;
            this.label_overall_accuracy.Location = new System.Drawing.Point(16, 538);
            this.label_overall_accuracy.Name = "label_overall_accuracy";
            this.label_overall_accuracy.Size = new System.Drawing.Size(88, 13);
            this.label_overall_accuracy.TabIndex = 37;
            this.label_overall_accuracy.Text = "Overall Accuracy";
            this.label_overall_accuracy.Click += new System.EventHandler(this.label_overall_accuracy_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(472, 279);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 44);
            this.button2.TabIndex = 36;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_confusion_matrix
            // 
            this.label_confusion_matrix.AutoSize = true;
            this.label_confusion_matrix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_confusion_matrix.Location = new System.Drawing.Point(15, 315);
            this.label_confusion_matrix.Name = "label_confusion_matrix";
            this.label_confusion_matrix.Size = new System.Drawing.Size(127, 20);
            this.label_confusion_matrix.TabIndex = 35;
            this.label_confusion_matrix.Text = "Confusion Matrix";
            this.label_confusion_matrix.Click += new System.EventHandler(this.label_confusion_matrix_Click);
            // 
            // dataGridView_confusion_matrix
            // 
            this.dataGridView_confusion_matrix.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_confusion_matrix.Location = new System.Drawing.Point(12, 350);
            this.dataGridView_confusion_matrix.Name = "dataGridView_confusion_matrix";
            this.dataGridView_confusion_matrix.Size = new System.Drawing.Size(390, 176);
            this.dataGridView_confusion_matrix.TabIndex = 34;
            this.dataGridView_confusion_matrix.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_confusion_matrix_CellContentClick);
            // 
            // textBox_overall_accuracy
            // 
            this.textBox_overall_accuracy.Location = new System.Drawing.Point(115, 536);
            this.textBox_overall_accuracy.Name = "textBox_overall_accuracy";
            this.textBox_overall_accuracy.Size = new System.Drawing.Size(133, 20);
            this.textBox_overall_accuracy.TabIndex = 33;
            this.textBox_overall_accuracy.TextChanged += new System.EventHandler(this.textBox_overall_accuracy_TextChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(472, 232);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 41);
            this.button1.TabIndex = 31;
            this.button1.Text = "Make NN";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(405, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(205, 20);
            this.label4.TabIndex = 30;
            this.label4.Text = "# of neuorens in each Layer";
            // 
            // NumberOfHidden
            // 
            this.NumberOfHidden.Location = new System.Drawing.Point(249, 135);
            this.NumberOfHidden.Name = "NumberOfHidden";
            this.NumberOfHidden.Size = new System.Drawing.Size(100, 20);
            this.NumberOfHidden.TabIndex = 29;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(175, 20);
            this.label3.TabIndex = 28;
            this.label3.Text = "Number of Hidden layer";
            // 
            // Eta
            // 
            this.Eta.Location = new System.Drawing.Point(249, 88);
            this.Eta.Name = "Eta";
            this.Eta.Size = new System.Drawing.Size(100, 20);
            this.Eta.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 26;
            this.label2.Text = "Learning Rate";
            // 
            // Epoch
            // 
            this.Epoch.Location = new System.Drawing.Point(249, 37);
            this.Epoch.Name = "Epoch";
            this.Epoch.Size = new System.Drawing.Size(100, 20);
            this.Epoch.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Epoch";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(494, 398);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 35);
            this.button3.TabIndex = 39;
            this.button3.Text = "Close";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(472, 329);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(138, 48);
            this.button4.TabIndex = 40;
            this.button4.Text = "Open image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Trainingtime
            // 
            this.Trainingtime.AutoSize = true;
            this.Trainingtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Trainingtime.Location = new System.Drawing.Point(12, 172);
            this.Trainingtime.Name = "Trainingtime";
            this.Trainingtime.Size = new System.Drawing.Size(119, 20);
            this.Trainingtime.TabIndex = 41;
            this.Trainingtime.Text = "Trainng Time is ";
            this.Trainingtime.Click += new System.EventHandler(this.Trainingtime_Click);
            // 
            // Testing_time
            // 
            this.Testing_time.AutoSize = true;
            this.Testing_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Testing_time.Location = new System.Drawing.Point(16, 208);
            this.Testing_time.Name = "Testing_time";
            this.Testing_time.Size = new System.Drawing.Size(114, 20);
            this.Testing_time.TabIndex = 42;
            this.Testing_time.Text = "Testing Time is";
            this.Testing_time.Click += new System.EventHandler(this.Testing_time_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 20);
            this.label5.TabIndex = 43;
            this.label5.Text = "Training Memory";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 20);
            this.label6.TabIndex = 44;
            this.label6.Text = "Testing Memory";
            // 
            // Neual_network_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 568);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Testing_time);
            this.Controls.Add(this.Trainingtime);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.NNlayers);
            this.Controls.Add(this.label_overall_accuracy);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_confusion_matrix);
            this.Controls.Add(this.dataGridView_confusion_matrix);
            this.Controls.Add(this.textBox_overall_accuracy);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumberOfHidden);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Eta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Epoch);
            this.Controls.Add(this.label1);
            this.Name = "Neual_network_form";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NNlayers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_confusion_matrix)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView NNlayers;
        private System.Windows.Forms.Label label_overall_accuracy;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_confusion_matrix;
        private System.Windows.Forms.DataGridView dataGridView_confusion_matrix;
        private System.Windows.Forms.TextBox textBox_overall_accuracy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox NumberOfHidden;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Eta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Epoch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label Trainingtime;
        private System.Windows.Forms.Label Testing_time;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}

