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

namespace Pea2.Appwin_
{
    public partial class frmProductoEdit : Form
    {
        Producto producto;
        public frmProductoEdit(Producto producto)
        {
            InitializeComponent();
            this.producto = producto;
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            asignarObjeto();
            this.DialogResult = DialogResult.OK;
        }

        private void frmProductoEdit_Load(object sender, EventArgs e)
        {
            cargarDatos();
            if (producto.IdProducto > 0)
            {
                asignarControles();
            }
        }
            private void cargarDatos()
            {

                cboCategoria.DataSource = CategoriaBL.Listar();
                cboCategoria.DisplayMember = "Nombre";
                cboCategoria.ValueMember = "IdCategoria";

            }
        private void asignarObjeto()
        {
            producto.Nombre = txtNombre.Text;
            producto.Marca = txtMarca.Text;
            producto.Precio = double.Parse(txtPrecio.Text.ToString()); ;
            producto.Stock = int.Parse(txtStock.Text.ToString());
            producto.Observacion = txtObser.Text;
            producto.IdCategoria = int.Parse(cboCategoria.SelectedValue.ToString());
        }
        private void asignarControles()
        {
            txtNombre.Text = producto.Nombre;
            txtMarca.Text = producto.Marca;
            double.Parse(txtPrecio.Text = producto.Precio.ToString());
            int.Parse(txtStock.Text = producto.Stock.ToString());
            txtObser.Text = producto.Observacion;
            cboCategoria.SelectedValue = producto.IdCategoria;
        }
    }
}
