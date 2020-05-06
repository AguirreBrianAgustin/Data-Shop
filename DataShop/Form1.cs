using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataShop
{  
    public partial class MenuPrincipal : Form
    { 
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void agregarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_productos listaproductos = new Lista_productos();


            listaproductos.Show();
            listaproductos.Location = this.Location;
            this.Hide();




        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clientes Clientes = new Clientes();


            Clientes.Show();
            Clientes.Location = this.Location;
            this.Close();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Proveedores Proveedores = new Proveedores();


            Proveedores.Show();
            Proveedores.Location = this.Location;
            this.Hide();
        }

        private void productoToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Agregar_Producto Agregar_producto = new Agregar_Producto();


            Agregar_producto.Show();
            Agregar_producto.Location = this.Location;
            this.Hide();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            LOGIN reg = new LOGIN();

           
            ///MessageBox.Show(resu + "dsa");
            if (VariablesGlobales.tipoUsuario == "False")
            {
                button2.Visible = false;
            }

            if (VariablesGlobales.tipoUsuario == "True")
            {
                button2.Visible = true;
            }
            if (VariablesGlobales.tipoUsuario == "False")
            {
                button2.Visible = false;
            }


        }
           
            

        

        private void generosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Genero gen = new Genero();


            gen.Show();
            gen.Location = this.Location;
            this.Close();
        }

        private void generosToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Genero gen = new Genero();


            gen.Show();
            gen.Location = this.Location;
            this.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Cliente cliente = new Agregar_Cliente();

            cliente.Show();
            cliente.Location = this.Location;
            this.Hide();
        }

        private void proveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Agregar_Proveedor proveedor = new Agregar_Proveedor();
            proveedor.Show();
            proveedor.Location = this.Location;
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
            label1.Text = DateTime.Now.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Restart();
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            NuevoUsuario NEW = new NuevoUsuario();


            NEW.Show();
            NEW.Location = this.Location;
            this.Hide();
        }

        private void btnTransaccion_Click(object sender, EventArgs e)
        {
            Transaccion hijo = new Transaccion();
            MenuPrincipal padre = new MenuPrincipal();

            this.Close();
            

            hijo.Show();
            hijo.Location = this.Location;

        }

        private void creditosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplicación creada y diseñada por Brian Aguirre, para la materia Programación 3.");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void marcasToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Agregar_marca marca = new Agregar_marca();

            this.Close();

            marca.Show();
        }

        private void generosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Genero gen = new Genero();


            gen.Show();
            gen.Location = this.Location;
            this.Close();
        }

        private void marcasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Listar_Marcas marca = new Listar_Marcas();


            this.Close();
            marca.Show();


        }

        private void gnerosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Listar_Generos generos = new Listar_Generos();
            this.Close();
            generos.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ventasYDetallesDeVentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reporte1 reporte1 = new Reporte1();


            reporte1.Show();
            reporte1.Location = this.Location;
            this.Hide();
        }

        private void btnESTADISTICA_Click(object sender, EventArgs e)
        {
           Estadisticas hijo = new Estadisticas();
            MenuPrincipal padre = new MenuPrincipal();

            this.Close();


            hijo.Show();
            hijo.Location = this.Location;
        }
    }
}
