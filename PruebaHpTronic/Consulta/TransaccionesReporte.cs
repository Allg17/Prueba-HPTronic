using PruebaHpTronic.Reporte;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaHpTronic.Consulta
{
    public partial class TransaccionesReporte : Form
    {
        public TransaccionesReporte()
        {
            InitializeComponent();
        }

        private void TransaccionescrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReporteTransacciones abrir = new ReporteTransacciones();
            abrir.SetDataSource(BLL.BancoBLL.GetListAll());
            TransaccionescrystalReportViewer1.ReportSource = abrir;
            // ReporteFacturaViewer.SelectionFormula = "{View_Facturaciones}.Id=id"; {Facturaciones.ClienteId}=1
            TransaccionescrystalReportViewer1.Refresh();
        }
    }
}
