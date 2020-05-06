using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Data.SqlClient;
using NEGOCIO;
using ENTIDAD;

namespace DataShop
{

    
    public partial class Agregar_Producto : Form
    {
        string nombre;
        string direccion;
        string directory = AppDomain.CurrentDomain.BaseDirectory;
        public Agregar_Producto()
        {
            InitializeComponent();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();

            
            hijo.Show();
            hijo.Location = this.Location;
            this.Hide();
        }

        private void volverAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();


            hijo.Show();
            hijo.Location = this.Location;
            this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Agregar_Producto_Load(object sender, EventArgs e)
        {
            
            n_genero gen = new n_genero();
            dataGenero.DataSource = gen.getTabla();
            //int cantFilasGeneros = dataGenero.Rows.Count-1;


            n_marca marc = new n_marca();
            dataMarca.DataSource = marc.getTabla();
            //int cantFilasMarcas = dataMarca.Rows.Count-1;

            n_pegi peg = new n_pegi();
            dataPEGI.DataSource = peg.getTabla();
            //int cantFilasPegis = dataPEGI.Rows.Count - 1;

            n_producto reg = new n_producto();
            int resu;
            resu = reg.obtenercantidadderegistros();
            resu = resu + 1;
            tbx_id.Text = resu.ToString();





            //for (int i = 1; i <= cantFilasMarcas; i++)
            //{
            //    clx_marca.Items.Add(marc.get(i).getnombre());

            //}
            //for (int i = 1; i <= cantFilasGeneros; i++)
            //{
            //    clx_genero.Items.Add(gen.get(i).getnombre());

            //}
            //for (int i = 1; i <= cantFilasPegis; i++)
            //{
            //    clx_pegi.Items.Add(peg.get(i).getnombre());

            //}

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            int cont = 0;
            if (string.IsNullOrEmpty(tbx_nombre.Text))
            {
                tbx_nombre.BackColor = Color.Red;
                cont++;
            }

            if (string.IsNullOrEmpty(tbx_precio.Text))
            {
                tbx_precio.BackColor = Color.Red;
                cont++;
            }

            if (string.IsNullOrEmpty(tbx_desc.Text))
            {
                tbx_desc.BackColor = Color.Red;
                cont++;
            }
            ///------------------------------------------------------
            if (string.IsNullOrEmpty(tbx_Marca.Text))
            {
                tbx_Marca.BackColor = Color.Red;
                cont++;
            }

            if (string.IsNullOrEmpty(tbx_Pegi.Text))
            {
                tbx_Pegi.BackColor = Color.Red;
                cont++;
            }

            if (string.IsNullOrEmpty(tbx_Genero.Text))
            {
                tbx_Genero.BackColor = Color.Red;
                cont++;
            }

            if (string.IsNullOrEmpty(tbx_Cant.Text))
            {
                tbx_Cant.BackColor = Color.Red;
                cont++;
            }

            if (pictureBox1.Image == null)
            {
                error_portada.Visible = true;
            }

            ///---------------------------------------------------------
            if (cont > 0)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            else
            {
                n_producto reg = new n_producto();

                
                direccion = pictureBox1.ToString();

                reg.AgregarProducto(tbx_id.Text, tbx_nombre.Text, tbx_Marca.Text, tbx_Genero.Text, tbx_Pegi.Text,tbx_Cant.Text, tbx_desc.Text, tbx_desc.Text, tbx_precio.Text);


                ///MessageBox.Show(direccion);


                File.Copy(nombre, Path.Combine(@"" + directory + "\\Portadas\\", Path.GetFileName(tbx_nombre.Text + ".jpg")), true);

                MessageBox.Show("Producto Agregado correctamente");
                tbx_id.Text = "";tbx_nombre.Text = "";tbx_Marca.Text = "";tbx_Genero.Text = "";tbx_Pegi.Text = "";tbx_Cant.Text = "";tbx_desc.Text = "";tbx_desc.Text = "";tbx_precio.Text = "";
                pictureBox1.Image = null;


                int resu;
                resu = reg.obtenercantidadderegistros();
                resu = resu + 1;
                tbx_id.Text = resu.ToString();
            }



        }

        private void tbx_nombre_Click(object sender, EventArgs e)
        {
            tbx_nombre.BackColor = Color.White;
        }

        private void tbx_precio_Click(object sender, EventArgs e)
        {
            tbx_precio.BackColor = Color.White;
        }

        private void tbx_desc_Click(object sender, EventArgs e)
        {
            tbx_desc.BackColor = Color.White;
        }

        private void tbx_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);

        }

        private void tbx_precio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            error_portada.Visible = false;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *jpeg; *.gif; *.bmp;)|*.jpg; *jpeg; *.gif; *bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                nombre = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void tbx_Marca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx_Genero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx_Pegi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                
                DataGridViewRow row = this.dataMarca.Rows[e.RowIndex];
                tbx_Marca.Text = row.Cells["id_marca"].Value.ToString();
                tbx_Marca.BackColor = Color.White;

            }
        }

        private void dataGenero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGenero.Rows[e.RowIndex];
                tbx_Genero.Text = row.Cells["id_genero"].Value.ToString();
                tbx_Genero.BackColor = Color.White;

            }

        }

        private void dataPEGI_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataPEGI.Rows[e.RowIndex];
                tbx_Pegi.Text = row.Cells["id_pegi"].Value.ToString();
                tbx_Pegi.BackColor = Color.White;

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *jpeg; *.gif; *.bmp;)|*.jpg; *jpeg; *.gif; *bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                nombre = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);
            }            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            File.Copy(nombre, Path.Combine(@""+directory + "\\Portadas\\", Path.GetFileName(tbx_nombre.Text + ".jpg")), true);
        }

        private void tbx_precio_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbx_Marca_Click(object sender, EventArgs e)
        {
            tbx_Marca.BackColor = Color.White;
        }

        private void tbx_Genero_Click(object sender, EventArgs e)
        {
            tbx_Genero.BackColor = Color.White;
        }

        private void tbx_Pegi_Click(object sender, EventArgs e)
        {
            tbx_Pegi.BackColor = Color.White;
        }

        private void tbx_Cant_Click(object sender, EventArgs e)
        {
            tbx_Cant.BackColor = Color.White;
        }
    }



}
