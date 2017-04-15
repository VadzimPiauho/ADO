namespace dz2
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.продажиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._sale_mdbDataSet = new dz2._sale_mdbDataSet();
            this.продавцыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.покупателиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.покупателиTableAdapter = new dz2._sale_mdbDataSetTableAdapters.ПокупателиTableAdapter();
            this.продавцыTableAdapter = new dz2._sale_mdbDataSetTableAdapters.ПродавцыTableAdapter();
            this.продажиTableAdapter = new dz2._sale_mdbDataSetTableAdapters.ПродажиTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.продажиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sale_mdbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.продавцыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.покупателиBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(220, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(595, 380);
            this.dataGridView1.TabIndex = 1;
            // 
            // продажиBindingSource
            // 
            this.продажиBindingSource.DataMember = "Продажи";
            this.продажиBindingSource.DataSource = this._sale_mdbDataSet;
            // 
            // _sale_mdbDataSet
            // 
            this._sale_mdbDataSet.DataSetName = "_sale_mdbDataSet";
            this._sale_mdbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // продавцыBindingSource
            // 
            this.продавцыBindingSource.DataMember = "Продавцы";
            this.продавцыBindingSource.DataSource = this._sale_mdbDataSet;
            // 
            // покупателиBindingSource
            // 
            this.покупателиBindingSource.DataMember = "Покупатели";
            this.покупателиBindingSource.DataSource = this._sale_mdbDataSet;
            // 
            // покупателиTableAdapter
            // 
            this.покупателиTableAdapter.ClearBeforeFill = true;
            // 
            // продавцыTableAdapter
            // 
            this.продавцыTableAdapter.ClearBeforeFill = true;
            // 
            // продажиTableAdapter
            // 
            this.продажиTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 435);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(535, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(597, 477);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.продажиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sale_mdbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.продавцыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.покупателиBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private _sale_mdbDataSet _sale_mdbDataSet;
        private System.Windows.Forms.BindingSource покупателиBindingSource;
        private _sale_mdbDataSetTableAdapters.ПокупателиTableAdapter покупателиTableAdapter;
        private System.Windows.Forms.BindingSource продавцыBindingSource;
        private _sale_mdbDataSetTableAdapters.ПродавцыTableAdapter продавцыTableAdapter;
        private System.Windows.Forms.BindingSource продажиBindingSource;
        private _sale_mdbDataSetTableAdapters.ПродажиTableAdapter продажиTableAdapter;
        private System.Windows.Forms.Button button1;
    }
}

