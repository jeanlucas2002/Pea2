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
    public partial class frmProducto1 : Form
    {
        public frmProducto1()
        {
            InitializeComponent();
        }
        private void cargarDatos()
        {
            var listado = ProductoBL.Listar();
            dgvListado.Rows.Clear();
            foreach (var producto in listado)
            {
                dgvListado.Rows.Add(producto.IdProducto, producto.Nombre, producto.Marca, producto.Precio);
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            var nuevoProducto = new Producto();
            var frm = new frmProductoEdit(nuevoProducto);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                var exito = ProductoBL.Insertar(nuevoProducto);
                if (exito)
                {
                    MessageBox.Show("El Producto ha sido registrado", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
                else
                {
                    MessageBox.Show("No se ha podido registrar el Producto ", "Parcial",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void frmProducto1_Load(object sender, EventArgs e)
        {
            cargarDatos();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idProducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var productoEditar = ProductoBL.BuscarPorId(idProducto);
                var frm = new frmProductoEdit(productoEditar);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    var exito = ProductoBL.Actualizar(productoEditar);
                    if (exito)
                    {
                        MessageBox.Show("El producto ha sido actualizado", "Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la operación de actualización",
                            "Financiera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            if (dgvListado.Rows.Count > 0)
            {
                int filaActual = dgvListado.CurrentRow.Index;
                var idProducto = int.Parse(dgvListado.Rows[filaActual].Cells[0].Value.ToString());
                var nombreProducto = dgvListado.Rows[filaActual].Cells[1].Value.ToString();
                var rpta = MessageBox.Show("¿Realmente desea eliminar al producto " + nombreProducto + " ?",
                    "Parcial", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rpta == DialogResult.Yes)
                {
                    var exito = ProductoBL.Eliminar(idProducto);
                    if (exito)
                    {
                        MessageBox.Show("El Producto ha sido eliminado.", "Parcial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarDatos();
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido completar la eliminación del Producto",
                            "Financiera", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

}
