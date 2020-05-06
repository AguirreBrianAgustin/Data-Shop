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
    public class DatosPegis
    {
        AccesoDatos ds = new AccesoDatos();
        public Pegis getPegi(int id)
        {
            Pegis pg = new Pegis();
            DataTable tabla = ds.ObtenerTabla("Pegis", "Select * from PEGI where id_pegi=" + id);
            pg.setid_pegi(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            pg.setNombre(tabla.Rows[0][1].ToString());
            return pg;
        }

        public DataTable getTablaPegis()
        {
            AccesoDatos RE = new AccesoDatos();
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = RE.ObtenerTabla("Pegis", "SELECT (id_pegi)as ID_Pegi,(descripcion)as Descripcion from pegi");
            return tabla;
        }

    }
}
