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
    public partial class Listar_Marcas : Form
    {
        public Listar_Marcas()
        {
            InitializeComponent();
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            this.Close();
            menu.Show();

        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtrar_Marcas marca = new Filtrar_Marcas();
            this.Close();
            marca.Show();
        }

        private void Listar_Marcas_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
            n_marca n_cat = new n_marca();
            dataGridView2.DataSource = n_cat.getTabla();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
