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
    public partial class Agregar_Proveedor : Form
    {
        public Agregar_Proveedor()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            menu.Location = this.Location;
            this.Hide();
        }

        private void Agregar_Proveedor_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            n_proveedor reg = new n_proveedor();
            dgv_proveedor.DataSource = reg.getTabla();
            n_producto pro = new n_producto();
            dgv_productos.DataSource = pro.getTabla();
            int resu;
            resu = reg.obtenerregistroproveedor();
            resu = resu + 1;
            textBox_id.Text = resu.ToString();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void volverAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal hijo = new MenuPrincipal();


            hijo.Show();
            hijo.Location = this.Location;
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int cont = 0;
            if (string.IsNullOrEmpty(textBox_nombre.Text))
            {
                textBox_nombre.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(textBox_direccion.Text))
            {
                textBox_direccion.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(textBox_id.Text))
            {
                textBox_id.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(textBox_localidad.Text))
            {
                textBox_localidad.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(textBox_telefono.Text))
            {
                textBox_telefono.BackColor = Color.Red;
                cont++;
            }

            if (cont > 0)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            /// MODIFICACION JOSE 8/02/2019
            //for (int i = 0; i < dgv_proveedor.Rows.Count; i++)
            //{
            //    //items.Cells[5].Value.Equals(item.Cells[5].Value)
            //    //textBox_id.Text.Equals(dgv_proveedor.Rows[i].Cells[0].Value.ToString())
            //    if (textBox_id.Text.Equals(dgv_proveedor.Rows[i].Cells[0].Value.ToString()))
            //    {
            //        MessageBox.Show("El ID del proveedor ya existe.");
            //        return;
            //    }
            //}
            /// MODIFICACION JOSE 8/02/2019

            if (textBox_id.Text != "" & textBox_nombre.Text != "" /*& textBox_apellido.Text != ""*/
                & textBox_direccion.Text != "" & textBox_telefono.Text != ""
                & textBox_localidad.Text != "")
            {
                n_proveedor reg = new n_proveedor();

                reg.AgregarProveedor(textBox_id.Text, tbx_idProducto.Text, textBox_nombre.Text, textBox_direccion.Text, textBox_telefono.Text, textBox_localidad.Text);
                MessageBox.Show("Proveedor Agregado correctamente");
                tbx_idProducto.Text = string.Empty;
                textBox_apellido.Text = string.Empty;
                textBox_direccion.Text = string.Empty;
                textBox_id.Text = string.Empty;
                textBox_localidad.Text = string.Empty;
                textBox_nombre.Text = string.Empty;
                textBox_telefono.Text = string.Empty;
             
                int resu;
                resu = reg.obtenerregistroproveedor();
                resu = resu + 1;
                textBox_id.Text = resu.ToString();
            }
        }

        private void textBox_id_Click(object sender, EventArgs e)
        {
            textBox_id.BackColor = Color.White;
        }

        private void textBox_nombre_Click(object sender, EventArgs e)
        {
            textBox_nombre.BackColor = Color.White;
        }

        private void textBox_direccion_Click(object sender, EventArgs e)
        {
            textBox_direccion.BackColor = Color.White;
        }

        private void textBox_telefono_Click(object sender, EventArgs e)
        {
            textBox_telefono.BackColor = Color.White;
        }

        private void textBox_localidad_Click(object sender, EventArgs e)
        {
            textBox_localidad.BackColor = Color.White;
        }

        private void dgv_productos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dgv_productos.Rows[e.RowIndex];
                tbx_idProducto.Text = row.Cells["id_producto"].Value.ToString();
                tbx_idProducto.BackColor = Color.White;

            }
        }

        private void dgv_proveedor_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

        }

        private void textBox_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Space);
        }
    }
}
