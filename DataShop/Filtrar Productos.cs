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
    public partial class Filtrar_Productos : Form
    {
        string globalActualizar;
        string global;
        /// <variablesImagenes>
        string nombreViejo;
        /// </summary>


        //  DataSet ds = new DataSet();
        public Filtrar_Productos()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataProductos.Rows[e.RowIndex];
                global = row.Cells["id_producto"].Value.ToString();

                
            }
        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lista_productos hijo = new Lista_productos();


            hijo.Show();
            hijo.Location = this.Location;
            this.Close();
        }

        private void Filtrar_Productos_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            n_producto producto = new n_producto();
            dataProductos.DataSource = producto.getTabla();

            //////////////////////////////
            ///



            /////

            n_genero gen = new n_genero();
            dataGenero.DataSource = gen.getTabla();
            int cantFilasGeneros = dataGenero.Rows.Count - 1;

            ///dataGenero.Columns["id_genero"].Visible = false;


            n_marca marc = new n_marca();
            dataMarca.DataSource = marc.getTabla();
            int cantFilasMarcas = dataMarca.Rows.Count - 1;


            n_pegi peg = new n_pegi();
            dataPegi.DataSource = peg.getTabla();
            int cantFilasPegis = dataPegi.Rows.Count - 1;





            //for (int i = 1; i <= cantFilasMarcas; i++)
            //{

            //    cbxMarca.Items.Add(marc.get(i).getid_marca());

            //}
            //for (int i = 1; i <= cantFilasGeneros; i++)
            //{
            //    cbxGenero.Items.Add(gen.get(i).getid_genero());

            //}

            //for (int i = 1; i <= cantFilasGeneros; i++)
            //{
            //    cbxPEGI.Items.Add(peg.get(i).getid_pegi());

            //}

            if (VariablesGlobales.tipoUsuario == "False")
            {
                btnModificar.Enabled = false;

            }
            if (VariablesGlobales.tipoUsuario == "False")
            {
                btnEliminar.Enabled = false;

            }
            if(VariablesGlobales.tipoUsuario == "False")
            {
                aviso.Visible = true;
            }
            if(VariablesGlobales.tipoUsuario == "True")
            {
                aviso.Visible = false;
            }


            //////////////////////////////
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            tbxAuxiliar.Text = String.Empty;
            tbxId.Text = String.Empty;
            tbxNombre.Text = String.Empty;
            //cbxMarca.Text = String.Empty;
            //cbxGenero.Text = String.Empty;
            //cbxPEGI.Text = String.Empty;
            tbx_genero.Text = String.Empty;
            tbx_Marca.Text = String.Empty;
            tbx_Pegi.Text = string.Empty;
            n_producto reg = new n_producto();
            dataProductos.DataSource = reg.getTabla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ///MODIFICACIONES JOSE AL 2 DE FEBRERO
            n_detalle_de_venta reg2 = new n_detalle_de_venta();
            reg2.eliminarDetalle(global);

            ///MODIFICACIONES JOSE AL 2 DE FEBRERO
            n_producto reg = new n_producto();
            reg.eliminarProducto(global);
            MessageBox.Show("Eliminado correctamente");
            dataProductos.DataSource = reg.getTabla();


        }

        private void dataProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataProductos.Rows[e.RowIndex];
                global = row.Cells["ID_Producto"].Value.ToString();
                globalActualizar = /*global = */row.Cells["id_producto"].Value.ToString()
                  + "," + row.Cells["Nombre"].Value.ToString()
                  + "," + row.Cells["ID_Marca"].Value.ToString()
                  + "," + row.Cells["ID_Genero"].Value.ToString()
                  + "," + row.Cells["ID_Pegi"].Value.ToString()
                  + "," + row.Cells["Stock"].Value.ToString()
                  + "," + row.Cells["Descripcion"].Value.ToString()
                  + "," + row.Cells["Precio_X_Unidad"].Value.ToString();
                ///+ "," + row.Cells["precio_de_unidad"].Value.ToString();
                ///
                nombreViejo = row.Cells["Nombre"].Value.ToString();

            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxId.Text) && string.IsNullOrEmpty(tbxNombre.Text)
                && string.IsNullOrEmpty(cbxGenero.Text) && string.IsNullOrEmpty(cbxMarca.Text)
                && string.IsNullOrEmpty(cbxPEGI.Text)
                && string.IsNullOrEmpty(tbxNombre.Text))
            {
                n_producto reg = new n_producto();
                dataProductos.DataSource = reg.getTabla();
            }

            if (!string.IsNullOrEmpty(tbxId.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_producto=" + tbxId.Text;
            }

            if (!string.IsNullOrEmpty(tbx_Marca.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_marca=" + tbx_Marca.Text;

            }

            if (!string.IsNullOrEmpty(tbx_genero.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_genero=" + tbx_genero.Text;
            }

            if (!string.IsNullOrEmpty(tbx_Pegi.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_pegi=" + tbx_Pegi.Text;
            }

            if (!string.IsNullOrEmpty(tbxNombre.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "nombre=" + "'" + tbxNombre.Text + "'";
            }





            //resumen.Text = tbxId.Text + tbxNombre.Text + cbxGenero.Text + cbxMarca.Text + cbxPEGI.Text;

            //((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_marca=" + cbxMarca.Text
            //                                                             + " AND " + " id_genero=" + cbxGenero.Text;

            ///****************************************************************************************
            //if (!string.IsNullOrEmpty(tbxId.Text) && !string.IsNullOrEmpty(tbxNombre.Text))
            //{
            //    ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_producto=" + tbxId.Text + "AND nombre =" + "'" + tbxNombre.Text + "'";
            //}

            if (!string.IsNullOrEmpty(tbx_genero.Text) && !string.IsNullOrEmpty(tbx_Marca.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_genero=" + tbx_genero.Text + "AND id_marca =" + "'" + tbx_Marca.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbx_genero.Text) && !string.IsNullOrEmpty(tbx_Pegi.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_genero=" + tbx_genero.Text + "AND id_pegi =" + "'" + tbx_Pegi.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbx_Marca.Text) && !string.IsNullOrEmpty(tbx_Pegi.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_marca=" + tbx_Marca.Text + "AND id_pegi =" + "'" + tbx_Pegi.Text + "'";
            }

            if (!string.IsNullOrEmpty(tbx_genero.Text) && !string.IsNullOrEmpty(tbx_Marca.Text) && !string.IsNullOrEmpty(tbx_Pegi.Text))
            {
                ((DataTable)dataProductos.DataSource).DefaultView.RowFilter = "id_genero=" + tbx_genero.Text + "AND id_marca =" + "'" + tbx_Marca.Text + "'" + "AND id_pegi =" + "'" + tbx_Pegi.Text + "'";
            }

            //dv.RowFilter = "id > 0 AND index = 4";



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label8.Text = DateTime.Now.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            n_producto producto = new n_producto();
            producto.actualizarProducto2(globalActualizar);

            ///System.IO.File.Move(nombreViejo + ".jpg", "newfilename");


            MessageBox.Show("Modificado correctamente");
            n_producto producto2 = new n_producto();
            dataProductos.DataSource = producto2.getTabla();


        }

        private void tbxId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbxGenero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnEditor_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGenero_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataGenero.Rows[e.RowIndex];
                tbx_genero.Text = row.Cells["id_genero"].Value.ToString();


            }
        }

        private void dataMarca_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataMarca.Rows[e.RowIndex];
                tbx_Marca.Text = row.Cells["id_marca"].Value.ToString();


            }
        }

        private void dataPegi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                DataGridViewRow row = this.dataPegi.Rows[e.RowIndex];
                tbx_Pegi.Text = row.Cells["id_pegi"].Value.ToString();


            }
        }
    }
}
