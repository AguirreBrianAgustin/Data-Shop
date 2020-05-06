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
    public partial class Transaccion : Form
    {
        public Transaccion()
        {
            InitializeComponent();
        }
        float precio;
        float total;
        String global = "";
        private void Transaccion_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            n_cliente cliente = new n_cliente();
            data_Cliente.DataSource = cliente.getTabla();

            n_producto producto = new n_producto();
            dataProductos.DataSource = producto.getTabla();
            

            

        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Transaccion padre = new Transaccion();
            MenuPrincipal hijo = new MenuPrincipal();

            this.Close();
            hijo.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {

            foreach (var item in listBox1.Items) {
                ListaProductos.Text += item.ToString() + "\n";
            }

               n_venta reg = new n_venta();


               int cont = 0;
               if (string.IsNullOrEmpty(tbx_cliente_id.Text))
               {
                   tbx_cliente_id.BackColor = Color.Red;
                   cont++;
               }
               if (cont > 0)
               {
                   MessageBox.Show("Falta ingresar campos");
               }


               if (cont == 0)
               {

                   if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
                       printDocument1.Print();

                   //////////////////////////////// 
                n_producto prodd = new n_producto();
                prodd.cargarVenta(tbx_cliente_id.Text, tbx_cliente_telefono.Text, tbx_preciototal.Text);
                


                foreach (String item in listBox1.Items)

                   {
                       string aux = item.ToString(); /////



                       String[] separado;
                       separado = aux.Split(':');
                       string[] resu = separado[1].Split(',');



                       //string resup2 = prod.obtenerproductoid(resu[0]);

                       int id = Convert.ToInt16(resu[0]), sto = Convert.ToInt16(resu[2]);
                       n_producto prod = new n_producto();
                       prod.actualizarStock(id, sto);
                   int resuu = prodd.cargarDetalleVentas(id, sto);
                    prodd.cargarDETALLECOMPLETO(id, sto,resuu);
                    //MessageBox.Show(id.ToString()+"  " + sto.ToString());
                    //MessageBox.Show(resuu.ToString());


                }

                   tbx_id_producto.Text = "";
                   textBox1.Text = "";
                   tbx_nombre_producto.Text = "";
                   tbx_cantidad_producto.Text = "";
                   tbx_preciototal.Text = "";
                   tbx_cliente_id.Text = "";
                   tbx_cliente_nombre.Text = "";
                   tbx_cliente_direccion.Text = "";
                   tbx_cliente_telefono.Text = "";
                   busXnombre.Text = "";
                dataGridView1.Visible = false;
                   listBox1.Items.Clear();
               }

            
        }

        private void tbx_cliente_id_Click(object sender, EventArgs e)
        {
            tbx_cliente_id.BackColor = Color.White;
        }

        private void btn_aceptar_cleinte_Click(object sender, EventArgs e)
        {
            /// AGREGADO JOSE 04/02/2019
            int cont = 0;
            if (string.IsNullOrEmpty(tbx_cliente_id.Text))
            {
                tbx_cliente_id.BackColor = Color.Red;
                cont++;
            }


            if (cont > 0)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            else
            {
                n_cliente cliente = new n_cliente();
                string resu = cliente.obtenerclienteid(tbx_cliente_id.Text);
                //  string resu=cliente.retorno();

                if (string.IsNullOrEmpty(resu)) { MessageBox.Show("Error DNI no existe"); }
                else
                {
                    String[] separado;
                    separado = resu.Split(',');
                    tbx_cliente_nombre.Text = separado[0];
                    tbx_cliente_direccion.Text = separado[1];
                    tbx_cliente_telefono.Text = separado[2];

                }

            }


            /// AGREGADO JOSE 04/02/2019

            
          
            




        }

        private void btn_agregar_producto_Click(object sender, EventArgs e)
        {
            /// AGREGADO JOSE 4/2/2019
            /// 
            int cont = 0;
            if (string.IsNullOrEmpty(tbx_cantidad_producto.Text))
            {
                tbx_cantidad_producto.BackColor = Color.Red;
                cont++;
            }
            if (string.IsNullOrEmpty(tbx_nombre_producto.Text))
            {
                tbx_nombre_producto.BackColor = Color.Red;
                cont++;
            }


            if (cont > 0)
            {
                MessageBox.Show("Falta ingresar campos");
            }
            else
            {
                int ns = Convert.ToInt16(textBox1.Text);
                int nc = Convert.ToInt16(tbx_cantidad_producto.Text);
                if (nc <= ns)
                {
                    string aux1;
                    aux1 = string.Concat(tbx_nombre_producto.Text, ", ", tbx_cantidad_producto.Text);
                    if (string.IsNullOrEmpty(tbx_nombre_producto.Text) || string.IsNullOrEmpty(tbx_cantidad_producto.Text))
                    {
                        MessageBox.Show("Falta ingresar producto o cantidad");
                    }
                    else
                    {
                        if (listBox1.Items.Contains(aux1))
                        {
                            MessageBox.Show("El producto deseado ya se ha seleccionado");
                        }
                        else
                        {

                            aux1 = string.Concat("ID_Producto:" + tbx_id_producto.Text + "," + tbx_nombre_producto.Text, ", ", tbx_cantidad_producto.Text);

                            listBox1.Items.Add(aux1);
                        }
                        total += precio * Convert.ToSingle(tbx_cantidad_producto.Text);
                        tbx_preciototal.Text = total.ToString();
                        tbx_cantidad_producto.Text = "";
                        tbx_id_producto.Text = "";
                        textBox1.Text = "";
                        tbx_nombre_producto.Text = "";
                    }

                }
                else { MessageBox.Show("Error no hay Stock"); }
            }

            /// AGREGADO JOSE 4/2/2019
            
            

            //n_producto producto = new n_producto();

            //string resu = producto.obtenerproductoid(tbx_id_producto.Text);

            //listBox1.Items.Add(producto.obtenerproductoid(tbx_id_producto.Text));

            //String[] separado;

            //separado = resu.Split(',');
            //listBox1.Items.Add(separado[0].ToString());



            //tbx_cliente_nombre.Text = separado[0];
            //tbx_cliente_direccion.Text = separado[1];
            //tbx_cliente_telefono.Text = separado[2];
        }

        private void tbx_id_producto_KeyPress(object sender, KeyPressEventArgs e)
        {
            dataGridView1.Visible = false;
            busXnombre.ReadOnly = true;
            if (tbx_id_producto.Text == "") { busXnombre.ReadOnly = false; }
           
        }

        private void tbx_id_producto_KeyDown(object sender, KeyEventArgs e)
        {
            dataGridView1.Visible = false;
            if (e.KeyCode == Keys.Enter)
            {
                n_producto prod = new n_producto();
                string resup2 = prod.obtenerproductoid(tbx_id_producto.Text);
                String[] separado;
                separado = resup2.Split(',');
                precio = Convert.ToUInt16(separado[1]);  
                tbx_nombre_producto.Text = separado[0];
                int resu= prod.obtenerStock(Convert.ToInt16(tbx_id_producto.Text));
                textBox1.Text = resu.ToString();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

       

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbx_id_producto_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string theDate = dateTimePicker1.Value.ToShortDateString();
            e.Graphics.DrawString("-----------------------------------------", new Font("Times New Roman", 40, FontStyle.Bold), Brushes.Black, new PointF(10, 450));
            e.Graphics.DrawString("-----------------------------------------", new Font("Times New Roman", 40, FontStyle.Bold), Brushes.Black, new PointF(10, 850));
            e.Graphics.DrawString("***************************", new Font("Times New Roman", 40, FontStyle.Bold), Brushes.Black, new PointF(10, 20));
            e.Graphics.DrawString("***************************", new Font("Times New Roman", 40, FontStyle.Bold), Brushes.Black, new PointF(10, 1100));

            e.Graphics.DrawString("FACTURA", new Font("Times New Roman", 40, FontStyle.Bold), Brushes.Black, new PointF(50, 50));
            e.Graphics.DrawString("DATA SHOP", new Font("Times New Roman", 40, FontStyle.Bold), Brushes.Black, new PointF(400, 50));
            e.Graphics.DrawString("Fecha", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(500, 200));
            e.Graphics.DrawString(theDate, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(600, 200));
            e.Graphics.DrawString("Nombre", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 200));
            e.Graphics.DrawString(tbx_cliente_nombre.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(200, 200));
            e.Graphics.DrawString("ID: ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 240));
            e.Graphics.DrawString(tbx_cliente_id.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(200, 240));
            e.Graphics.DrawString("Productos comprados: ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(100, 500));
            e.Graphics.DrawString(ListaProductos.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(500, 500));
            e.Graphics.DrawString("Total a pagar: ", new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(400, 900));
            e.Graphics.DrawString(tbx_preciototal.Text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, new PointF(700, 900));


        }


        private void listBox1_DoubleClick(object sender, EventArgs e)
        {

            /* if (this.listBox1.SelectedIndex >= 0) {
                 this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);


                total -= precio;
             }*/
            string aux;
            aux = string.Concat(listBox1.SelectedItem);
            String[] separado;
            separado = aux.Split(':');
            string[] resu= separado[1].Split(',');
            

            n_producto prod = new n_producto();
            string resup2 = prod.obtenerproductoid(resu[0]);
            String[] separad;
            separad = resup2.Split(',');
            precio = Convert.ToUInt16(separad[1]);
          
            total = total - (precio * Convert.ToSingle(resu[2]));
          
            listBox1.Items.Remove(listBox1.SelectedItem);
            tbx_preciototal.Text = total.ToString();

        }

        private void busXnombre_KeyDown(object sender, KeyEventArgs e)
        {
            //  tbx_id_producto.ReadOnly = true;
            dataGridView1.Visible = true;
            n_producto producto = new n_producto();
            dataGridView1.DataSource = producto.getTablalike(busXnombre.Text);
        }

        private void busXnombre_TextChanged(object sender, EventArgs e)
        {
            //tbx_id_producto.ReadOnly = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                global = row.Cells["id_producto"].Value.ToString();
                tbx_id_producto.Text = global;
                    //globalModificar /*= global*/ = row.Cells["id_genero"].Value.ToString() + "," + row.Cells["descripcion"].Value.ToString();


                    n_producto prod = new n_producto();
                    string resup2 = prod.obtenerproductoid(global);
                    String[] separado;
                    separado = resup2.Split(',');
                    precio = Convert.ToUInt16(separado[1]);
                    tbx_nombre_producto.Text = separado[0];
                    int resu = prod.obtenerStock(Convert.ToInt16(global));
                    textBox1.Text = resu.ToString();
                
            }
        }

        private void busXnombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbx_id_producto.ReadOnly = true;
            if (busXnombre.Text == "") { tbx_id_producto.ReadOnly = false; }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbx_id_producto_Click(object sender, EventArgs e)
        {
            tbx_nombre_producto.BackColor = Color.White;
        }

        private void busXnombre_Click(object sender, EventArgs e)
        {
            tbx_nombre_producto.BackColor = Color.White;
        }

        private void tbx_cantidad_producto_Click(object sender, EventArgs e)
        {
            tbx_cantidad_producto.BackColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Transaccion padre = new Transaccion();
            MenuPrincipal hijo = new MenuPrincipal();

            this.Close();
            hijo.Show();

        }
    }
}
