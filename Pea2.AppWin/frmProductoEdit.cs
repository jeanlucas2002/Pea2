using Pea.Dominio;
using Pea2.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pea2.AppWin
{
    public partial class frmProductoEdit : Form
    {
        Producto producto;
        public frmProductoEdit()
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void frmProductoEdit_Load(object sender, EventArgs e)
        {
            cargarDatos();
            if (producto.ID > 0)
            {
                asignarControles();
            }
        }
        private void cargarDatos()
        {
          

            //Listar los tipos de clientes
            cboCategoria.DataSource = CategoriaBL.Listar();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "IdCategoria";

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }
        private void asignarObjeto()
        {
            Categoria.Nombre = txtNombre.Text;
            Categoria.Apellidos = txtApellido.Text;
            Categoria.Direccion = txtDireccion.Text;
            Categoria.Referencia = txtReferencia.Text;
            Categoria.IdTipoCliente = int.Parse(cboTipoCliente.SelectedValue.ToString());
            Categoria.IdTipoDocumento = int.Parse(cboTipoDocumento.SelectedValue.ToString());
            Categoria.NumeroDocumento = txtNumeroDocumento.Text;
            Categoria.Estado = chkEstado.Checked;
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cboTipoCliente_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkEstado_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
