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
    public class DatosMarcas
    {
        AccesoDatos ds = new AccesoDatos();
        public Marcas getMarca(int id)
        {
            Marcas cat = new Marcas();
            DataTable tabla = ds.ObtenerTabla("Marcas", "Select * from MARCAS where id_marca=" + id);
            cat.setid_marca(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            cat.setNombre(tabla.Rows[0][1].ToString());
            return cat;
        }

        public DataTable getTablaMarcas()
        {
            //List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Marcas", "SELECT (id_marca)as ID_Marca,(nombre)as Nombre from MARCAS");
            return tabla;
        }


        public void AgregarMarca(String ID, String NOMBRE)
        {
            AccesoDatos reg = new AccesoDatos();
                reg.agregarMarcas(ID,NOMBRE);


        }

        public int obtenercatidadregistro() {
            AccesoDatos reg = new AccesoDatos();
            int resu;
            resu = reg.obtenercatidadregistro();
            return resu;
        }

        public void eliminarMarca(string id)
        {
            AccesoDatos reg = new AccesoDatos();

            reg.eliminarMarca(id);
        }

        public void actualizarMarca(string todo)
        {
            AccesoDatos reg = new AccesoDatos();
            reg.actualizarMarca(todo);
        }


    }
}
