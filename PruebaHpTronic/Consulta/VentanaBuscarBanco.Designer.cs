namespace PruebaHpTronic.Registro
{
    partial class VentanaBuscarBanco
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
            this.BuscarbancodataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.CriteriotextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.BuscarbancodataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BuscarbancodataGridView
            // 
            this.BuscarbancodataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BuscarbancodataGridView.Location = new System.Drawing.Point(6, 12);
            this.BuscarbancodataGridView.Name = "BuscarbancodataGridView";
            this.BuscarbancodataGridView.Size = new System.Drawing.Size(365, 196);
            this.BuscarbancodataGridView.TabIndex = 0;
            this.BuscarbancodataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BuscarbancodataGridView_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Criterio";
            // 
            // CriteriotextBox
            // 
            this.CriteriotextBox.Location = new System.Drawing.Point(51, 214);
            this.CriteriotextBox.Name = "CriteriotextBox";
            this.CriteriotextBox.Size = new System.Drawing.Size(121, 20);
            this.CriteriotextBox.TabIndex = 2;
            this.CriteriotextBox.TextChanged += new System.EventHandler(this.CriteriotextBox_TextChanged);
            // 
            // VentanaBuscarBanco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 247);
            this.Controls.Add(this.CriteriotextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuscarbancodataGridView);
            this.MaximizeBox = false;
            this.Name = "VentanaBuscarBanco";
            this.Text = "VentanaBuscarBanco";
            ((System.ComponentModel.ISupportInitialize)(this.BuscarbancodataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BuscarbancodataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox CriteriotextBox;
    }
}