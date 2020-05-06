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
/// <summary>
/// 31/10/2018  23:40 VERSION
/// </summary>
namespace DataShop
{
    public partial class Clientes : Form
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Clientes_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            n_cliente n_cat = new n_cliente();
            dataCliente.DataSource = n_cat.getTabla();
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();

            hijo.Show();
            hijo.Location = this.Location;
            this.Hide();
        }

        private void filtrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filtrar_Cliente filtrar = new Filtrar_Cliente();
            
            filtrar.Show();
            filtrar.Location = this.Location;
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataCliente.Rows[e.RowIndex];
                tbxNombre.Text = row.Cells["Nombre"].Value.ToString();
                tbxDNI.Text = row.Cells["dni"].Value.ToString();
                tbxDireccion.Text = row.Cells["Direccion"].Value.ToString();
                tbxTelefono.Text = row.Cells["Telefono"].Value.ToString();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }
    }
}
