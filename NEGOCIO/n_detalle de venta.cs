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
    public class n_detalle_de_venta
    {

        public DataTable getTabla()
        {
            DatosDetalle_de_ventas dao = new DatosDetalle_de_ventas();
            return dao.getTablaDetalle();
        }

        public void eliminarDetalle(string id)
        {
            DatosDetalle_de_ventas dao = new DatosDetalle_de_ventas();
            dao.eliminarDetalle(id);
        }

    }
}
