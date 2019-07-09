using PruebaHpTronic.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PruebaHpTronic.Registro
{
    public partial class VentanaBuscarBanco : Form
    {
        public List<Banco> Banco { get; set; }
        public VentanaBuscarBanco()
        {
            InitializeComponent();
        }

        private void BuscarbancodataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            BLL.Utils.banco = Banco.ElementAt(e.RowIndex);
            this.Close();
        }

        private void CriteriotextBox_TextChanged(object sender, EventArgs e)
        {
            Banco = BLL.BancoBLL.GetListBuscar(CriteriotextBox.Text);
            BuscarbancodataGridView.DataSource = Banco;
        }
    }
}
