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
    public partial class Filtrar_Marcas : Form
    {
        string global;
        string globalModificar;

        int posicion = 1;

        string idMarca_Prodcuto;
        string id_marca;

        public Filtrar_Marcas()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void irParaAtrásToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar_Marcas marca = new Listar_Marcas();
            this.Close();
            marca.Show();
        }

        private void Filtrar_Marcas_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;

            n_producto pro = new n_producto();
            dgv_prodcutos.DataSource = pro.getTabla();


            timer1.Enabled = true;
            n_marca marc = new n_marca();
            dataMarcas.DataSource = marc.getTabla();

            /// OJO!!! MODIFICACION DEL DIA 9/02

            ///tbx_id.Text = marc.get(posicion).getid_marca().ToString();
            ///tbx_nombre.Text = marc.get(posicion).getnombre();
            ///
            /// OJO!!! MODIFICACION DEL DIA 9/02

        }

        private void adelante_Click(object sender, EventArgs e)
        {
            n_marca marc = new n_marca();
            dataMarcas.DataSource = marc.getTabla();
            ///int limite = dataMarcas.Rows.Count-1;

            




            if (posicion < dataMarcas.Rows.Count)
            {

                tbx_id.Text = marc.get(posicion).getid_marca().ToString();
                tbx_nombre.Text = marc.get(posicion).getnombre();
                posicion++;
               
            }

        }

        private void atras_Click(object sender, EventArgs e)
        {
            n_marca marc = new n_marca();
            //int limite = dataMarcas.Rows.Count;

          
            if (posicion <= dataMarcas.Rows.Count && posicion > 1)
            {
                posicion--;
                tbx_id.Text = marc.get(posicion).getid_marca().ToString();
                tbx_nombre.Text = marc.get(posicion).getnombre();
                

            }


        }

        private void primero_Click(object sender, EventArgs e)
        {
            posicion = 1;
            n_marca marc = new n_marca();
            tbx_id.Text = marc.get(posicion).getid_marca().ToString();
            tbx_nombre.Text = marc.get(posicion).getnombre();
            
        }

        private void ultimo_Click(object sender, EventArgs e)
        { 
            n_marca marc = new n_marca();
            dataMarcas.DataSource = marc.getTabla();
            int posicion = dataMarcas.Rows.Count-1;
            
 
            



            tbx_id.Text = marc.get(posicion).getid_marca().ToString();
            tbx_nombre.Text = marc.get(posicion).getnombre();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_prodcutos.Rows)
            {
                if (row.Cells["id_marca"].Value == null)
                {
                    n_marca marca = new n_marca();
                    marca.eliminarMarca(global);
                    MessageBox.Show("Eliminado correctamente");
                    dataMarcas.DataSource = marca.getTabla();
                    return;
                }
                ///MessageBox.Show(row.Cells["id_marca"].Value.ToString());
                idMarca_Prodcuto = row.Cells["id_marca"].Value.ToString();
                if (idMarca_Prodcuto == id_marca)
                {
                    MessageBox.Show("Marca vinculada a producto");
                    return;
                }


            }
            

            //n_marca marca = new n_marca();
            //marca.eliminarMarca(global);
            //MessageBox.Show("Eliminado correctamente");
            //dataMarcas.DataSource = marca.getTabla();



        }

        private void dataMarcas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataMarcas.Rows[e.RowIndex];
                global = row.Cells["id_marca"].Value.ToString();
                globalModificar /*= global*/ = row.Cells["id_marca"].Value.ToString() + "," + row.Cells["nombre"].Value.ToString();
                id_marca = global = row.Cells["id_marca"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n_marca marca = new n_marca();
            marca.actualizarMarca(globalModificar);
            MessageBox.Show("Modificado correctamente");
            dataMarcas.DataSource = marca.getTabla();
        }
    }
}
