using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEGOCIO;
using ENTIDAD;

namespace DataShop
{
    public partial class Proveedores : Form
    {
        public Proveedores()
        {
            InitializeComponent();
        }

        private void Proveedores_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            n_proveedor n_prov = new n_proveedor();
            dataProveedor.DataSource = n_prov.getTabla();
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();

            
            hijo.Show();
            hijo.Location = this.Location;
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtrar_Proveedores Filt = new Filtrar_Proveedores();
            Filt.Show();
            Filt.Location = this.Location;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            label6.Text = DateTime.Now.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataProveedor.Rows[e.RowIndex];
                tbxId.Text = row.Cells["id_proveedor"].Value.ToString();
                tbxNombre.Text = row.Cells["Nombre"].Value.ToString();
                tbxDireccion.Text = row.Cells["Dirección"].Value.ToString();
                tbxTelefono.Text = row.Cells["Telefono"].Value.ToString();
                tbxLocalidad.Text = row.Cells["Localidad"].Value.ToString();

            }
        }
    }
}
