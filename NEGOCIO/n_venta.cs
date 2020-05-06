using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTIDAD;
using DATOS;
using System.Data;

namespace NEGOCIO
{
    public class n_venta
    {
        public DataTable getTabla()
        {
            DatosVentas dao = new DatosVentas();
            return dao.getTablaVentas();
        }
      
             public DataTable getTablafecha(string consulta)
        {
            DatosVentas dao = new DatosVentas();
            return dao.getTablafecha(consulta);
        }
        public string obtenerRecaudacionDia(string consulta) {
            DatosVentas dao = new DatosVentas();
            string resu = dao.obtenerRecaudacionDia( consulta);
            return resu;
        }

        public string obtenerRecaudacionMes(string consulta)
        {
            DatosVentas dao = new DatosVentas();
            string resu = dao.obtenerRecaudacionMes(consulta);
            return resu;
        }

        public string obtenerRecaudacionAnio(string consulta)
        {
            DatosVentas dao = new DatosVentas();
            string resu = dao.obtenerRecaudacionAnio(consulta);
            return resu;
        }

        public string obtenerRecaudacionRangoMes(string consulta)
        {
            DatosVentas dao = new DatosVentas();
            string resu = dao.obtenerRecaudacionRangoMes(consulta);
            return resu;
        }

        public DataTable getTablaDETALLE()
        {
            DatosVentas dao = new DatosVentas();
            return dao.getTablaDETALLE();
        }
        public void InsertarVenta(string id_venta, string id_cliente, string dni_cliente, string telefono, string fecha, string id_Detalle_Venta, string total)
        {

            DatosVentas reg = new DatosVentas();
            reg.InsertarVenta(id_venta, id_cliente, dni_cliente, telefono, fecha, id_Detalle_Venta, total);
        }

        public int obtenercantidadderegistrosVenta()
        {
            DatosVentas reg = new DatosVentas();
            int resu = reg.obtenercantidadderegistrosVentas();
            return resu;

        }

    }
}
