namespace PruebaHpTronic.Consulta
{
    partial class BancoReporte
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
            this.BancocrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // BancocrystalReportViewer1
            // 
            this.BancocrystalReportViewer1.ActiveViewIndex = -1;
            this.BancocrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BancocrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.BancocrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BancocrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.BancocrystalReportViewer1.Name = "BancocrystalReportViewer1";
            this.BancocrystalReportViewer1.Size = new System.Drawing.Size(800, 450);
            this.BancocrystalReportViewer1.TabIndex = 0;
            this.BancocrystalReportViewer1.Load += new System.EventHandler(this.BancocrystalReportViewer1_Load);
            // 
            // BancoReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BancocrystalReportViewer1);
            this.Name = "BancoReporte";
            this.Text = "BancoReporte";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer BancocrystalReportViewer1;
    }
}