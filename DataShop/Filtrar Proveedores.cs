using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NEGOCIO;
using ENTIDAD;

namespace DataShop
{
    public partial class Filtrar_Proveedores : Form
    {
        string global;
        string globalActualizar;
        public Filtrar_Proveedores()
        {
            InitializeComponent();
        }

        private void irParaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores prov = new Proveedores();
            prov.Show();
            this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            n_proveedor reg = new n_proveedor();
            reg.eliminarproveedor(global);
            MessageBox.Show("Eliminado correctamente");

            n_proveedor prov = new n_proveedor();
            dataProveedor.DataSource = prov.getTabla();
        }

        private void Filtrar_Proveedores_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            n_proveedor prov = new n_proveedor();
            dataProveedor.DataSource = prov.getTabla();


            if (VariablesGlobales.tipoUsuario == "False")
            {
                btnModificar.Enabled = false;

            }
            if (VariablesGlobales.tipoUsuario == "False")
            {
                btnEliminar.Enabled = false;

            }
            if (VariablesGlobales.tipoUsuario == "False")
            {
                aviso.Visible = true;

            }
            if (VariablesGlobales.tipoUsuario == "True")
            {
                aviso.Visible = false;

            }
        }

        private void dataProveedor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataProveedor.Rows[e.RowIndex];
                global = row.Cells["id_proveedor"].Value.ToString();

                globalActualizar = row.Cells["id_proveedor"].Value.ToString() + "," + row.Cells["id_producto"].Value.ToString() + "," +
                row.Cells["Nombre"].Value.ToString() + "," + row.Cells["Dirección"].Value.ToString() + "," + row.Cells["Telefono"].Value.ToString() + "," +
                row.Cells["Localidad"].Value.ToString();
                    }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
          
            n_proveedor reg = new n_proveedor();
            reg.ActualizarProveedor(globalActualizar);
            MessageBox.Show("Modificado correctamente");
            n_proveedor prov = new n_proveedor();
            dataProveedor.DataSource = prov.getTabla();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbx_id.Text) && string.IsNullOrEmpty(tbx_nombre.Text)
            && string.IsNullOrEmpty(tbx_nombre.Text) && string.IsNullOrEmpty(tbx_telefono.Text))
            {
                n_proveedor reg = new n_proveedor();
                dataProveedor.DataSource = reg.getTabla();
            }



            if (!string.IsNullOrEmpty(tbx_id.Text))
            {
                ((DataTable)dataProveedor.DataSource).DefaultView.RowFilter = "id_proveedor=" + tbx_id.Text;
            }

            if (!string.IsNullOrEmpty(tbx_localidad.Text))
            {
                ((DataTable)dataProveedor.DataSource).DefaultView.RowFilter = "Localidad=" + "'" + tbx_localidad.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbx_nombre.Text))
            {
                ((DataTable)dataProveedor.DataSource).DefaultView.RowFilter = "Nombre=" + "'" + tbx_nombre.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbx_telefono.Text))
            {
                ((DataTable)dataProveedor.DataSource).DefaultView.RowFilter = "Telefono=" + "'" + tbx_telefono.Text + "'";
            }


        }



        private void btn_limpiar_Click(object sender, EventArgs e)
        {
            
            tbx_id.Text = String.Empty;
            tbx_localidad.Text = String.Empty;
            tbx_nombre.Text = String.Empty;
            n_proveedor reg = new n_proveedor();
            dataProveedor.DataSource = reg.getTabla();
        }
    }
}
