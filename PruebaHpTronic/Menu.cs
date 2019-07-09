using PruebaHpTronic.Consulta;
using PruebaHpTronic.Registro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaHpTronic
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void BancoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rBanco banco = new rBanco();
            banco.MdiParent = this;
            banco.Show();

        }

        private void TransaccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTransacciones rTransacciones = new rTransacciones();
            rTransacciones.MdiParent = this;
            rTransacciones.Show();
        }

        private void reporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransaccionesReporte abrir = new TransaccionesReporte();
            abrir.MdiParent = this;
            abrir.Show();
        }

        private void reporteCuentasBancariasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BancoReporte bancoReporte = new BancoReporte();
            bancoReporte.MdiParent = this;
            bancoReporte.Show();
        }
    }
}
