namespace PruebaHpTronic.Consulta
{
    partial class TransaccionesReporte
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
            this.TransaccionescrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // TransaccionescrystalReportViewer1
            // 
            this.TransaccionescrystalReportViewer1.ActiveViewIndex = -1;
            this.TransaccionescrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TransaccionescrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.TransaccionescrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TransaccionescrystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.TransaccionescrystalReportViewer1.Name = "TransaccionescrystalReportViewer1";
            this.TransaccionescrystalReportViewer1.Size = new System.Drawing.Size(800, 450);
            this.TransaccionescrystalReportViewer1.TabIndex = 0;
            this.TransaccionescrystalReportViewer1.Load += new System.EventHandler(this.TransaccionescrystalReportViewer1_Load);
            // 
            // TransaccionesReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TransaccionescrystalReportViewer1);
            this.Name = "TransaccionesReporte";
            this.Text = "TransaccionesReporte";
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer TransaccionescrystalReportViewer1;
    }
}