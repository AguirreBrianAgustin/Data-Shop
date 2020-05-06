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

namespace DataShop
{
    public partial class Agregar_marca : Form
    {
        public Agregar_marca()
        {
            InitializeComponent();
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            this.Close();
            menu.Show();
        }

        private void tbx_id_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbx_id.BackColor = Color.White;
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbx_nombre.BackColor = Color.White;
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool codigo = false;
            bool nombre = false;
            string mensaje;
            if (string.IsNullOrEmpty(tbx_id.Text))
            {
                tbx_id.BackColor = Color.Red;
               
               
            }
            else
            {
                codigo = true;
            }
            if (string.IsNullOrEmpty(tbx_nombre.Text))
            {
                tbx_nombre.BackColor = Color.Red;
            }
            else
            {
                nombre = true;
            }
            if (codigo == false && nombre == false)
            {
                MessageBox.Show("Falta ingresar ID y Nombre");

            }
            if (codigo == false && nombre == true)
            {
                MessageBox.Show("Falta ingresar ID");
               
            }
            if (nombre == false && codigo == true)
            {
                MessageBox.Show("Falta ingresar Nombre");
            }

            if(tbx_id.Text != "" && tbx_nombre.Text != "")
            {
                n_marca reg = new n_marca();
                reg.AgregarMarca(tbx_id.Text, tbx_nombre.Text);
                MessageBox.Show("Marca Agregada correctamente");
                tbx_id.Text = "";
                tbx_nombre.Text = "";
             
                int resu = reg.obtenercatidadregistro();
                resu = resu + 1;
                tbx_id.Text = resu.ToString();
            }
        }

        private void tbx_id_Click(object sender, EventArgs e)
        {
            tbx_id.BackColor = Color.White;
        }

        private void tbx_nombre_Click(object sender, EventArgs e)
        {
            tbx_nombre.BackColor = Color.White;
        }

        private void Agregar_marca_Load(object sender, EventArgs e)
        {

            n_marca reg = new n_marca();
            int resu = reg.obtenercatidadregistro();
            resu = resu + 1;
            tbx_id.Text = resu.ToString();
        }
    }
}
