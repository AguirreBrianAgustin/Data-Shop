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
using ENTIDAD;
using System.Data;
using System.Data.SqlClient;

namespace DataShop
{
    public partial class Estadisticas : Form
    {
        public Estadisticas()
        {
            InitializeComponent();
        }

        private void volverAlMenuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Estadisticas padre = new Estadisticas();
            MenuPrincipal hijo = new MenuPrincipal();

            this.Close();
            hijo.Show();
        }

        private void Estadisticas_Load(object sender, EventArgs e)
        {
            //  tbx_id_producto.ReadOnly = true;
            VENTA.Visible = true;
            
            n_venta reg = new n_venta();
            VENTA.DataSource = reg.getTabla();
            DETALLEVENTA.DataSource = reg.getTablaDETALLE();
            // textBox1.Text = monthCalendar1.SelectionStart.ToString();


            /// MODIFICACIONES JOSE
            if (VariablesGlobales.tipoUsuario == "False")
            {
                btn_auxiliar.Enabled = false;

            }
            VENTA.Visible = false;
            DETALLEVENTA.Visible = false;
            gbx_auxiliar.Visible = false;
            /// 


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }
        private SqlConnection ObtenerConexion()
        {
            String rutaBDDataShop =
//"Data Source=DESKTOP-ES3ODSC;Initial Catalog=DataShop;Integrated Security=True";
// "Data Source=DESKTOP-C247IGF\\QLEXPRESS;Initial Catalog=DataShop;Integrated Security=True";
"Data Source=localhost\\sqlexpress;Initial Catalog=DataShop;Integrated Security=True";
            SqlConnection cn = new SqlConnection(rutaBDDataShop);
            //       try
            //     {
            cn.Open();
            return cn;
            //   }
            // catch (Exception ex)
            //{
            //  return null;
            //}
        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            texrecaudaciondia.Text = "";
            textBox1.Text = monthCalendar1.SelectionStart.Day.ToString() + '/' +
              monthCalendar1.SelectionStart.Month.ToString() + '/' +
              monthCalendar1.SelectionStart.Year.ToString();
            int dia = monthCalendar1.SelectionStart.Day, mes = monthCalendar1.SelectionStart.Month,
                año = monthCalendar1.SelectionStart.Year;
            string fechaseleccionada = año.ToString() + "-" + mes.ToString() + "-" + dia.ToString();

            n_venta reg = new n_venta();
            dataGridView1.DataSource = reg.getTabla();
            string consulta = "select (id_venta)as ID_Venta, (id_cliente)as ID_Cliente,(dni_cliente)as DNI_Cliente,(telefono)as Telefono,(fecha)as Fecha,(total)as Total from VENTAS WHERE fecha = '" + fechaseleccionada + "'";  //+ "'"  + año + "'";
            dataGridView1.DataSource = reg.getTablafecha(consulta);


            string resurecaudacion = reg.obtenerRecaudacionDia("select sum(total)as total from ventas where fecha = '" + fechaseleccionada + "'");
            texrecaudaciondia.Text = resurecaudacion;

            /// NUEVAS ESTADISTICAS JOSE MES
            /// 
            tbx_Mes.Text = mes.ToString();

            string resurecaudacionMes = reg.obtenerRecaudacionMes("select sum (total)as Totalvendido_mes from VENTAS WHERE MONTH(fecha) = '" + tbx_Mes.Text+ "'");

            tbx_RecaudacionMes.Text = resurecaudacionMes;
            ///
            /// NUEVAS ESTADISTICAS JOSE MES

            ///-------------------------------------------------------------------------------------

            /// NUEVAS ESTADISTICAS JOSE AÑO
            /// 
            tbx_añoSeleccionado.Text = año.ToString();

            string resurecaudacionAnio = reg.obtenerRecaudacionAnio("select sum(total) as Totalvendido_anio from VENTAS WHERE YEAR(fecha) = '" + tbx_añoSeleccionado.Text + "'");

            tbx_totalAño.Text = resurecaudacionAnio;
            ///
            /// NUEVAS ESTADISTICAS JOSE AÑO



        }

        private void texrecaudaciondia_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
      
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_rangoMes_Click(object sender, EventArgs e)
        {
            n_venta reg = new n_venta();
            string resurecaudacionRangoMes = reg.obtenerRecaudacionRangoMes("select sum (total)as Totalvendido_rangoMes from VENTAS WHERE month(fecha) between '" + tbx_desdeMes.Text + "' and " + "'" + tbx_hastaMes.Text + "'");

            tbx_totalRangoMes.Text = resurecaudacionRangoMes;
        }

        private void btn_auxiliar_Click(object sender, EventArgs e)
        {
            VENTA.Visible = true;
            DETALLEVENTA.Visible = true;
            gbx_auxiliar.Visible = true;
        }
    }
}
