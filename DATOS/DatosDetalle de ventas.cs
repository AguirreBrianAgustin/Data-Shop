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
    public class DatosDetalle_de_ventas
    {

        AccesoDatos ds = new AccesoDatos();
        public Detalle_de_ventas getDetalle_de_venta(int id)
        {
            Detalle_de_ventas DetalleVenta = new Detalle_de_ventas();
            DataTable tabla = ds.ObtenerTabla("Detalle_de_ventas", "Select * from DETALLE_VENTAS where id_venta=" + id);
            DetalleVenta.setid_venta(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            DetalleVenta.setid_producto(Convert.ToInt32(tabla.Rows[0][1].ToString()));
            DetalleVenta.setid_cliente(Convert.ToInt32(tabla.Rows[0][2].ToString()));
            DetalleVenta.setcantidad(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            DetalleVenta.setprecio_unitario(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            return DetalleVenta;
        }

        public DataTable getTablaDetalle()
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Detalle_de_ventas", "select id_venta,id_producto,id_cliente,cantidad,precio_unitario from DETALLE_VENTAS");
            return tabla;
        }
        public void eliminarDetalle(string id)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.eliminarDetalle(id);
        }

    }
}
