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
    public partial class rBanco : Form
    {
        public rBanco()
        {
            InitializeComponent();
        }

        private Banco GetData()
        {
            return new Banco(IDtextBox.Text != string.Empty ? IDtextBox.Text.Toint() : 0, NombretextBox.Text, CuentatextBox.Text);
        }

        void Clean()
        {
            IDtextBox.Clear();
            NombretextBox.Clear();
            CuentatextBox.Clear();
            IDerrorProvider.Clear();
            NombreerrorProvider.Clear();
            CuentaerrorProvider.Clear();

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (SetError(1))
                return;

            if (IDtextBox.Text == string.Empty)
            {
                if (BLL.BancoBLL.Insertar(GetData()))
                {
                    MessageBox.Show("Guardado!");
                    Clean();
                }
                else
                {
                    MessageBox.Show("No pudo Guardar!");
                }
            }
            else
            {
                if (BLL.BancoBLL.Modificar(GetData()))
                {
                    MessageBox.Show("Modificado!");
                    Clean();
                }
                else
                {
                    MessageBox.Show("No pudo Modificar!");
                }
            }

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (SetError(2))
                return;

            if (IDtextBox.Text != string.Empty)
            {
                if (BLL.BancoBLL.Eliminar(IDtextBox.Text.Toint()))
                {
                    MessageBox.Show("Eliminado!");
                    Clean();
                }
                else
                {
                    MessageBox.Show("No pudo Eliminar!");
                }
            }
        }

        private bool SetError(int error)
        {
            bool paso = false;
            if (error == 1 && NombretextBox.Text.Equals(string.Empty))
            {
                NombreerrorProvider.SetError(NombretextBox, "El nombre no puede estar vacio!");
                paso = true;
            }
            if (error == 1 && CuentatextBox.Text.Equals(string.Empty))
            {
                CuentaerrorProvider.SetError(CuentatextBox, "La cuenta no puede estar vacio!");
                paso = true;
            }
            if (error == 2 && IDtextBox.Text.Equals(string.Empty))
            {
                IDerrorProvider.SetError(IDtextBox, "Debe Seleccionar un ID!");
                paso = true;
            }


            return paso;
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            VentanaBuscarBanco ventana = new VentanaBuscarBanco();
            ventana.ShowDialog();
            SetData(BLL.Utils.banco);

        }

        private void SetData(Banco banco)
        {
            if (banco != null)
                if (banco.Id != 0)
                {
                    IDtextBox.Text = banco.Id.ToString();
                    NombretextBox.Text = banco.Nombre;
                    CuentatextBox.Text = banco.Cuenta;

                }
                else
                {
                    MessageBox.Show("No se selecciono ninguna Cuenta Bancaria");
                }
            else
            {
                MessageBox.Show("No se selecciono ninguna Cuenta Bancaria");
            }

        }
    }
}
