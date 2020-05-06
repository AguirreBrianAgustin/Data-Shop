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
    public class DatosGeneros
    {
        AccesoDatos ds = new AccesoDatos();
        public Generos getMarca(int id)
        {
            Generos cat = new Generos();
            DataTable tabla = ds.ObtenerTabla("Generos", "Select * from GENEROS where id_genero=" + id);
            cat.setid_genero(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            cat.setNombre(tabla.Rows[0][1].ToString());
            return cat;
        }

        public DataTable getTablaMarcas()
        {
            AccesoDatos RE = new AccesoDatos();
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = RE.ObtenerTabla("Generos", "SELECT (id_genero)as ID_Genero,(descripcion)as Descripcion from GENEROS");
            return tabla;
        }
        public void AgregarGenero(string id, string nombre)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.agregarGeneros(id, nombre);
        }
        public int obtenercantidadregistrogenero()
        {
            AccesoDatos reg = new AccesoDatos();
            int resu = reg.obtenercantidadregistrogenero();
            return resu;


        }

        public void eliminarGenero(string id)
        {
            AccesoDatos reg = new AccesoDatos();

            reg.eliminarGenero(id);
        }

        public void actualizarGenero(string todo)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.actualizarGenero(todo);
        }
    }
}
