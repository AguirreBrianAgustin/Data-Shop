using NEGOCIO;
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


namespace DataShop
{ 
    public partial class Agregar_Cliente : Form
    {  
        public Agregar_Cliente()
        {
            InitializeComponent();
        }

        private void Agregar_Cliente_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            n_cliente reg = new n_cliente();
            int resu = reg.obtenerregistrocliente();
            resu = resu + 1;
            tbx_cliente.Text = resu.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            menu.Location = this.Location;
            this.Hide();
            

        }

        private void volverAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();


            hijo.Show();
            hijo.Location = this.Location;
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString();
        }

        private void tbx_cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbx_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_cargar_Click(object sender, EventArgs e)
        {
            int cont = 0;
            if (string.IsNullOrEmpty(tbx_cliente.Text))
            {
                tbx_cliente.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(tbx_dni.Text))
            {
                tbx_dni.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(tbx_nombre.Text))
            {
                tbx_nombre.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(tbx_direccion.Text))
            {
                tbx_direccion.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(tbx_telefono.Text))
            {
                tbx_telefono.BackColor = Color.Red;
                cont++;
            }

            if (cont > 0)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            
            else
            {
                n_cliente reg = new n_cliente();
                reg.getagregar_cliente(tbx_cliente.Text, tbx_dni.Text, tbx_nombre.Text, tbx_direccion.Text, tbx_telefono.Text);
                MessageBox.Show("Cliente Agregado correctamente");
                tbx_cliente.Text = string.Empty;
                tbx_direccion.Text = string.Empty;
                tbx_dni.Text = string.Empty;
                tbx_nombre.Text = string.Empty;
                tbx_telefono.Text = string.Empty;
              
                int resu = reg.obtenerregistrocliente();
                resu = resu + 1;
                tbx_cliente.Text = resu.ToString();
            }
            
            


        }

        private void tbx_cliente_Click(object sender, EventArgs e)
        {
            tbx_cliente.BackColor = Color.White;
        }

        private void tbx_dni_Click(object sender, EventArgs e)
        {
            tbx_dni.BackColor = Color.White;
        }

        private void tbx_nombre_Click(object sender, EventArgs e)
        {
            tbx_nombre.BackColor = Color.White;
        }

        private void tbx_telefono_Click(object sender, EventArgs e)
        {
            tbx_telefono.BackColor = Color.White;
        }

        private void tbx_direccion_Click(object sender, EventArgs e)
        {
            tbx_direccion.BackColor = Color.White;
        }

        private void tbx_cliente_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
