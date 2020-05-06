using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTIDAD;
using NEGOCIO;

namespace DataShop
{
    public partial class Genero : Form
    {
        public Genero()
        {
            InitializeComponent();
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
            Close();
        }

        private void Genero_Load(object sender, EventArgs e)
        {
            n_genero reg = new n_genero();
            int resu = reg.obtenercantidadregistrogenero();
            resu = resu + 1;
            textBox_genero.Text = resu.ToString();


        }

        private void textBox_genero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx_desc_KeyPress(object sender, KeyPressEventArgs e)
        {
           e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);

        }

        public void BTNCARGAR_Click(object sender, EventArgs e)
        {
            bool codigo = false;
            bool descripcion = false;
            if (string.IsNullOrEmpty(textBox_genero.Text))
            {
                textBox_genero.BackColor = Color.Red;


            }
            else
            {
                codigo = true;
            }
            if (string.IsNullOrEmpty(tbx_desc.Text))
            {
                tbx_desc.BackColor = Color.Red;
            }
            else
            {
                descripcion = true;
            }
            if (codigo == false && descripcion == false)
            {
                MessageBox.Show("Falta ingresar ID y Nombre");

            }
            if (codigo == false && descripcion == true)
            {
                MessageBox.Show("Falta ingresar ID");

            }
            if (descripcion == false && codigo == true)
            {
                MessageBox.Show("Falta ingresar Nombre");
            }
            if (descripcion == true && codigo == true)
            {
                n_genero reg = new n_genero();   
               
                reg.AgregarGenero(textBox_genero.Text, tbx_desc.Text);
                MessageBox.Show("AGREGADO CORRECTAMENTE");
                textBox_genero.Text = ""; tbx_desc.Text = "";



                int resu = reg.obtenercantidadregistrogenero();
                resu = resu + 1;
                textBox_genero.Text = resu.ToString();
            }
        }

        private void textBox_genero_Click(object sender, EventArgs e)
        {
            textBox_genero.BackColor = Color.White;
        }

        private void tbx_desc_Click(object sender, EventArgs e)
        {
            tbx_desc.BackColor = Color.White;
        }
    }
}
