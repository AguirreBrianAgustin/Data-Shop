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
    public partial class Reporte1 : Form
    {
        public Reporte1()
        {
            InitializeComponent();
        }

        private void Reporte1_Load(object sender, EventArgs e)
        {
            n_venta n_venta = new n_venta();
            data_ventas.DataSource = n_venta.getTabla();

            n_detalle_de_venta detalle = new n_detalle_de_venta();
            data_detalle.DataSource = detalle.getTabla();

            
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                MenuPrincipal hijo = new MenuPrincipal();

                hijo.Show();
                hijo.Show();
                hijo.Location = this.Location;
                this.Hide();
            }
        }
    }
}
