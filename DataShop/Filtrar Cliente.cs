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
    public partial class Filtrar_Cliente : Form
    {
        string global;
        string globalModificar;
        public Filtrar_Cliente()
        {
            InitializeComponent();
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes hijo = new Clientes();


            hijo.Show();
            hijo.Location = this.Location;
            this.Close();
        }

        private void Filtrar_Cliente_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            n_cliente cliente = new n_cliente();
            dataCliente.DataSource = cliente.getTabla();

            if (VariablesGlobales.tipoUsuario == "False")
            {
                aviso.Visible = true;
                btnModificar.Enabled = false;
                btnEliminar.Enabled = false;

            }
            if (VariablesGlobales.tipoUsuario == "True")
            {
                aviso.Visible = false;


            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            n_cliente cliente = new n_cliente();
            dataCliente.DataSource = cliente.getTabla();
            tbxDireccion.Text = string.Empty;
            tbxId.Text = string.Empty;
            tbxNombre.Text = string.Empty;
            tbxTelefono.Text = string.Empty;
            tbx_dni.Text = string.Empty;

        }

        private void tbxId_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxNombre_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void tbxTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void dataCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = this.dataCliente.Rows[e.RowIndex];
                global= row.Cells["id_cliente"].Value.ToString();
                globalModificar /*= global*/ = row.Cells["id_cliente"].Value.ToString() + "," + row.Cells["dni"].Value.ToString() 
                  +"," + row.Cells["Nombre"].Value.ToString()  +"," + row.Cells["Direccion"].Value.ToString() + "," +
                     row.Cells["Telefono"].Value.ToString();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {



            n_cliente cliente = new n_cliente();
            cliente.eliminarcliente(global);
            MessageBox.Show("Eliminado correctamente");
            dataCliente.DataSource = cliente.getTabla();
          
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxId.Text) 
                && string.IsNullOrEmpty(tbxNombre.Text)
                && string.IsNullOrEmpty(tbxTelefono.Text)
                && string.IsNullOrEmpty(tbx_dni.Text)
                && string.IsNullOrEmpty(tbxDireccion.Text))
            {
                n_cliente reg = new n_cliente();
                dataCliente.DataSource = reg.getTabla();
            }

            if (!string.IsNullOrEmpty(tbxId.Text))
            {
                ((DataTable)dataCliente.DataSource).DefaultView.RowFilter = "ID_Cliente=" + tbxId.Text;
            }

            if (!string.IsNullOrEmpty(tbxNombre.Text))
            {
                ((DataTable)dataCliente.DataSource).DefaultView.RowFilter = "Nombre=" + "'" + tbxNombre.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbxTelefono.Text))
            {
                ((DataTable)dataCliente.DataSource).DefaultView.RowFilter = "Telefono=" + "'" + tbxTelefono.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbxDireccion.Text))
            {
                ((DataTable)dataCliente.DataSource).DefaultView.RowFilter = "Direccion=" + "'" + tbxDireccion.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbx_dni.Text))
            {
                ((DataTable)dataCliente.DataSource).DefaultView.RowFilter = "DNI=" + tbx_dni.Text;
            }
















            //      String rutaBDDataShop =
            //"Data Source=DESKTOP-C247IGF\\QLEXPRESS;Initial Catalog=DataShop;Integrated Security=True";


            //      SqlConnection cn = new SqlConnection(rutaBDDataShop);
            //      cn.Open();



            //      String consulta = "SELECT FROM CLIENTES WHERE id_cliente =  " +  tbxId; //+ global;
            //      SqlCommand comando = new SqlCommand(consulta, cn);
            //      comando.ExecuteNonQuery();

            //      n_cliente cliente = new n_cliente();
            //      dataCliente.DataSource = cliente.getTabla();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            n_cliente cliente = new n_cliente();
            cliente.actualizarCliente(globalModificar);
            MessageBox.Show("Modificado correctamente");
            dataCliente.DataSource = cliente.getTabla();
         
        }
    }
}
