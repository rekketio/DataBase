
namespace WindowsFormsApp2.Forms
{
	partial class MainForm
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
            this.carsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.accountsDataSet = new WindowsFormsApp2.Data.DataSets.AccountsDataSet();
            this.button1 = new System.Windows.Forms.Button();
            this.carsTableAdapter = new WindowsFormsApp2.Data.DataSets.AccountsDataSetTableAdapters.CarsTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp2.Data.DataSets.AccountsDataSetTableAdapters.TableAdapterManager();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // carsBindingSource
            // 
            this.carsBindingSource.DataMember = "Cars";
            this.carsBindingSource.DataSource = this.accountsDataSet;
            // 
            // accountsDataSet
            // 
            this.accountsDataSet.DataSetName = "AccountsDataSet";
            this.accountsDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 74);
            this.button1.TabIndex = 15;
            this.button1.Text = "Форма контрактов";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // carsTableAdapter
            // 
            this.carsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.CarsTableAdapter = this.carsTableAdapter;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp2.Data.DataSets.AccountsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 111);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 74);
            this.button2.TabIndex = 16;
            this.button2.Text = "Форма автомобилей";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 213);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 74);
            this.button3.TabIndex = 17;
            this.button3.Text = "Форма регистрации";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(160, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 19;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 324);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Основная форма";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accountsDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion
        private WindowsFormsApp2.Data.DataSets.AccountsDataSet accountsDataSet;
        private System.Windows.Forms.BindingSource carsBindingSource;
        private WindowsFormsApp2.Data.DataSets.AccountsDataSetTableAdapters.CarsTableAdapter carsTableAdapter;
        private WindowsFormsApp2.Data.DataSets.AccountsDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}