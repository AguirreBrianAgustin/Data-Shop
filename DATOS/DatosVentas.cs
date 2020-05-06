using ENTIDAD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DATOS
{
    public class DatosVentas
    {
        AccesoDatos ds = new AccesoDatos();
        public Ventas getVenta(int id)
        {
            Ventas ven = new Ventas();
            DataTable tabla = ds.ObtenerTabla("Ventas", "Select * from VENTAS where id_venta=" + id);
            ven.setid_venta(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            ven.setid_cliente(Convert.ToInt32(tabla.Rows[0][1].ToString()));
            ven.setdni_cliente(Convert.ToInt32(tabla.Rows[0][2].ToString()));
            ven.settelefono(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            ven.setfecha(tabla.Rows[0][4].ToString());
            ven.setid_Detalle_venta(Convert.ToInt32(tabla.Rows[0][5].ToString()));
            ven.settotal(Convert.ToInt32(tabla.Rows[0][6].ToString()));
            return ven;
        }

        public DataTable getTablaVentas()
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Ventas", "select (id_venta)as ID_Venta, (id_cliente)as ID_Cliente,(dni_cliente)as DNI_Cliente,(telefono)as Telefono,(fecha)as Fecha,(total)as Total from VENTAS");
            return tabla;
        }
        public DataTable getTablafecha(string consulta)
        {
            DataTable tabla = ds.ObtenerTablafecha("ventas", consulta);
            return tabla;
        }

        public string obtenerRecaudacionDia(string consulta) {
            string resu = ds.obtenerRecaudacionDia("ventas",consulta);
            return resu;
        }

        public string obtenerRecaudacionMes(string consulta)
        {
            string resu = ds.obtenerRecaudacionMes("ventas", consulta);
            return resu;
        }

        public string obtenerRecaudacionAnio(string consulta)
        {
            string resu = ds.obtenerRecaudacionAnio("ventas", consulta);
            return resu;
        }

        public string obtenerRecaudacionRangoMes(string consulta)
        {
            string resu = ds.obtenerRecaudacionRangoMes("ventas", consulta);
            return resu;
        }
        public DataTable getTablaDETALLE()
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTablaDETALLE("Ventas", "select (id_Detalle_Venta)as ID_Detalle_Venta,(id_venta)as ID_venta, (id_producto)AS ID_Producto,(cantidad)as Cantidad,(precio_unitario)as Precio_unitario from DETALLE_VENTAS");
            return tabla;
        }
       

        public void InsertarVenta(string id_venta, string id_cliente, string dni_cliente, string telefono, string fecha, string id_Detalle_Venta, string total)
        {
            AccesoDatos reg = new AccesoDatos();
            //DatosProveedores reg = new DatosProveedores();
            reg.InsertarVentas(id_venta, id_cliente, dni_cliente, telefono, fecha, id_Detalle_Venta, total);
        }

        public int obtenercantidadderegistrosVentas()
        {
            AccesoDatos reg = new AccesoDatos();
            int resu = reg.obtenercantidadderegistrosVenta();
            return resu;
        }


    }
}
