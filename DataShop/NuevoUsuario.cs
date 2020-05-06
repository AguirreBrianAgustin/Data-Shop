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

namespace DataShop
{
    public partial class NuevoUsuario : Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
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

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void BTN_GUARDAR_Click(object sender, EventArgs e)
        {
            int cont = 0;
            if (string.IsNullOrEmpty(textBox_USUARIO.Text))
            {
                textBox_USUARIO.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(textBox_contra.Text))
            {
                textBox_contra.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(textBox_confirmar.Text))
            {
                textBox_confirmar.BackColor = Color.Red;
                cont++;
            }
            bool xxx = false;
            if (radioButton1.Checked)
            {
                xxx = true;
            }
            if (radioButton2.Checked)
            {
                xxx = false;
            }
            login reg = new login();

            if (cont == 0)
            {
                if (cont == 0)
                {
                    if (textBox_contra.Text == textBox_confirmar.Text)
                    {
                        String consulta = "INSERT INTO USUARIOS (nombre_usuario,contraseña_usuario,permiso) " +
          "values(   '" + textBox_USUARIO.Text + "' , '" + textBox_contra.Text + "' , '" + xxx + "')";
                        reg.cargarlogin(consulta);

                        MessageBox.Show("AGREGADO CORECTAMENTE");
                        textBox_USUARIO.Text = string.Empty;
                        textBox_contra.Text = string.Empty;
                        textBox_confirmar.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("LAS CONTRASEÑAS NO COINCIDEN");

                    }
                }







                if (cont > 0)
                {
                    MessageBox.Show("Falta ingresar campos");
                }
            }
        }

        private void textBox_USUARIO_Click(object sender, EventArgs e)
        {
            textBox_USUARIO.BackColor = Color.White;
        }

        private void textBox_contra_Click(object sender, EventArgs e)
        {
            textBox_contra.BackColor = Color.White;
        }

        private void textBox_confirmar_Click(object sender, EventArgs e)
        {
            textBox_confirmar.BackColor = Color.White;
        }
    }
}
