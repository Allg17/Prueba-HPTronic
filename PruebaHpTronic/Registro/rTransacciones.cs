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
using Utilidades_Albert;

namespace PruebaHpTronic.Registro
{
    public partial class rTransacciones : Form
    {
        List<Transacciones> transacciones = new List<Transacciones>();
        int SelectedRow;
        public rTransacciones()
        {
            InitializeComponent();
            FillBancoComboBox();
        }

        private void FillBancoComboBox()
        {
            //Llena el ComboBox
            BancocomboBox.DisplayMember = "Nombre";
            BancocomboBox.ValueMember = "Id";
            BancocomboBox.DataSource = BLL.BancoBLL.GetListBuscar();
        }

        private void BancocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Busca en la base de datos al cambiar el index del comboBox
            transacciones = BLL.TransaccionesBLL.GetListBuscar(BancocomboBox.SelectedValue.Toint());
            if (transacciones.Count == 0)
            {
                AgregarNuevo();
            }
            FillGrid();
        }

        private void FillbalanceTxt()
        {
            //Llena el TextBox Balance
            decimal Monto = 0;

            foreach (var item in transacciones)
            {

                Monto += item.Monto;

            }

            BalancetextBox.Text = Monto.ToString();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (BancocomboBox.SelectedValue != null)
            {
                transacciones = BLL.TransaccionesBLL.GetListBuscar(BancocomboBox.SelectedValue.Toint(), DesdedateTimePicker.Value.Date, HastadateTimePicker.Value.Date);
                if(transacciones.Count == 0)
                {
                    AgregarNuevo();
                }
                FillGrid();

            }
        }

        private void AgregarNuevo()
        {
            transacciones.Add(new Transacciones(0, BancocomboBox.SelectedValue.Toint(), "", DateTime.Now, "", 0));
            
        }

        private void FillGrid()
        {
            //LLena y crea las columnas del Grid
            BancodataGridView.DataSource = null;
            BancodataGridView.ColumnCount = 6;

            BancodataGridView.Columns[0].HeaderText = "ID";
            BancodataGridView.Columns[0].Name = "Id";
            BancodataGridView.Columns[0].DataPropertyName = "Id";

            BancodataGridView.Columns[1].HeaderText = "Id_Banco";
            BancodataGridView.Columns[1].Name = "Id_Banco";
            BancodataGridView.Columns[1].DataPropertyName = "Id_Banco";

            BancodataGridView.Columns[2].HeaderText = "Tipo";
            BancodataGridView.Columns[2].Name = "Tipo";
            BancodataGridView.Columns[2].DataPropertyName = "Tipo";

            BancodataGridView.Columns[3].HeaderText = "Fecha";
            BancodataGridView.Columns[3].Name = "Fecha";
            BancodataGridView.Columns[3].DataPropertyName = "Fecha";

            BancodataGridView.Columns[4].HeaderText = "Detalle";
            BancodataGridView.Columns[4].Name = "Detalle";
            BancodataGridView.Columns[4].DataPropertyName = "Detalle";

            BancodataGridView.Columns[5].HeaderText = "Monto";
            BancodataGridView.Columns[5].Name = "Monto";
            BancodataGridView.Columns[5].DataPropertyName = "Monto";

            BancodataGridView.Columns[0].ReadOnly = true;
            BancodataGridView.Columns[1].ReadOnly = true;


            BancodataGridView.DataSource = transacciones;

            FillbalanceTxt();
        }

        private void BancodataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            //Evento que captura al pulsar una tecla
            if (e.KeyCode == Keys.Enter)
            {
                AgregarNuevo();
                FillGrid();
            }
            if (e.KeyCode == Keys.Delete)
            {
                if (SelectedRow >= 0 && transacciones.Count > 0 && transacciones.Count > SelectedRow)
                    transacciones.RemoveAt(SelectedRow);
                FillGrid();
            }
        }

        private void BancodataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectedRow = e.RowIndex;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Validar())
                return;

            if (BLL.TransaccionesBLL.Operacion(transacciones))
            {
                MessageBox.Show("Operacion Ejecutada Exitosamente!");
            }
            else
            {
                MessageBox.Show("Ocurrio un Error en la Ejecucion!");
            }
        }

        private void BancodataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //Esto es para asegurarnos de que siempre se escriban el valor deseado en la columna tipo
            FillbalanceTxt();
            if (e.RowIndex >= 0)
                if (BancodataGridView[2, e.RowIndex].Value.ToString() != string.Empty)
                    if (BancodataGridView[2, e.RowIndex].Value.ToString()[0] == 'D' || BancodataGridView[2, e.RowIndex].Value.ToString()[0] == 'd')
                    {
                        BancodataGridView[2, e.RowIndex].Value = "Deposito";
                    }
                    else
                    {
                        BancodataGridView[2, e.RowIndex].Value = "Retiro";
                    }
            MarcarNegativo(e.RowIndex);
        }

        private void BancodataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //Evento que ocurre al dejar una celda
            if (transacciones.Count >= e.RowIndex)
            {
                if (BancodataGridView.CurrentCell.ColumnIndex != 5)
                    MarcarNegativo(e.RowIndex);

                FillbalanceTxt();
            }

        }

        private void MarcarNegativo(int index)
        {
            //Funcion para volver negativo o positivo el monto segun corresponda en caso de no encontrarse de manera correcta.
            if (index >= 0)
            {
                if (BancodataGridView[2, index].Value == "Retiro")
                {
                    if (BancodataGridView[5, index].Value.Todecimal() > 0)
                    {
                        decimal cadena = -1 * BancodataGridView[5, index].Value.Todecimal();
                        BancodataGridView[5, index].Value = cadena;
                    }

                }
                else
                {
                    if (BancodataGridView[5, index].Value.Todecimal() < 0)
                    {
                        decimal cadena = -1 * BancodataGridView[5, index].Value.Todecimal();
                        BancodataGridView[5, index].Value = cadena;
                    }
                }
            }


        }

        private bool Validar()
        {
            bool paso = false;
            foreach (var item in transacciones)
            {
                if(item.Tipo ==string.Empty || item.Detalle ==string.Empty || item.Monto ==0)
                {
                    MessageBox.Show("No puede guardar sin antes completar las Celdas vacias o Agregado un Monto!!");
                    paso = true;
                }
            }

            return paso;
        }
    }
}
