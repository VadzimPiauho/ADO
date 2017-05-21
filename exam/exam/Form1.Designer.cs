namespace exam
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.productExamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.productExamDataSet = new exam.ProductExamDataSet();
            this.productExamTableAdapter = new exam.ProductExamDataSetTableAdapters.ProductExamTableAdapter();
            this.productExamDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.productExamBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productExamDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productExamDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // productExamBindingSource
            // 
            this.productExamBindingSource.DataMember = "ProductExam";
            this.productExamBindingSource.DataSource = this.productExamDataSet;
            // 
            // productExamDataSet
            // 
            this.productExamDataSet.DataSetName = "ProductExamDataSet";
            this.productExamDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // productExamTableAdapter
            // 
            this.productExamTableAdapter.ClearBeforeFill = true;
            // 
            // productExamDataSetBindingSource
            // 
            this.productExamDataSetBindingSource.DataSource = this.productExamDataSet;
            this.productExamDataSetBindingSource.Position = 0;
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 24;
            this.listBox1.Location = new System.Drawing.Point(4, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(604, 244);
            this.listBox1.TabIndex = 3;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 256);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(148, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Добавить товар";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(156, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(224, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Редактировать произвольные атрибуты";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(384, 256);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(224, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Детальная информация";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 283);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Exam";
            ((System.ComponentModel.ISupportInitialize)(this.productExamBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productExamDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productExamDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ProductExamDataSet productExamDataSet;
        private System.Windows.Forms.BindingSource productExamBindingSource;
        private ProductExamDataSetTableAdapters.ProductExamTableAdapter productExamTableAdapter;
        private System.Windows.Forms.BindingSource productExamDataSetBindingSource;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
    }
}

