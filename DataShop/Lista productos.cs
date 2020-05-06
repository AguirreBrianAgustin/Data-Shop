using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NEGOCIO;
using ENTIDAD;

namespace DataShop
{
    public partial class Lista_productos : Form
    {
        ///int idAuxiliar;
        string nombreTapa;
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        public Lista_productos()
        {      
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();
            
            hijo.Show();
            hijo.Show();
            hijo.Location = this.Location;
            this.Hide();

        }

        private void volverAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();

            hijo.Show();
            hijo.Show();
            hijo.Location = this.Location;
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BTNCARGARProductos_Click(object sender, EventArgs e)
        {

        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtrar_Productos Filt = new Filtrar_Productos();

            Filt.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }


        private void Lista_productos_Load(object sender, EventArgs e)
        {
            
            timer2.Enabled = true;
            n_producto n_prod = new n_producto();
            dataProducto.DataSource = n_prod.getTablaInner();
            



            n_marca marc = new n_marca();
            n_pegi peg = new n_pegi();

            foreach (DataGridViewRow row in dataProducto.Rows)
            {
                var stock = Convert.ToInt32(row.Cells[5].Value);

                /// MODIFICACIÓN JOSE AL 8/2/2019
                if (stock <= 4 && stock > 0)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                if (stock >= 5 && stock <= 19)
                {
                    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                }
                if (stock >= 20 && stock <= 999)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                }


                /// MODIFICACIÓN JOSE AL 8/2/2019


                //if (stock <= 4 && stock != 0)
                //{
                //    row.DefaultCellStyle.BackColor = Color.Red;
                //}
                //if (stock >= 5 && stock <= 15)
                //{
                //    row.DefaultCellStyle.BackColor = Color.LightSalmon;
                //}
                //if (stock >= 20 && stock <= 49)
                //{
                //    row.DefaultCellStyle.BackColor = Color.LightGreen;
                //}
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = this.dataProducto.Rows[e.RowIndex];

                tbxID.Text = row.Cells["Id_Producto"].Value.ToString();
                tbxNombre.Text = row.Cells["Nombre"].Value.ToString();
                tbxMarca.Text = row.Cells["Id_Marca"].Value.ToString();
                tbxGenero.Text = row.Cells["Id_Genero"].Value.ToString();
                tbxPEGI.Text = row.Cells["Id_Pegi"].Value.ToString();
                tbxStock.Text = row.Cells["Stock"].Value.ToString();
                tbxDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                tbxPrecioxunidad.Text = row.Cells["Precio_X_Unidad"].Value.ToString();



                //tbxNombre.Text = row.Cells["ID_Producto"].Value.ToString();
                //tbxGenero.Text = row.Cells["Nombre"].Value.ToString();
                //tbxID.Text = row.Cells["ID_Marca"].Value.ToString();
                //tbxPEGI.Text = row.Cells["ID_Genero"].Value.ToString();
                //tbxPrecioxunidad.Text = row.Cells["ID_Pegi"].Value.ToString();
                //tbxStock.Text = row.Cells["Stock"].Value.ToString();
                //tbxDescripcion.Text = row.Cells["Descripcion"].Value.ToString();
                //tbxMarca.Text = row.Cells["Precio_X_Unidad"].Value.ToString();
                ///idAuxiliar = Convert.ToInt32(tbxID.Text);
                /// TESTEO IMAGEN
                /// 

                //foreach (string file in Directory.EnumerateFiles(directory + "\\Portadas\\", "*.jpg"))
                //{
                //    string contents = File.ReadAllText(file);
                //    MessageBox.Show(contents);
                //}

                nombreTapa = tbxNombre.Text;

                DirectoryInfo d = new DirectoryInfo(@"" + directory + "\\Portadas\\");//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles("*.jpg"); //Getting Text files
                string str = "";
                pictureBox1.Image = null;
                foreach (FileInfo file in Files)
                {
                    str = file.Name;
                    ///essageBox.Show(str);

                    if (nombreTapa+".jpg" == file.Name)
                    {
                        pictureBox1.Image = Image.FromFile(directory + "\\Portadas\\"+ str);
                        ///MessageBox.Show("correcto");
                    }

                }













            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label10.Text = DateTime.Now.ToString();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void dataProducto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
