namespace MovieRentalSystem
{
    partial class Reports
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
            this.gridc = new System.Windows.Forms.DataGridView();
            this.gridm = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridm)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.gridc.AllowUserToAddRows = false;
            this.gridc.AllowUserToDeleteRows = false;
            this.gridc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridc.Location = new System.Drawing.Point(12, 12);
            this.gridc.Name = "dataGridView1";
            this.gridc.ReadOnly = true;
            this.gridc.Size = new System.Drawing.Size(782, 195);
            this.gridc.TabIndex = 0;
            // 
            // dataGridView2
            // 
            this.gridm.AllowUserToAddRows = false;
            this.gridm.AllowUserToDeleteRows = false;
            this.gridm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridm.Location = new System.Drawing.Point(12, 252);
            this.gridm.Name = "dataGridView2";
            this.gridm.ReadOnly = true;
            this.gridm.Size = new System.Drawing.Size(782, 195);
            this.gridm.TabIndex = 1;
            // 
            // Reports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 460);
            this.Controls.Add(this.gridm);
            this.Controls.Add(this.gridc);
            this.Name = "Reports";
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.Reports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridc;
        private System.Windows.Forms.DataGridView gridm;
    }
}