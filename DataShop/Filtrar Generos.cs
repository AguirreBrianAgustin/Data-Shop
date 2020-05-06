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
    public partial class Filtrar_Generos : Form
    {
        string global;
        string globalModificar;
        int posicion = 1;

        string idGenero_Prodcuto;
        string id_genero;

        public Filtrar_Generos()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void irParaAtrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar_Generos generos = new Listar_Generos();
            this.Close();
            generos.Show();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Filtrar_Generos_Load(object sender, EventArgs e)
        {
            n_producto pro = new n_producto();
            dgv_productos.DataSource = pro.getTabla();

            n_genero generos = new n_genero();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            dataGeneros.DataSource = generos.getTabla();


            timer1.Enabled = true;
        }

        private void adelante_Click(object sender, EventArgs e)
        {
            n_genero genero = new n_genero();
            dataGeneros.DataSource = genero.getTabla();
            ///int limite = dataMarcas.Rows.Count-1;






            if (posicion < dataGeneros.Rows.Count)
            {

                tbx_id.Text = genero.get(posicion).getid_genero().ToString();
                txb_nombre.Text = genero.get(posicion).getnombre();
                posicion++;

            }
        }

        private void atras_Click(object sender, EventArgs e)
        {
            n_genero gene = new n_genero();
            //int limite = dataMarcas.Rows.Count;


            if (posicion <= dataGeneros.Rows.Count && posicion > 1)
            {
                posicion--;
                tbx_id.Text = gene.get(posicion).getid_genero().ToString();
                txb_nombre.Text = gene.get(posicion).getnombre();


            }

        }

        private void ultimo_Click(object sender, EventArgs e)
        {
            n_genero gen = new n_genero();
            dataGeneros.DataSource = gen.getTabla();
            int posicion = dataGeneros.Rows.Count - 1;






            tbx_id.Text = gen.get(posicion).getid_genero().ToString();
            txb_nombre.Text = gen.get(posicion).getnombre();
        }

        private void primero_Click(object sender, EventArgs e)
        {
            posicion = 1;
            n_genero gene = new n_genero();
            tbx_id.Text = gene.get(posicion).getid_genero().ToString();
            txb_nombre.Text = gene.get(posicion).getnombre();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString();
        }

        private void dataGeneros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGeneros.Rows[e.RowIndex];
                global = row.Cells["id_genero"].Value.ToString();
                globalModificar /*= global*/ = row.Cells["id_genero"].Value.ToString() + "," + row.Cells["descripcion"].Value.ToString();
                id_genero = global = row.Cells["id_genero"].Value.ToString();
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_productos.Rows)
            {
                if (row.Cells["id_genero"].Value == null)
                {
                    n_genero gen = new n_genero();
                    gen.eliminarGenero(global);
                    MessageBox.Show("Eliminado correctamente");
                    dataGeneros.DataSource = gen.getTabla();
                    return;
                }
                ///MessageBox.Show(row.Cells["id_marca"].Value.ToString());
                idGenero_Prodcuto = row.Cells["id_genero"].Value.ToString();
                if (idGenero_Prodcuto == id_genero)
                {
                    MessageBox.Show("Genero vinculado a producto");
                    return;
                }


            }





            //n_genero genero = new n_genero();
            //genero.eliminarGenero(global);
            //MessageBox.Show("Eliminado correctamente");
            //dataGeneros.DataSource = genero.getTabla();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            n_genero genero = new n_genero();
            genero.actualizarGenero(globalModificar);
            MessageBox.Show("Modificado correctamente");
            dataGeneros.DataSource = genero.getTabla();
        }
    }
}
