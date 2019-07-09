using PruebaHpTronic.Clases;
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
    public partial class BancoReporte : Form
    {
        public BancoReporte()
        {
            InitializeComponent();
        }

        private void BancocrystalReportViewer1_Load(object sender, EventArgs e)
        {
            ReporteBanco abrir = new ReporteBanco();
            abrir.SetDataSource(BLL.BancoBLL.GetListBuscar());
            BancocrystalReportViewer1.ReportSource = abrir;
            // ReporteFacturaViewer.SelectionFormula = "{View_Facturaciones}.Id=id"; {Facturaciones.ClienteId}=1
            BancocrystalReportViewer1.Refresh();
        }
    }
}
