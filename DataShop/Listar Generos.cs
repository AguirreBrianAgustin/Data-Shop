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
    public partial class Listar_Generos : Form
    {
        public Listar_Generos()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            Filtrar_Generos generos = new Filtrar_Generos();
            this.Close();
            generos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void volverAlMenúPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();

            this.Close();
            menu.Show();
        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filtrar_Generos generos = new Filtrar_Generos();
            this.Close();
            generos.Show();
        }

        private void Listar_Generos_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            
            n_genero n_cat = new n_genero();
            dataGridView1.DataSource = n_cat.getTabla();

           /* string rutaNeptunoSQL = "Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";

            //SqlConnection cnNeptuno = new SqlConnection();
            //cnNeptuno.ConnectionString = rutaNeptunoSQL;
            //se puede resumir en una sola linea:
            SqlConnection cnNeptuno = new SqlConnection(rutaNeptunoSQL);

            //string consultaSQL = "select * from Categorías where IdCategoría = " + comboBox1.Text;
            string consultaSQL = "select * from GENEROS";
            SqlDataAdapter adaptador = new SqlDataAdapter(consultaSQL, cnNeptuno);
            DataSet dsProductos = new DataSet();

            cnNeptuno.Open();
            // aca vendra el codigo para llenar la grilla
            adaptador.Fill(dsProductos, "Categorías");
            dataGridView1.DataSource = dsProductos.Tables["Categorías"];

            cnNeptuno.Close();*/
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }
    }
}
